package main

import (
  "log"
  "strings"
  "strconv"
)

//RecMat recieves the function coming in from the MsgMultiplexer and
// calls the proper function based off of the cmd
func RecMat(command string, params map[string]string, client *Client) bool {
  switch(command) {
    case "get_po": { return getPO(params, client) }
    case "receive": { return receive(params, client) }
    case "purchase": { return purchase(params, client) }
    case "save_copy": { return saveCopy(params, client) }
    case "save_book": { return saveBook(params, client) }
    case "report": { return maReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return false
}

//getPO gets the Purchase Order and its info specified
func getPO(params map[string]string, client *Client) bool {
  poS, poOk := params["po_number"]
  if !poOk {
    SendErr(client, "Need more info", "05002")
    return false
  }
  po, err := strconv.Atoi(poS)
  if err != nil {
    SendErr(client, "PO must be a number", "05003")
    return false;
  }
  var purchaseOrder PurchaseOrder
  db.Where("id = ?", po).First(&purchaseOrder)
  if purchaseOrder.Id == 0 {
    SendErr(client, "PO not found", "05004")
    return false
  }
  var poCopies []PoCopy
  db.Model(&purchaseOrder).Related(&poCopies)
  toSend := make(map[string]string)
  for id, curCopy := range poCopies {
    if curCopy.Copies > 0 {
      toSend["order_"+strconv.Itoa(id)] = strconv.Itoa(int(curCopy.Isbn))
      var book Book
      db.Where("isbn = ?", curCopy.Isbn).First(&book)
      toSend[strconv.Itoa(int(curCopy.Isbn))+"_name"] = book.Title
      toSend[strconv.Itoa(int(curCopy.Isbn))+"_copies"] = strconv.Itoa(int(curCopy.Copies))
    }
  }
  toSend["cost"] = strconv.Itoa(int(purchaseOrder.Cost))
  SendMessage(client, "success", toSend)
  return true
}

//recieve recieves items in a purchase order and deducts mone from the budget as needed
func receive(params map[string]string, client *Client) bool {
  orderNumS, orderOk := params["po_number"]
  if !orderOk {
    SendErr(client, "Need more info", "05002")
    return false
  }
  orderNum, err := strconv.Atoi(orderNumS)
  if err != nil {
    SendErr(client, "PO must be a number", "05003")
    return false
  }
  var po PurchaseOrder
  db.Where("id = ?", orderNum).First(&po)
  if po.Id == 0 {
    SendErr(client, "PO not found", "05004")
    return false
  }
  var poCopies []PoCopy
  db.Model(&po).Related(&poCopies)
  var newPoCopies []PoCopy
  log.Println(poCopies)
  for _, poCopy := range poCopies {
    copyS, copyOk := params[strconv.Itoa(int(poCopy.Isbn))+"_received"]
    if copyOk {
      log.Println("FOUND PO COPY")
      copies, err := strconv.Atoi(copyS)
      if err != nil {
        SendErr(client, "Recieved not a number", "05005")
        return false
      }
      if int64(copies) > poCopy.Copies {
        SendErr(client, "Can't receive more books than ordered", "05006")
        return false
      }
      var book Book
      db.Where("isbn = ?", poCopy.Isbn).First(&book)
      if book.Id == 0 {
        SendErr(client, "Book not found", "05006")
        return false
      }
      for i:=0; i<copies; i++ {
        book.Copy = append(book.Copy, BookCopy{Available: true, Condition: 0})
      }
      db.Save(&book)
      poCopy.Copies -= int64(copies)
      if poCopy.Copies > 0 {
        newPoCopies = append(newPoCopies, poCopy)
      }
      db.Save(&poCopy)
    }
  }
  po.Books = newPoCopies
  /*if len(newPoCopies) == 0 {
    var budget Budget
  */
  db.Save(&po)
  SendMessage(client, "success", make(map[string]string))
  return true
}

//purchase allows the user to setup a new purchase order and can add new books
// as needed
func purchase(params map[string]string, client *Client) bool {
  poS, poOk := params["po_number"]
  //bidS, bidOk := params["budget_id"]
  costS, costOk := params["cost"]
  if !costOk {
    SendErr(client, "Need more info", "05002")
    return false
  }
  cost, err := strconv.Atoi(costS)
  if err != nil {
    SendErr(client, "Cost must be number", "05005")
    return false
  }
  purchaseNumber := 0
  if poOk {
    purchaseNumber, err = strconv.Atoi(poS)
    if err != nil {
      SendErr(client, "Purchase Order must be number", "05006")
      return false
    }
  }
  var po PurchaseOrder
  db.Where("id = ?", purchaseNumber).First(&po)
  if poOk && po.Id == 0 {
    SendErr(client, "Purchase Order not found", "05007")
    return false
  }
  //var budget Budget
  //db.First(&budget)
  //if bgOk {
  //  db.Where("id = ?", budgetGroup).First(&bg)
  //}
  //if int(bg.Remaining) < cost {
  //  SendErr(client, "Not enough money in the group to purchase", "pu_money")
  //  return false
  //}
  for key, value := range params {
    if strings.Contains(key, "isbn") {
      isbn, err := strconv.Atoi(value)
      if err != nil {
        SendErr(client, "Isbn not number", "05008")
        return false
      }
      var book Book
      db.Where("isbn = ?", isbn).First(&book)
      if book.Id == 0 {
        title, titleOk := params[value+"_book_title"]
        author, authorOk := params[value+"_book_author"]
        genre, genreOk := params[value+"_book_genre"]
        if !titleOk || !authorOk || !genreOk {
          SendErr(client, "Need more info", "05002")
          return false
        }
        book.Isbn = int64(isbn)
        book.Title = title
        book.Author = author
        book.Genre = genre
        db.Save(&book)
      }
      var poCopy PoCopy
      db.Where("isbn = ? and purchase_order_id = ?", isbn,  po.Id)
      copiesS, copiesOk := params[value+"_copies"]
      if !copiesOk {
        SendErr(client, "Need more info", "05002")
        return false
      }
      copies, err := strconv.Atoi(copiesS)
      if err != nil {
        SendErr(client, "Copies must be number", "05008")
        return false
      }
      poCopy.Isbn = int64(isbn)
      poCopy.Copies = int64(copies)
      po.Books = append(po.Books, poCopy)
    }
  }
  po.Cost = int64(cost)
  db.Save(&po)
  SendMessage(client, "success", make(map[string]string))
  return true
}

//saveCopy saves a copy and all its condition to the database
func saveCopy(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  conditionS, condOk := params["condition"]
  copyNumS, copyOk := params["copy"]
  if !isbnOk || !condOk || !copyOk {
    SendErr(client, "Need more info", "05009")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "Isbn must be number", "05008")
    return false
  }
  condition, err := strconv.Atoi(conditionS)
  if err != nil {
    SendErr(client, "Condition must be number", "05011")
    return false
  }
  if condition > 5 {
    SendErr(client, "Condition can't be over 5", "05012")
    return false
  }
  copyNum, err := strconv.Atoi(copyNumS)
  if err != nil {
    SendErr(client, "Copy Number must be number", "05013")
    return false
  }
  var book Book
  db.Where("isbn = ?", isbn).First(&book)
  if book.Id == 0 {
    SendErr(client, "Book not found", "05014")
    return false
  }
  var copies []BookCopy
  db.Model(&book).Related(&copies)
  if len(copies) >= copyNum {
    SendErr(client, "Copy not found", "05015")
    return false
  }
  copies[copyNum].Condition = int64(condition)
  db.Save(&copies[copyNum])
  SendMessage(client, "success", make(map[string]string))
  return true
}

//saveBook saves teh book listed by isbn and its information
func saveBook(params map[string]string, client *Client) bool {
  isbnS, isbnOk := params["isbn"]
  title, titleOk := params["title"]
  author, authOk := params["author"]
  genre, genreOk := params["genre"]
  numCopiesS, copyOk := params["num_copies"]
  if !isbnOk || !titleOk || !authOk || !genreOk || !copyOk {
    SendErr(client, "Need more info", "05009")
    return false
  }
  isbn, err := strconv.Atoi(isbnS)
  if err != nil {
    SendErr(client, "Isbn must be number", "05008")
    return false
  }
  numCopies, err := strconv.Atoi(numCopiesS)
  if err != nil {
    SendErr(client, "Number of copies must be number", "05008")
    return false
  }
  var book Book
  db.Where("isbn = ?", isbn).First(&book)
  if book.Id == 0 {
    SendErr(client, "Book not found", "05014")
    return false
  }
  var copies []BookCopy
  db.Model(&book).Related(&copies)
  if len(copies) < numCopies {
    for i:=len(copies); i<numCopies; i++ {
      copies = append(copies, BookCopy{Available: true, Condition: 0})
    }
  }
  if len(copies) > numCopies {
    var toDel []BookCopy
    shouldDelete := false
    for i:=0; i<len(copies);i++ {
      if copies[i].Available {
        toDel = append(toDel, copies[i])
        if len(toDel) == (len(copies)-numCopies) {
          i = len(copies)
          shouldDelete = true
        }
      }
    }
    if shouldDelete {
      for _, curCopy := range toDel {
        db.Delete(&curCopy)
      }
    }
  }
  book.Title = title
  book.Author = author
  book.Genre = genre
  book.Copy = copies
  db.Save(&book)
  SendMessage(client, "success", make(map[string]string))
  return true
}

func maReport(params map[string]string, client *Client) bool {
  report := make(map[string]string)
  var purchases []PurchaseOrder
  db.Find(&purchases)
  report["num_purchases"] = strconv.Itoa(len(purchases))
  for index, purchase := range purchases {
    purchaseId := strconv.Itoa(int(purchase.Id))
    report["purchase_"+strconv.Itoa(index)] = purchaseId
    report[purchaseId+"_cost"] = strconv.Itoa(int(purchase.Cost))
    var poCopies []PoCopy
    db.Model(&purchase).Related(&poCopies)
    report[purchaseId+"_num_po_copies"] = strconv.Itoa(len(poCopies))
    for poIndex, poCopy := range poCopies {
      report[purchaseId+"_po_copy_"+strconv.Itoa(poIndex)+"_isbn"] = strconv.Itoa(int(poCopy.Isbn))
      report[purchaseId+"_po_copy_"+strconv.Itoa(poIndex)+"_copies"] = strconv.Itoa(int(poCopy.Copies))
    }
    if(index+1)%5 == 0 {
      report["more"] = "true"
      SendMessage(client, "success", report)
      report = make(map[string]string)
    }
  }
  report["more"] = "false"
  SendMessage(client, "success", report)
  return true
}
