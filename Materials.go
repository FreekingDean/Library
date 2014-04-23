package main

import (
  "log"
)

func RecFC(command string, params map[string]string) bool {
  switch(cmd) {
    case: "recieving" { return recieve(params, client) }
    case: "purchase" { return purchase(params, client) }
    case: "inventory" { return inventory(params, client) }
    case: "report" { return maReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return nil
}

func recieve(params map[string]string, client *Client) bool {
  isbn, isbnOk := params["isbn"]
  quant, quantOk := params["quantity"]
  orderNum, orderOk := params["po_number"]
  if !isbnOk || !quantOk || !orderOk {
    SendErr(client, "Need more info", "re_info")
    return false
  }
  po, exists := GetPO(orderNum)
  if !exists {
    SendErr(client, "Could not find purchase number", "po_not_found")
    return false
  }
  foundAt := -1
  for index, curBook := range po.Books {
    if curBook.Isbn == isbn {
      book := curBook
      if curBook.Copies <= quant {
        foundAt = index
      } else {
        curBook.Copies -= quant
        foundAt = 0
      }
    }
  }
  if foundAt := -1 {
    SendErr(client, "Book not found", "bk_not_found")
    return false
  }
  book, exists := GetBook(isbn)
  for i:=0; i<quant; i++ {
    book.Copies = append(book.Copies, BookCopy{Isbn: isbn, Available: true, Condition: 0}
  }
  db.Save(&book)
  return true
}

func purchase(params map[string]string, client *Client) bool {
  po, poOk := params["po_number"]
  budgetGroup, bgOk := params["budget_group"]
  isbn, isbnOk := params["isbn"]
  quant, quantOk := params["quantitiy"]
  cost, costOk := params["cost"]
  if !isbnOk || !poOk || !quantOk || !costOk {
    SendErr(client, "Need more info", "pu_info")
    return false
  }
  po, _ := GetPO(po)
  if bgOk {
    bg := GetBudgetGroup(budgetGroup)
  } else {
    bg := GetMasterBudget()
  }
  if bg.RemainingGroups < cost {
    SendErr(client, "Not enough money in the group to purchase", "pu_money")
    return false
  }
  po.Books = append(po.Books, PoCopy{Isbn: isbn, Copies: quant})
  db.Save(&po)
  return true
}

func inventory(params map[string]string, client *Client) bool {
  isbn, isbnOk := params["isbn"]
  if !isbnOk
    SendErr(client, "Need more info", "pu_info")
    return false
  }
  book, exists := GetBook(isbn)
  if !exists {
    SendErr(client, "Book not found", "in_no_book")
    return false
  }
  title, titleOk := params["title"]
  if titleOk {
    book.Title = title
  }
  reserveToDel, rtdOk := params["reserve_delete"]
  if rtdOk {
    var newReserves []Reservation
    for curRes := range book.Reserve {
      if reserveToDel != curRes.Customer {
        newReserves = append(newReserves, curRes)
      }
    }
  }
  delCopy, dcOk := params["copy_to_delete"]
  if dcOk {
    if book.Copies[delCopy].Available {
      book.Copies := append(book.Copies[0:delCopy], book.Copies[delCopy+1:len(book.Copies)]
    }
  }
  db.Save(&book)
  return true
}
