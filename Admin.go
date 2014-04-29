package main

import(
  "fmt"
  "log"
  "strconv"
  "code.google.com/p/go.crypto/bcrypt"
)

func RecAdmin(cmd string, params map[string]string, client *Client) bool {
  switch(cmd) {
    case "login": { return login(params, client) }
    case "get_user": { return getUser(params, client) }
    case "modify_user": { return modifyUser(params, client) }
    case "delete_user": { return deleteUser(params, client) }
    case "backup_system": { return backupSystem(params, client) }
    case "restore_system": {return restoreSystem(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "03001")
  }
  return false
}

func login(params map[string]string, client *Client) bool {
  username, unOk := params["username"]
  password, passOk := params["password"]
  if !unOk || !passOk {
    SendErr(client, "need info", "03002")
    return false
  }
  var user User
  db.Where("username = ?", username).First(&user)
  err := bcrypt.CompareHashAndPassword([]byte(user.PasswordDigest), []byte(password))
  if err != nil  || user.Id == 0 {
    SendErr(client, "username/password wrong", "03003")
    return false
  }
  loggedIn := make(map[string]string)
  loggedIn["role"] = strconv.Itoa(int(user.Role))
  SendMessage(client, "logged_in", loggedIn)
  return true
}

func getUser(params map[string]string, client *Client) bool {
  userId, uIdOk := params["user_id"]
  if !uIdOk {
    SendErr(client, "Need user ID", "03004")
    return false
  }
  uid, err := strconv.Atoi(userId)
  if err != nil {
    SendErr(client, "User ID must be number", "03005")
    return false
  }
  var user User
  db.First(&user, uid)
  fmt.Println(user.Id)
  if user.Id == 0 {
    SendErr(client, "User ID not found", "03006")
    return false
  }
  foundUser := make(map[string]string)
  foundUser["username"] = user.Username
  foundUser["role"] = strconv.Itoa(int(user.Role))
  foundUser["first_name"] = user.FirstName
  foundUser["last_name"] = user.LastName
  SendMessage(client, "user_found", foundUser)
  return true
}

func modifyUser(params map[string]string, client *Client) bool {
  username, unOk := params["username"]
  password, passOk := params["password"]
  newPass, newOk := params["new_password"]
  firstName, fnOk := params["first_name"]
  lastName, lnOk := params["last_name"]
  roleS, roleOk := params["role"]
  uidS, uidOk := params["user_id"]
  if !unOk || !passOk || !fnOk || !lnOk || !roleOk {
    SendErr(client, "Not all credentials inputted", "03007")
    return false
  }
  roleI, err := strconv.Atoi(roleS)
  if err != nil {
    SendErr(client, "Role not number!", "03008")
    return false
  }
  role := int64(roleI)
  var user User
  if uidOk {
    uid, err := strconv.Atoi(uidS)
    if err != nil {
      SendErr(client, "User ID not number!", "03009")
      return false
    }
    db.First(&user, uid)
    if user.Id == 0 {
      SendErr(client, "User ID not found", "03006")
      return false
    }
    err = bcrypt.CompareHashAndPassword([]byte(user.PasswordDigest), []byte(password))
    if err != nil {
      SendErr(client, "username/password wrong", "03003")
      return false
    }
  }
  if !newOk {
    newPass = password
  }
  passwordDigest, err := bcrypt.GenerateFromPassword([]byte(newPass), 4)
  if err != nil {
    log.Println(err)
    SendErr(client, "Password hash error", "3010")
    return false
  }
  user.PasswordDigest = string(passwordDigest)
  user.Username = username
  user.FirstName = firstName
  user.LastName = lastName
  user.Role = role //ADMN-0 MNGR/ACCT-1 WRHS-2 CSHR-3
  db.Save(&user)
  SendMessage(client, "success", make(map[string]string))
  return true
}

func deleteUser(params map[string]string, client *Client) bool {
  userId, uIdOk := params["user_id"]
  password, passOk := params["password"]
  if !uIdOk || !passOk {
    SendErr(client, "Not all credentials inputted", "03007")
    return false
  }
  uid, err := strconv.Atoi(userId)
  if err != nil {
    SendErr(client, "User ID must be number", "03005")
    return false
  }
  var user User
  db.First(&user, uid)
  err = bcrypt.CompareHashAndPassword([]byte(user.PasswordDigest), []byte(password))
  if err != nil {
    SendErr(client, "username/password wrong", "03003")
    return false
  }
  db.Delete(&user)
  SendMessage(client, "success", make(map[string]string))
  return true
}

func backupSystem(params map[string]string, client *Client) bool {
  //BACKUP
  return true
}

func restoreSystem(params map[string]string, client *Client) bool {
  //RESTORE
  return true
}
