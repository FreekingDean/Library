package main

import (
	"flag"
	"crypto/tls"
	"github.com/FreekingDean/gotWrap"
  "fmt"
)

var s *gotWrap.Server
var connections map[string]*Client

type Client struct {
  Conn *tls.Conn
  Authed bool
}

func main() {
	addr := flag.String("addr", "", "Listening address")
	port := flag.String("port", "8000", "Listening port")
	protocol := flag.String("protocol", "tcp", "Listening protocol")
	pem := flag.String("pem", "certs/server.pem", "Cert pem file")
	key := flag.String("key", "certs/server.key", "Cert key file")
	flag.Parse()

  connections = make(map[string]*tls.Conn)
	s = &gotWrap.Server {
		Protocol: *protocol,
		ListenerAddr: *addr+":"+*port,
		PemFile: *pem,
		KeyFile: *key,
		MessageRec: recMsg,
	}
	s.CreateServer()
}

func recMsg(tlscon *tls.Conn, msg string) {
  if val, ok := connections[tlscon.RemoteAddr().String()]; !ok {
    connections[tlscon.RemoteAddr().String()] = &Client{
      Conn: tlscon,
      Authed: false,
    }
  }
  multiRec(msg, connections[tlscon.RemoteAddr().String()])
}

func (client *Client) SendMsg(msg string) {
  gotWrap.SendMessage(client.Conn, []byte(msg))
}