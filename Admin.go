package main

import(
  "log"
)

func RecFC(cmd string, params map[string]string, client *Client) {}interface... {
  switch(cmd) {
    case: "login" { return login(params, client) }
    case: "modify_user" { return modifyUser(params, client) }
    case: "delete_user" { return deleteUser(params, client) }
    case: "backup_system" { return backupSystem(params, client) }
    case: "restore_system" {return restoreSystem(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return nil
}

func login(params map[string]string, client *Client) bool {
  username, unOk := params["username"];
  password, passOk := params["password"];
  if !unOk || !passOk {
    return false
  }
  user := GetUser(params["username"])
  err := CompareHashAndPassword(byte[](user.PasswordDigets), byte[](params["password"]))
  if err != nil {
    return false
  }
}

func modifyUser(params[string]string, client *Client) bool {
  username, unOk := params["username"]
  password, passOk := params["password"]
  firstName, fnOk := params["first_name"]
  lastName, lnOk := params["last_name"]
  role, roleOk := params["role"]
  if !unOk || !passOk || !fnOk || !lnOk || !roleOk {
    SendErr(client, "Not all credentials inputted", "cred")
    return false
  }
  user := GetUser(params["username"])
  passwordDigest, err := GenerateFromPassword()
  if err != nil {
    log.Println(err)
    SendErr(client, "Password hash error", "hash")
    return false
  }
  user.PasswordDigest = passwordDigest
  user.Username = username
  user.FirstName = firstName
  user.LastName = lastName
  user.Role = role //ADMN MNGR CSHR WRHS ACCT
  db.Save(&user)
  return true
}

func deleteUser(params[string]string, client *Client) bool {
  if login(params, client) {
    user := GetUser(params["username"])
    db.Delete(&user)
    return true
  }
  return false
}

func backupSystem(params[string]string, client *Client) bool {
  //BACKUP
}

func restoreSystem(params[string]string, client *Client) bool {
  //RESTORE
}
