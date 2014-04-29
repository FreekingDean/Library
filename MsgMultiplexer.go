package main

import (
  "fmt"
  //"crypto/tls"
  "encoding/json"
  //"code.google.com/p/go.crypto/bcrypt"
)

func multiRec(client *Client, msg string) {
  fmt.Println("[MsgMulti]: checking msg")
  var params map[string]string
  err := json.Unmarshal([]byte(msg), &params)
  if err != nil {
    fmt.Println(err)
    return
  }

  if client.Authed {
    switch(params["top_cmd"]) {
      case "front_counter": RecFC(params["cmd"], params, client); break
      case "materials": RecMat(params["cmd"], params, client); break
      case "accounting": RecAcc(params["cmd"], params, client); break
      case "admin": RecAdmin(params["cmd"], params, client); break
      default: SendErr(client, "No command/commmand not recognized", "no_cmd")
    }
  } else { //if not authed
    if params["top_cmd"] == "login" {
      authed := RecAdmin("login", params, client)
      if authed {
        client.Authed = true
      }
    } else { //if command != "login"
      SendErr(client, "Please authenticate first", "auth")
    }
  }
}

func SendMessage(client *Client, command string, prms map[string]string) {
prms["top_cmd"] = command
message, err := json.Marshal(prms)
  if err != nil {
    fmt.Println(err)
    return
  }
  client.SendMsg(string(message))
}

func SendErr(client *Client, msg string, code string) {
params := make(map[string]string)
params["top_cmd"] = "error"
 params["msg"] = msg
  params["code"] = code
  message, err := json.Marshal(params)
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
