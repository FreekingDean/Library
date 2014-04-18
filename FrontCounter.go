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

func checkOut(params map[string]string, client *Client) {
  isbn, isbnOk:= params["isbn"]
  copyNumber, copyOk := params["copy_number"]
  customerID, custOk := params["customer_id"]
  if !isbnOk || !copyOk || !custOk {
    SendErr(client, "Need more info", "co_info")
    return
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
      }
    } else {
      SendErr(client, "Customer not in good standing", "cust_stand")
    }
  } else {
    SendErr(client, "Book already checked out", "book_out")
  }
}

func checkIn(params map[string]string, client *Client) {
  
