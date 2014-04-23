package main

import (
  "log"
)

func RecFC(command string, params map[string]string) bool {
  switch(cmd) {
    case: "set_budget_group" { return setBudgetGroup(params, client) }
    case: "set_master_budget" { return setMasterBudget(params, client) }
    case: "manage_wallet" { return manageWallet(params, client) }
    case: "report" { return acReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return nil
}

func setBudgetGroup(params map[string]string, client *Client) bool {
  group, groupOk := params["group_name"]
  amount, amountOk := params["budget_amount"]
  if !groupOk {
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
  db.save(&masterBudget)
}

func setMasterBudget(params map[string]string, client *Client) bool {
  amount := params["amount"]
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
  amount, amountOk := params["amount"]
  reason, reasonOk := params["reason"]
  if !amountOk || !reasonOk {
    SendErr(client, "Need more info", "mw_info")
    return false
  }
  wallet := GetLastWallet()
  newWallet := Wallet{
    RunningTotal: wallet.RunningTotal += amount
    Amount: amount
    Reason: reason
  }
  db.Save(&newWallet)
  return true
}
