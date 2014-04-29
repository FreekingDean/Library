package main

import (
  //"log"
  "strconv"
)

func RecMat(command string, params map[string]string, client *Client) bool {
  switch(command) {
    case "recieving": { return recieve(params, client) }
    case "purchase": { return purchase(params, client) }
    case "inventory": { return inventory(params, client) }
    case "report": { return maReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return false
}

func recieve(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  quantS, quantOk := params["quantity"]
  orderNumS, orderOk := params["po_number"]
  if !isbnOk || !quantOk || !orderOk {
    SendErr(client, "Need more info", "re_info")
    return false
  }
  orderNum, err := strconv.Atoi(orderNumS)
  if err != nil {
    SendErr(client, "ordernumber must be number", "rec_isbn")
    return false
  }
  quant, err := strconv.Atoi(quantS)
  if err != nil {
    SendErr(client, "quant must be number", "rec_isbn")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "isbn must be number", "rec_isbn")
    return false
  }
  po := GetPO(orderNum)
  foundAt := -1
  for index, curBook := range po.Books {
    if int(curBook.Isbn) == isbn {
      //book := curBook
      if int(curBook.Copies) <= quant {
        foundAt = index
      } else {
        curBook.Copies -= int64(quant)
        foundAt = 0
      }
    }
  }
  if foundAt == -1 {
    SendErr(client, "Book not found", "bk_not_found")
    return false
  }
  book := GetBook(isbn)
  for i:=0; i<quant; i++ {
    book.Copy = append(book.Copy, BookCopy{Available: true, Condition: 0})
  }
  db.Save(&book)
  return true
}

func purchase(params map[string]string, client *Client) bool {
  poS, poOk := params["po_number"]
  budgetGroup, bgOk := params["budget_group"]
  isbnS, isbnOk := params["isbn"]
  quantS, quantOk := params["quantitiy"]
  costS, costOk := params["cost"]
  if !isbnOk || !poOk || !quantOk || !costOk {
    SendErr(client, "Need more info", "pu_info")
    return false
  }
  purchaseNumber, err := strconv.Atoi(poS)
  if err != nil {
    SendErr(client, "ordernumber must be number", "rec_isbn")
    return false
  }
  quant, err := strconv.Atoi(quantS)
  if err != nil {
    SendErr(client, "quant must be number", "rec_isbn")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "isbn must be number", "rec_isbn")
    return false
  }
  cost, err := strconv.Atoi(costS)
  if err != nil {
    SendErr(client, "cost must be number", "rec_isbn")
    return false
  }
  po := GetPO(purchaseNumber)
  bg := GetMasterBudget()
  if bgOk {
    bg = GetBudgetGroup(budgetGroup)
  }
  if int(bg.RemainingGroups) < cost {
    SendErr(client, "Not enough money in the group to purchase", "pu_money")
    return false
  }
  po.Books = append(po.Books, PoCopy{Isbn: int64(isbn), Copies: int64(quant)})
  db.Save(&po)
  return true
}

func inventory(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  if !isbnOk {
    SendErr(client, "Need more info", "pu_info")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "isbn must be number", "rec_isbn")
    return false
  }
  book := GetBook(isbn)
  title, titleOk := params["title"]
  if titleOk {
    book.Title = title
  }
  reserveToDelS, rtdOk := params["reserve_delete"]
  if rtdOk {
    reserveToDel, err := strconv.Atoi(reserveToDelS)
    if err != nil {
      SendErr(client, "isbn must be number", "rec_isbn")
      return false
    }
    var newReserves []Reservation
    for _, curRes := range book.Reserve {
      if reserveToDel != int(curRes.CustomerId) {
        newReserves = append(newReserves, curRes)
      }
    }
  }
  delCopyS, dcOk := params["copy_to_delete"]
  if dcOk {
    delCopy, err := strconv.Atoi(delCopyS)
    if err != nil {
      SendErr(client, "isbn must be number", "rec_isbn")
      return false
    }
    if book.Copy[delCopy].Available {
      book.Copy = append(book.Copy[0:delCopy], book.Copy[delCopy+1:len(book.Copy)]...)
    }
  }
  db.Save(&book)
  return true
}

func maReport(params map[string]string, client *Client) bool {
  return true
}
