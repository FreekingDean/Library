package main

import (
  "log"
)

func RecFC(command string, params map[string]string) {
  switch(cmd) {
    case: "check_out" { return checkOut(params, client) }
    case: "check_in" { return checkIn(params, client) }
    case: "search" { return search(params, client) }
    case: "reserve" { return reserve(params, client) }
    case: "manage_customer" { return manageCustomer(params, client) }
    case: "delete_customer" { return deleteCustomer(params, client) }
    case: "report" { return fcReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return nil
}

func checkOut(params map[string]string, client *Client) bool {
  isbn, isbnOk:= params["isbn"]
  copyNumber, copyOk := params["copy_number"]
  customerID, custOk := params["customer_id"]
  if !isbnOk || !copyOk || !custOk {
    SendErr(client, "Need more info", "co_info")
    return
  }
  book, exists := GetBook(isbn)
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

func reserve(params map[string]string, client *Client) bool {
  isbn, isbnOk := params["isbn"]
  customerID, custOk := params["customer_id"]
  if !isbnOk || !custOk || {
    SendErr(client, "Need more info", "re_info")
    return false
  }
  book, exists := GetBook(isbn)
  for id, thisCopy := range book.Copy {
    if thisCopy.Available {
      SendErr(client, "Book available with copy number: "+id, "rs_avail")
      return false
    }
  }
  book.Reserve = append(book.Reserve, Reserve{Customer: customerID}
  db.Save(&book)
  return true
}

func checkIn(params map[string]string, client *Client) bool {
  isbn, isbnOk := params["isbn"]
  copyNumber, copyOk := params["copy_number"]
  customerID, custOk := params["customer_id"]
  condition, condOk := params["condition"]
  if !isbnOk || !copyOk || !custOk || !condOk {
    SendErr(client, "Need more info", "ci_info")
    return false
  }
  book := GetBook(isbn)
  thisCopy := book.Copy[copyNumber]
  if !thisCopy.Available {
    if customer.CheckedOut[0] == thisCopy {
      customer.CheckedOut = customer.CheckedOut[1:2]
    } else if customer.CheckedOut[1] == thisCopy {
      customer.CheckedOut = customer.CheckedOut[0:1]
    } else {
      SendErr(client, "Book not checked out to customer", "co_not_cust")
      return false
    }
    if condition < thisCopy.Condition {
      customer.Status++
    }
    thisCopy.Condition = condition
    thisCopy.Available = true
  } else {
    SendErr(client, "Book not checked out", "co_not_out")
    return false
  }
  if book.Reserve != nil {
    reservation := book.Reserve[0]
    alertReserve(reservation.Customer, client)
    book.Reserve = book.Reserve[1:len(book.Reserve)]
  }
  db.Save(&book)
  return true
}

func alertReserve(custID int, client *Client) {
  info := make(map[string]string)
  info["customer_id"] = strconv.Itoa(custID)
  SendMsg(client, info)
}

func manageCustomer(params map[string]string, client *Client) bool {
  custID, custIdOk := params["customer_id"]
  firstName, firstOk := params["fist_name"]
  last_name, lastOk := params["last_name"]
  if !firstOk || !lastOk || !custOk {
    SendErr(client, "Need more info", "mc_info")
    return false
  }
  customer, found := GetCustomer(custId)
  if !found {
    SendErr(client, "Couldn't find customer with that ID", "dc_bad_id")
    return false
  }
  cust.FirstName = firstName
  cust.LastName = lastName
  cust.Status = params["status"]
  db.Save(&cust)
  return true
}

func deleteCustomer(params map[string]string, client *Client) bool {
  custID, custIdOk := params["customer_id"]
  if !custIdOk {
    SendErr(client, "Need more info", "dc_info")
    return false
  }
  customer, found := GetCustomer(custId)
  if !found {
    SendErr(client, "Couldn't find customer with that ID", "dc_bad_id")
    return false
  }
  db.Delete(&customer)
  return true
}

func search(params map[string]string, client *Client) bool {
  start, startOk := params["start"]
  var books []Book
  if !startOk {
    start = 0
  }
  userSearch := User
  if isbnOk {
    db.Offset(start*OFFSET_NUM).Where("isbn=?", isbn).Limit(OFFSET_NUM).Find(&books)
    SendMessage(client, "search_return", books)
    return true
  }
  title := "%"+params["title"]+"%"
  author := "%"+params["author"]+"%"
  genre := "%"+params["genre"]+"%"
  db.Offset(start*OFFSET_NUM).Where("title LIKE ? and author LIKE ? and genre LIKE ?", searchTitle).Limit(OFFSET_NUM).Find(&books)
  SendMessage(client, "search_return", books)
  return true
}
