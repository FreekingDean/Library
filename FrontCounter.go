package main

import (
  "strconv"
  //"log"
)

const OFFSET_NUM = 10

//RecFC recieves the command and routes it to the correct function.
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func RecFC(command string, params map[string]string, client *Client) bool {
  switch(command) {
    case "check_out": { return checkOut(params, client) }
    case "check_in": { return checkIn(params, client) }
    case "search": { return search(params, client) }
    case "get_book": { return getBook(params, client) }
    case "reserve": { return reserve(params, client) }
    case "get_customer": {return getCustomer(params, client) }
    case "cancel_reserve": { return cancelReserve(params, client) }
    case "manage_customer": { return manageCustomer(params, client) }
    case "delete_customer": { return deleteCustomer(params, client) }
    case "report": { return fcReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "06001")
  }
  return false
}

//checkOut performs sanity checks and then checks to see if the 
//DB to see if the customer can take out a book.  If they can it 
//adds the book to the DB as being checked out by 
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem or the customer can't checkout a book
func checkOut(params map[string]string, client *Client) bool {
  isbnS, isbnOk:= params["isbn"]
  copyNumberS, copyOk := params["copy_number"]
  customerIDS, custOk := params["customer_id"]
  if !isbnOk || !copyOk || !custOk {
    SendErr(client, "Need more info", "06002")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "Isbn not number", "06003")
    return false
  }
  customerID, err := strconv.Atoi(customerIDS)
  if err != nil {
    SendErr(client, "CustomerID not number", "06004")
    return false
  }
  copyNumber, err := strconv.Atoi(copyNumberS)
  if err != nil {
    SendErr(client, "CopyNumber not number", "06005")
    return false
  }
  var book Book
  db.Where("isbn = ?", isbn).First(&book)
  if book.Id == 0 {
    SendErr(client, "Book not found", "06006")
    return false
  }
  var copies []BookCopy
  db.Model(&book).Related(&copies)
  if copies[copyNumber].Available {
    var customer Customer
    db.Where("id = ?", customerID).First(&customer)
    if customer.Id == 0 {
      SendErr(client, "Customer not found", "06007")
      return false
    }
    if customer.Status <= 3 {
      if len(customer.CheckedOut) < 2 {
        copies[copyNumber].Available = false
        var reserve Reservation
        db.Where("book_id = ? and customer_id = ?", book.Id, customer.Id).First(&reserve)
        if reserve.Id != 0 {
          db.Delete(&reserve)
        }
        customer.CheckedOut = append(customer.CheckedOut, copies[copyNumber])
        db.Save(&customer)
      } else {
        SendErr(client, "Too many books already checked out", "06008")
        return false
      }
    } else {
      SendErr(client, "Customer not in good standing", "06009")
      return false
    }
  } else {
    SendErr(client, "Book already checked out", "06010")
    return false
  }
  SendMessage(client, "success", make(map[string]string))
  return true
}

//reserve puts a book reserve.  It checks for errors or if there is a copy in stock first
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func reserve(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  customerIDS, custOk := params["customer_id"]
  if !isbnOk || !custOk {
    SendErr(client, "Need more info", "06002")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "Isbn must be number", "06003")
    return false
  }
  customerId, err := strconv.Atoi(customerIDS)
  if err != nil {
    SendErr(client, "Customer ID must be number", "06004")
    return false
  }
  var book Book
  db.Where("isbn = ?", isbn).First(&book)
  if book.Id == 0 {
    SendErr(client, "Book not found", "06005")
    return false
  }
  for id, thisCopy := range book.Copy {
    if thisCopy.Available {
      SendErr(client, "Book available with copy number: "+strconv.Itoa(id), "06011")
      return false
    }
  }
  var reserve Reservation
  db.Where("book_id = ? and customer_id = ?", book.Id, customerId).First(&reserve)
  if reserve.Id != 0 {
    SendErr(client, "Reservation already exists", "06012")
    return false
  }
  book.Reserve = append(book.Reserve, Reservation{CustomerId: int64(customerId)})
  db.Save(&book)
  SendMessage(client, "success", make(map[string]string))
  return true
}

