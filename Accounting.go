package main

import (
  //"log"
  "strconv"
)

// RecAcc recieves a call from another class/module where, based on the call, will
// choose which case to point it toward
//
// parms command, String to be parsed and read to select case
// parms params, map of strings that hold parameter for the cases to use in later methods
// parms client, point to the Client module

func RecAcc(command string, params map[string]string, client *Client) bool {
  switch(command) {
    case "set_budget_group": { return setBudgetGroup(params, client) }
    case "set_master_budget": { return setMasterBudget(params, client) }
    case "manage_wallet": { return manageWallet(params, client) }
    case "report": { return acReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return false
}

// 

func setBudgetGroup(params map[string]string, client *Client) bool {
  group, groupOk := params["group_name"]
  amountS, amountOk := params["budget_amount"]
  amountI, err := strconv.Atoi(amountS)
  if err != nil {
    SendErr(client, "Amount not number!", "bg_number")
    return false
  }
  amount := int64(amountI)
  if !groupOk || !amountOk {
    SendErr(client, "Need more info", "bg_info")
    return false
  }
  if group == "MASTER" {
    SendErr(client, "Group can't be named \"MASTER\"", "bg_name")
    return false
  }
  budget := GetBudgetGroup(group)
  masterBudget := GetMasterBudget()
  masterBudget.RemainingGroups -= budget.Amount
  if amount > masterBudget.RemainingGroups {
    SendErr(client, "Amount can't exceed amount left in master budget", "bg_amnt")
    return false
  }
  budget.Name = group
  budget.Amount = amount
  db.Save(&budget)
  db.Save(&masterBudget)
  return true
}

func setMasterBudget(params map[string]string, client *Client) bool {
  amountS, amountOk := params["amount"]
  if !amountOk {
    SendErr(client, "Need more info", "mb_info")
    return false
  }
  amountI, err := strconv.Atoi(amountS)
  if err != nil {
    SendErr(client, "Amount not number!", "bg_number")
    return false
  }
  amount := int64(amountI)
  if !amountOk {
    SendErr(client, "Need more info", "mb_info")
    return false
  }
  mb := GetMasterBudget()
  if amount < mb.RemainingGroups {
    SendErr(client, "Budget must be more than the current total of all budget groups!", "mb_amnt")
    return false
  }
  mb.RemainingGroups -= (mb.Amount - amount)
  mb.Amount = amount
  return true
}

func manageWallet(params map[string]string, client *Client) bool {
  amountS, amountOk := params["amount"]
  reason, reasonOk := params["reason"]
  if !amountOk || !reasonOk {
    SendErr(client, "Need more info", "mw_info")
    return false
  }
  amountI, err := strconv.Atoi(amountS)
  if err != nil {
    SendErr(client, "Amount not number!", "bg_number")
    return false
  }
  amount := int64(amountI)
  wallet := GetLastWallet()
  newTot := wallet.RunningTotal + amount
  newWallet := Wallet{
    RunningTotal: newTot,
    Amount: amount,
    Reason: reason,
  }
  db.Save(&newWallet)
  return true
}

//TODO - IMPLEMENT
func acReport(params map[string]string, client *Client) bool {
  return true
}
