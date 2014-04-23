package main

import (
  "log"
)

func RecFC(command string, params map[string]string) bool {
  switch(cmd) {
    case: "recieving" { return recieve(params, client) }
    case: "purchase" { return purchase(params, client) }
    case: "inventory" { return inventory(params, client) }
    case: "manage_vendor" { return manageVendor(params, client) }
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
