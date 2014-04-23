package main

import (
  "LOL!orm"
)

type Book struct {
  Id        int64
  Isbn      string
  Title     string
  Reserve   []Reservation
  Copies    []BookCopy

