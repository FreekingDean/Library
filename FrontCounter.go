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
    case "reserve": { return reserve(params, client) }
    case "manage_customer": { return manageCustomer(params, client) }
    case "delete_customer": { return deleteCustomer(params, client) }
    case "report": { return fcReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
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
    SendErr(client, "Need more info", "co_info")
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
  book := GetBook(isbn)
  thisCopy := book.Copy[copyNumber]
  if thisCopy.Available {
    customer := GetCustomer(customerID)
    if customer.Status <= 3 {
      if len(customer.CheckedOut) < 2 {
        thisCopy.Available = false
        customer.CheckedOut = append(customer.CheckedOut, thisCopy)
      } else {
        SendErr(client, "Too many books already checked out", "co_number")
        return false
      }
    } else {
      SendErr(client, "Customer not in good standing", "cust_stand")
      return false
    }
  } else {
    SendErr(client, "Book already checked out", "book_out")
    return false
  }
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
    SendErr(client, "Need more info", "re_info")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "Isbn not number", "co_isbn")
    return false
  }
  customerId, err := strconv.Atoi(customerIDS)
  if err != nil {
    SendErr(client, "CustomerID not number", "co_isbn")
    return false
  }
  book := GetBook(isbn)
  for id, thisCopy := range book.Copy {
    if thisCopy.Available {
      SendErr(client, "Book available with copy number: "+strconv.Itoa(id), "rs_avail")
      return false
    }
  }
  book.Reserve = append(book.Reserve, Reservation{CustomerId: int64(customerId)})
  db.Save(&book)
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
    SendErr(client, "Need more info", "ci_info")
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
  book := GetBook(isbn)
  thisCopy := book.Copy[copyNumber]
  customer := GetCustomer(customerID)
  if !thisCopy.Available {
    if customer.CheckedOut[0] == thisCopy {
      customer.CheckedOut = customer.CheckedOut[1:2]
    } else if customer.CheckedOut[1] == thisCopy {
      customer.CheckedOut = customer.CheckedOut[0:1]
    } else {
      SendErr(client, "Book not checked out to customer", "co_not_cust")
      return false
    }
    if int64(condition) < thisCopy.Condition {
      customer.Status++
    }
    thisCopy.Condition = int64(condition)
    thisCopy.Available = true
  } else {
    SendErr(client, "Book not checked out", "co_not_out")
    return false
  }
  if book.Reserve != nil {
    reservation := book.Reserve[0]
    alertReserve(int(reservation.CustomerId), client)
    book.Reserve = book.Reserve[1:len(book.Reserve)]
  }
  db.Save(&book)
  return true
}

//alertReserve alerts a customer if a book they want was returned by another customer.
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func alertReserve(custID int, client *Client) {
  info := make(map[string]string)
  info["customer_id"] = strconv.Itoa(custID)
  SendMessage(client, "reservation_alert", info)
}

//manageCustomer 
//param client pointer to the original caller
//param params map of parameter names and values
//return false if there is a problem
func manageCustomer(params map[string]string, client *Client) bool {
  custIDS, custOk := params["customer_id"]
  firstName, firstOk := params["fist_name"]
  lastName, lastOk := params["last_name"]
  statusS, statusOk := params["status"]
  if !firstOk || !lastOk || !custOk {
    SendErr(client, "Need more info", "mc_info")
    return false
  }
  customerID, err := strconv.Atoi(custIDS)
  if err != nil {
    SendErr(client, "CustomerID not number", "co_isbn")
    return false
  }
  customer := GetCustomer(customerID)
  if customer == nil {
    SendErr(client, "Couldn't find customer with that ID", "dc_bad_id")
    return false
  }
  var statusI int
  if statusOk {
    statusI, err = strconv.Atoi(statusS)
    if err != nil {
      SendErr(client, "Status must be number", "mc_status")
      return false
    }
  } else {
    statusI = 0
  }
  status := int64(statusI)
  customer.FirstName = firstName
  customer.LastName = lastName
  customer.Status = status
  db.Save(&customer)
  return true
}


func deleteCustomer(params map[string]string, client *Client) bool {
  customerIDS, custIdOk := params["customer_id"]
  if !custIdOk {
    SendErr(client, "Need more info", "dc_info")
    return false
  }
  customerId, err := strconv.Atoi(customerIDS)
  if err != nil {
    SendErr(client, "CustomerID not number", "co_isbn")
    return false
  }
  customer := GetCustomer(customerId)
  if customer == nil {
    SendErr(client, "Couldn't find customer with that ID", "dc_bad_id")
    return false
  }
  db.Delete(&customer)
  return true
}

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
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "isbn not number", "co_isbn")
    return false
  }
  if isbnOk {
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
  SendMessage(client, "search_return", bookMap)
  return true
}

func fcReport(params map[string]string, client *Client) bool {
  return true
}
