package main

import (
  "fmt"
  "log"
  "code.google.com/p/go.crypto/bcrypt"
  "github.com/jinzhu/gorm"
  _ "github.com/mattn/go-sqlite3"
)

var db gorm.DB

func init() {
  log.Println("starting db")
  var err error
  db, err = gorm.Open("sqlite3", "./LIBRARY.db")
  if err != nil {
    log.Fatal(err)
    return
  }
  db.LogMode(true)
  db.DB().SetMaxIdleConns(10)
  db.DB().Ping()
  db.SingularTable(true)
}

type Book struct {
  Id          int64
  Isbn        int64
  Title       string
  Author      string
  Genre       string
  Reserve     []Reservation
  Copy        []BookCopy
}

type Reservation struct {
  Id          int64
  BookId      int64
  CustomerId  int64
}

type BookCopy struct {
  Id          int64
  BookId      int64
  Condition   int64
  CustomerId  int64
  Available   bool
}

type Customer struct {
  Id          int64
  FirstName   string
  LastName    string
  Status      int64
  CheckedOut  []BookCopy
  Reserve     []Reservation
}

type Budget struct {
  Id              int64
  Name            string
  Amount          int64
  Remaining       int64
  LastWallet      []Wallet
}

type Wallet struct {
  Id              int64
  BudgetId        int64
  Reason          string
  Amount          int64
  RunningTotal    int64
}

type PurchaseOrder struct {
  Id          int64
  Books       []PoCopy
  Cost        int64
}

type PoCopy struct {
  Id              int64
  PurchaseOrderId int64
  Isbn            int64
  Copies          int64
}

type User struct {
  Id              int64
  FirstName       string
  LastName        string
  Username        string
  PasswordDigest  string
  Role            int64
}

func BuildDB() {

  db.CreateTable(User{})
  db.CreateTable(Book{})
  db.CreateTable(Reservation{})
  db.CreateTable(BookCopy{})
  db.CreateTable(Wallet{})
  db.CreateTable(Customer{})
  db.CreateTable(Budget{})
  db.CreateTable(PurchaseOrder{})
  db.CreateTable(PoCopy{})
  passwordDigest, err := bcrypt.GenerateFromPassword([]byte("admin"), 4)
  if err != nil {
    log.Fatal(err)
    return
  }
  db.Save(&User{Username: "root", PasswordDigest: string(passwordDigest), Role: 0 })
  var wallets []Wallet
  wallets = append(wallets, Wallet{Reason: "Init", Amount: 10000, RunningTotal: 10000})
  db.Save(&Budget{Name: "MASTER", Amount: 10000, Remaining: 10000, LastWallet: wallets})
  var user User
  db.First(&user)
  log.Println(user.Username + ":"+ user.PasswordDigest)
}

func GetUser(username string) User {
  var user User
  fmt.Println(username)
  db.First(&user)
  return user
}
