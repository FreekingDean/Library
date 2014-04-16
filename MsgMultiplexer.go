package main

import (
  "fmt"
  "crypto/tls"
  "encoding/json"
  "code.google.com/p/go.crypto/bcrypt"
)

var authed bool = false

type TlsMsg struct {
  cmd string
  params map[string]string
}

func multiRec(client *Client, msg string) {
  var recMsg TlsMsg
  err := json.Unmarshal([]byte(msg), &recMsg)
  if err != nil {
    fmt.Println(err)
    return
  }

  if authed {
    switch(recMsg.cmd) {
      case "front_counter": RecFC(recMsg.params["cmd"], recMsg.params, client); break
      case "materials": RecMat(recMsg.params["cmd"], recMsg.params, client); break
      case "accounting": RecAcc(recMsg.params["cmd"], recMsg.params, client); break
      case "admin": RecAdmin(recMsg.params["cmd"], recMsg.params, client); break
      default: SendErr(client, "No command/commmand not recognized", "no_cmd")
    }
  } else { //if not authed
    if recMsg.cmd == "login" {
      RecAdmin("login", params, client)
      if authed, ok := RecAdmin("login", params, client).(bool); ok && authed {
        client.Authed = true
        SendMessage(client, "logged_in", nil)
      } else { //if client returned false or other var
        SendErr(client, "Password or Username incorrect", "auth")
      }
    } else { //if command != "login"
      SendErr(client, "Please authenticate first", "auth")
  }
}

func SendMessage(client *Client, command string, prms map[string]string) {
  msg := &TlsMsg{
    cmd: command,
    params: prms,
  }
  message, err := json.Marshal(errorMsg)
  if err != nil {
    fmt.Println(err)
    return
  }
  client.SendMsg(string(message))
}

func SendErr(client *Client, msg string, code string) {
  errorMsg := &TlsMsg{
    cmd: "error",
  }
  errorMsg.params = make(map[string]string)
  errorMsg.params["msg"] = msg
  errorMsg.params["code"] = code
  message, err := json.Marshal(errorMsg)
  if err != nil {
    fmt.Println(err)
    return
  }
  client.SendMsg(string(message))
}

/* NOT NEEDED WHY DID I DO THIS???
func (client *Client) authUser(userName, password string) {
  params := make(map[string]string)
  params["user_name"] = userName
  params["password"] = password
  if authed, ok := RecAdmin("login", params, client).(bool); ok && authed {
    client.Authed = true
    SendMessage(client, "logged_in", nil)
  } else {
    SendErr(client, "Password or Username incorrect", "auth")
  }
}
*/