//cancelReserve takes a reserve out. It checks for errors
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func cancelReserve(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  customerIDS, custOk := params["customer_id"]
  if !isbnOk || !custOk {
    SendErr(client, "Need more info", "06002")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "Isbn not number", "06003")
    return false
  }
  customerId, err := strconv.Atoi(customerIDS)
  if err != nil {
    SendErr(client, "CustomerID not number", "06004")
    return false
  }
  var book Book
  db.Where("isbn = ?", isbn).First(&book)
  var reserves []Reservation
  db.Model(&book).Related(&reserves)
  for _, thisReserve := range reserves {
    if thisReserve.CustomerId == int64(customerId) {
      db.Delete(&thisReserve)
    }
  }
  SendMessage(client, "success", make(map[string]string))
  return true
}

//checkIn checks in a book a customer is returning.  Checks for formating errors
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func checkIn(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  copyNumberS, copyOk := params["copy_number"]
  customerIDS, custOk := params["customer_id"]
  conditionS, condOk := params["condition"]
  if !isbnOk || !copyOk || !custOk || !condOk {
    SendErr(client, "Need more info", "06001")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "Isbn not number", "co_isbn")
    return false
  }
  customerID, err := strconv.Atoi(customerIDS)
  if err != nil {
    SendErr(client, "CustomerID not number", "co_isbn")
    return false
  }
  copyNumber, err := strconv.Atoi(copyNumberS)
  if err != nil {
    SendErr(client, "CopyNumber not number", "co_isbn")
    return false
  }
  condition, err := strconv.Atoi(conditionS)
  if err != nil {
    SendErr(client, "CopyNumber not number", "co_isbn")
    return false
  }
  var book Book
  db.Where("isbn = ?", isbn).First(&book)
  var copies []BookCopy
  db.Model(&book).Related(&copies)
  book.Copy = copies
  if copyNumber > len(book.Copy) {
    SendErr(client, "Copy Number over number of copies", "06006")
    return false
  }
  var customer Customer
  db.Where("id = ?", customerID).First(&customer)
  db.First(&customer, book.Copy[copyNumber].CustomerId)
  if customer.Id == 0 {
    SendErr(client, "Book not checked out", "06007")
    return false
  }
  if int64(customerID) != customer.Id {
    SendErr(client, "Customer not the one checking in", "06008")
    return false
  }
  if int64(condition) < book.Copy[copyNumber].Condition {
    customer.Status++
  }
  book.Copy[copyNumber].Condition = int64(condition)
  book.Copy[copyNumber].CustomerId = 0
  book.Copy[copyNumber].Available = true
  db.Save(&book)
  if book.Reserve != nil {
    reservation := book.Reserve[0]
    alertReserve(int(reservation.CustomerId), client)
    return true
  }
  SendMessage(client, "success", make(map[string]string))
  return true
}

//alertReserve alerts a customer if a book they want was returned by another customer.
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func alertReserve(custID int, client *Client) {
  info := make(map[string]string)
  info["alert_reserve"] = "true"
  info["customer_id"] = strconv.Itoa(custID)
  SendMessage(client, "string", info)
}

//getCustomer gets a customer's infor based off his ID
func getCustomer(params map[string]string, client *Client) bool {
  customerIdS, custOk := params["customer_id"]
  if !custOk {
    SendErr(client, "Need more info", "06002")
    return false
  }
  customerId, err := strconv.Atoi(customerIdS)
  if err != nil {
    SendErr(client, "Customer Id must be number", "06003")
    return false
  }
  var customer Customer
  db.Where("id = ?", customerId).First(&customer)
  if customer.Id == 0 {
    SendErr(client, "Customer not found", "06004")
    return false
  }
  toReturn := make(map[string]string)
  toReturn["first_name"] = customer.FirstName
  toReturn["last_name"] = customer.LastName
  toReturn["status"] = strconv.Itoa(int(customer.Status))
  var reserves []Reservation
  db.Model(&customer).Related(&reserves)
  for index, curRes := range reserves {
    var book Book
    db.First(&book, curRes.BookId)
    toReturn[strconv.Itoa(index)+"_reservation"] = strconv.Itoa(int(book.Isbn))
  }
  var checkOuts []BookCopy
  db.Model(&customer).Related(&checkOuts)
  for index, curCO := range checkOuts {
    toReturn[strconv.Itoa(index)+"_checked_out"] = strconv.Itoa(int(curCO.BookId))
  }
  SendMessage(client, "success", toReturn)
  return true
}

