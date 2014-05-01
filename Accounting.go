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
    case "get_budget":  {return getBudget(params, client) }
    case "manage_budget": { return manageBudget(params, client) }
    case "manage_wallet": { return manageWallet(params, client) }
    case "report": { return acReport(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return false
}

func getBudget(params map[string]string, client *Client) bool {
  bidS, bidOk := params["budget_id"]
  var bid int
  var err error
  if bidOk {
    bid, err = strconv.Atoi(bidS)
    if err != nil {
      SendErr(client, "Budget ID not numner!", "04001")
      return false
    }
  } else {
    bid = 1
  }
  var budget Budget
  db.Where("id = ?", bid).First(&budget)
  rtnBudget := make(map[string]string)
  if budget.Id == 0 {
    SendErr(client, "Couldn't find budget", "04002")
    return false
  }
  rtnBudget["id"] = strconv.Itoa(int(budget.Id))
  rtnBudget["remaining"] = strconv.Itoa(int(budget.Remaining))
  rtnBudget["name"] = budget.Name
  rtnBudget["amount"] = strconv.Itoa(int(budget.Amount))
  var wallets []Wallet
  var wallet Wallet
  db.Model(&budget).Related(&wallets)
  if len(wallets) > 0 {
    wallet = wallets[len(wallets)-1]
  }
  rtnBudget["wallet_id"] = strconv.Itoa(int(wallet.Id))
  rtnBudget["wallet_reason"] = wallet.Reason
  rtnBudget["wallet_amount"] = strconv.Itoa(int(wallet.Amount))
  rtnBudget["wallet_running_total"] = strconv.Itoa(int(wallet.RunningTotal))
  SendMessage(client, "success", rtnBudget)
  return true
}

func manageBudget(params map[string]string, client *Client) bool {
  bidS, bidOk := params["budget_id"]
  group, groupOk := params["group_name"]
  amountS, amountOk := params["budget_amount"]
  if !groupOk || !amountOk {
    SendErr(client, "Need more info", "04003")
    return false
  }
  bid := 0
  var err error
  if bidOk {
    bid, err = strconv.Atoi(bidS)
    if err != nil {
      SendErr(client, "Budget ID not number!", "04004")
      return false
    }
  }
  amount, err := strconv.Atoi(amountS)
  if err != nil {
    SendErr(client, "Amount not number!", "04005")
    return false
  }
  var budget Budget
  var wallets []Wallet
  var wallet Wallet
  var mBud Budget
  var mWals []Wallet
  var mWal Wallet
  db.Where("id = ?", bid).First(&budget)
  db.Model(&budget).Related(&wallets)
  if len(wallets) > 0 {
    wallet = wallets[len(wallets)-1]
  }
  db.Where("id = 1").First(&mBud)
  db.Model(&mBud).Related(&mWals)
  if len(mWals) > 0 {
    mWal = mWals[len(mWals)-1]
  }
  if budget.Id == 0 && bid != 0 {
    SendErr(client, "Couldn't find budget", "04002")
    return false
  }
  if budget.Id == 1 && group != budget.Name {
    SendErr(client, "Can't rename MASTER budget", "04006")
    return false
  }
  diff :=  int64(amount) - budget.Amount
  if budget.Id != 1 && int64(amount) > mBud.Remaining {
    SendErr(client, "Budget can't exceed remaining  master budget", "04007")
    return false
  }
  diffMas := diff + mWal.RunningTotal
  diffWal := diff + wallet.RunningTotal
  if diffMas <  0 || diffWal < 0 {
    SendErr(client, "Not enough money to lower the budget", "04008")
    return false
  }
  var newWal Wallet
  newWal.Amount = diff
  newWal.RunningTotal = diffWal
  newWal.Reason = "Budget changed by: "+strconv.Itoa(int(diff))
  wallets = append(wallets, newWal)
  budget.Name = group
  budget.Amount = int64(amount)
  budget.LastWallet = wallets
  mBud.LastWallet = mWals
  if bid == 1 {
    mBud.Remaining += diff
  } else {
    mBud.Remaining -= diff
  }
  if budget.Id != 1 {
    db.Save(&mBud)
  } else {
    budget.Remaining += diff
  }
  db.Save(&budget)
  SendMessage(client, "success", make(map[string]string))
  return true
}

func manageWallet(params map[string]string, client *Client) bool {
  bidS, bidOk := params["budget_id"]
  amountS, amountOk := params["amount"]
  reason, reasonOk := params["reason"]
  if !amountOk || !reasonOk || !bidOk {
    SendErr(client, "Need more info", "mw_info")
    return false
  }
  bid, err = strconv.Atoi(bidS)
  if err != nil {
    SendErr(client, "Budget ID not number!", "04004")
    return false
  }
  amountI, err := strconv.Atoi(amountS)
  if err != nil {
    SendErr(client, "Amount not number!", "04009")
    return false
  }
  amount := int64(amountI)
  var budget Budget
  var wallet Wallet
  db.Where("id = ?", bid).First(&budget)
  if budget.Id == 0 {
    SendErr(client, "Couldn't find budget", "04002")
    return false
  }
  var wallets []Wallet
  var wallet Wallet
  var mBud Budget
  var mWals []Wallet
  var mWal Wallet
  db.Where("id = ?", bid).First(&budget)
  db.Model(&budget).Related(&wallets)
  if len(wallets) > 0 {
    wallet = wallets[len(wallets)-1]
  }
  db.Where("id = 1").First(&mBud)
  db.Model(&mBud).Related(&mWals)
  if len(mWals) > 0 {
    mWal = mWals[len(mWals)-1]
  }
  newTot := wallet.RunningTotal + amount
  if newTot < 0 {
    SendErr(client, "Not enough money", "04010")
    return false
  }
  newWallet := Wallet{
    RunningTotal: newTot,
    Amount: amount,
    Reason: reason,
  }
  budget.LastWallet = append(wallets, newWallet)
  db.Save(&budget)
  if budget.Id != 1 {
    newTot = mWal.RunningTotal + amount
    newMWallet := Wallet{
      RunningTotal: newTot,
      Amount: amount,
      Reason: "Budget ["+budget.Name+"] :"+reason
    }
    mBud.LastWallet = append(mWals, newMWallet)
    db.Save(&mBud)
  }
  SendMessage(client, "success", make(map[string]string))
  return true
}

//TODO - IMPLEMENT
func acReport(params map[string]string, client *Client) bool {
  return true
}
