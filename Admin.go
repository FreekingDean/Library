package main

import(
  "log"
)

func RecAdmin(cmd string, params map[string]string, client *Client) {}interface... {
  switch(cmd) {
    case: "log_in" { return logIn(params, client) }
    case: "modify_user" { return modifyUser(params, client) }
    case: "delete_user" { return deleteUser(params, client) }
    case: "backup_system" { return backupSystem(params, client) }
    case: "restore_system" {return restoreSystem(params, client) }
    default: SendErr(client, "No command/commmand not recognized", "admin_cmd")
  }
  return nil
}

func login(params map[string]string, client *Client) {
}