//manageCustomer 
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func manageCustomer(params map[string]string, client *Client) bool {
  custIDS, custOk := params["customer_id"]
  firstName, firstOk := params["first_name"]
  lastName, lastOk := params["last_name"]
  statusS, statusOk := params["status"]
  var customer Customer
  if custOk {
    customerId, err := strconv.Atoi(custIDS)
    if err != nil {
      SendErr(client, "Customer Id must be number", "06005")
      return false
    }
    db.Where("id = ?", customerId).First(&customer)
    if customer.Id == 0 {
      SendErr(client, "Couldn't find customer with that Id", "06006")
      return false
    }
    if statusOk {
      status, err := strconv.Atoi(statusS)
      if err != nil {
        SendErr(client, "Status must be number", "mc_status")
        return false
      }
      customer.Status = int64(status)
    }
    if firstOk {
      customer.FirstName = firstName
    }
    if lastOk {
      customer.LastName = lastName
    }
  } else {
    if !firstOk || !lastOk {
      SendErr(client, "Need more info", "06002")
      return false
    }
    customer.FirstName = firstName
    customer.LastName = lastName
    customer.Status = 0
  }
  db.Save(&customer)
  SendMessage(client, "success", make(map[string]string))
  return true
}

//Delete customer deletes a customer with that ID
func deleteCustomer(params map[string]string, client *Client) bool {
  customerIDS, custIdOk := params["customer_id"]
  if !custIdOk {
    SendErr(client, "Need more info", "06002")
    return false
  }
  customerId, err := strconv.Atoi(customerIDS)
  if err != nil {
    SendErr(client, "CustomerID not number", "06004")
    return false
  }
  var customer Customer
  db.Where("id = ?", customerId).First(&customer)
  if customer.Id == 0 {
    SendErr(client, "Couldn't find customer with that ID", "06007")
    return false
  }
  var checkOuts []BookCopy
  db.Model(&customer).Related(&checkOuts)
  if len(checkOuts) > 0 {
    SendErr(client, "Customer has a checkout", "06008")
    return false
  }
  var reservations []Reservation
  db.Model(&customer).Related(&reservations)
  db.Delete(&reservations)
  db.Delete(&customer)
  SendMessage(client, "success", make(map[string]string))
  return true
}

//search finds books with the given paramters if they exsist after sanity checks are done
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func search(params map[string]string, client *Client) bool {
  startS, startOk := params["start"]
  var start = 0
  var err error
  if startOk {
    start, err = strconv.Atoi(startS)
    if err != nil {
      SendErr(client, "Start not number", "co_isbn")
      return false
    }
  }
  var books []Book
  isbnS, isbnOk := params["isbn"]
  if isbnOk {
    isbn, err := strconv.Atoi(isbnS)
    if err != nil {
      SendErr(client, "isbn not number", "co_isbn")
      return false
    }
    db.Offset(start*OFFSET_NUM).Where("isbn=?", isbn).Limit(OFFSET_NUM).Find(&books)
    var bookMap = make(map[string]string)
    for index, book := range books {
      bookMap["book_"+strconv.Itoa(index)] = strconv.Itoa(int(book.Isbn))
    }
    SendMessage(client, "search_return", bookMap)
    return true
  }
  title := "%"+params["title"]+"%"
  author := "%"+params["author"]+"%"
  genre := "%"+params["genre"]+"%"
  db.Offset(start*OFFSET_NUM).Where("title LIKE ? and author LIKE ? and genre LIKE ?", title, author, genre).Limit(OFFSET_NUM).Find(&books)
  var bookMap = make(map[string]string)
  for index, book := range books {
    bookMap["book_"+strconv.Itoa(index)] = strconv.Itoa(int(book.Isbn))
  }
  SendMessage(client, "success", bookMap)
  return true
}

//getBook grabs the book based off of the ISBN
func getBook(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  if !isbnOk {
    SendErr(client, "Need more info", "06002")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "ISBN not number", "06003")
    return false
  }
  var book Book
  db.Where("isbn = ?", isbn).First(&book)
  if book.Id == 0 {
    SendErr(client, "Book not found", "06004")
    return false
  }
  var copies []BookCopy
  db.Model(&book).Related(&copies)
  toReturn := make(map[string]string)
  for index, curCopy := range copies {
    toReturn["condition_"+strconv.Itoa(index)] = strconv.Itoa(int(curCopy.Condition))
    toReturn["checked_out_"+strconv.Itoa(index)] = strconv.Itoa(int(curCopy.CustomerId))
  }
  var reserves []Reservation
  db.Model(&book).Related(&reserves)
  for index, curReserve := range reserves {
    toReturn["reserve_"+strconv.Itoa(index)] = strconv.Itoa(int(curReserve.CustomerId))
  }
  toReturn["title"] = book.Title
  toReturn["genre"] = book.Genre
  toReturn["author"] = book.Author
  toReturn["book_id"] = strconv.Itoa(int(book.Id))
  SendMessage(client, "success", toReturn)
  return true
}

//fcReport sends a full report to the client via a large map. It sends
// the report every five items with the tag "more" in order for the client
// to know that they will be recieveing more data soon.
func fcReport(params map[string]string, client *Client) bool {
  var books []Book
  var customers []Customer
  db.Find(&books)
  report := make(map[string]string)
  report["num_books"] = strconv.Itoa(len(books))
  for index, book := range books {
    bookId :=  strconv.Itoa(int(book.Id))
    report["book_"+strconv.Itoa(index)] = bookId
    report[bookId+"_isbn"] = strconv.Itoa(int(book.Isbn))
    report[bookId+"_title"] = book.Title
    report[bookId+"_author"] = book.Author
    report[bookId+"_genre"] = book.Genre
    var copies []BookCopy
    db.Model(&book).Related(&copies)
    report[bookId+"_num_copies"] = strconv.Itoa(len(copies))
    for copyIndex,  curCopy := range copies {
      report[bookId+"_copy_"+strconv.Itoa(copyIndex)+"_condition"] = strconv.Itoa(int(curCopy.Condition))
      report[bookId+"_copy_"+strconv.Itoa(copyIndex)+"_checkout_id"] = strconv.Itoa(int(curCopy.CustomerId))
    }
    var reservations []Reservation
    db.Model(&book).Related(&reservations)
    for resIndex, curReserve := range reservations {
      report[bookId+"_reservation_"+strconv.Itoa(resIndex)+"_reserve_id"] = strconv.Itoa(int(curReserve.CustomerId))
    }
    if (index+1)%5 == 0 {
      report["more"] = "true"
      SendMessage(client, "success", report)
      report = make(map[string]string)
    }
  }
  report["more"] = "true"
  SendMessage(client, "success", report)
  report["cust"] = "true"
  db.Find(&customers)
  report["num_customers"] = strconv.Itoa(len(customers))
  for index, customer := range customers {
    custId := strconv.Itoa(int(customer.Id))
    report["customer_"+strconv.Itoa(index)] = custId
    report[custId + "_fist_name"] = customer.FirstName
    report[custId + "_last_name"] = customer.LastName
    report[custId + "_status"] = strconv.Itoa(int(customer.Status))
    var copies []BookCopy
    db.Model(&customer).Related(&copies)
    report[custId+"_num_checkouts"] = strconv.Itoa(len(copies))
    for copyIndex,  curCopy := range copies {
      report[custId+"_copy_"+strconv.Itoa(copyIndex)+"_condition"] = strconv.Itoa(int(curCopy.Condition))
      report[custId+"_copy_"+strconv.Itoa(copyIndex)+"_book_id"] = strconv.Itoa(int(curCopy.BookId))
    }
    var reservations []Reservation
    db.Model(&customer).Related(&reservations)
    for resIndex, curReserve := range reservations {
      report[custId+"_reservation_"+strconv.Itoa(resIndex)+"_book_id"] = strconv.Itoa(int(curReserve.BookId))
    }
    if (index+1)%5 == 0 {
      report["more"] = "true"
      SendMessage(client, "success", report)
      report = make(map[string]string)
    }
  }
  report["more"] = "false"
  SendMessage(client, "success", report)
  return true
}
