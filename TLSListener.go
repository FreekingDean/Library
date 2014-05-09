package main

import (
	"flag"
	"net"
	"fmt"
	//"github.com/FreekingDean/gotWrap"
)

//var s *gotWrap.Server
var connections map[string]*Client

type Client struct {
  Conn net.Conn
  Authed bool
}

func main() {
	addr := flag.String("addr", "", "Listening address")
	port := flag.String("port", "8000", "Listening port")
	//protocol := flag.String("protocol", "tcp", "Listening protocol")
	//pem := flag.String("pem", "certs/server.pem", "Cert pem file")
	//key := flag.String("key", "certs/server.key", "Cert key file")
	flag.Parse()

  connections = make(map[string]*Client)
	/*s = &gotWrap.Server {
		Protocol: *protocol,
		ListenerAddr: *addr+":"+*port,
		PemFile: *pem,
		KeyFile: *key,
		MessageRec: recMsg,
	}
	s.CreateServer()*/
	listener, err := net.Listen("tcp", *addr+":"+*port)
	if err != nil {
		println("Error accept:", err.Error())
		return
	}
	fmt.Println("STARTING LIBRARY SYSTEM")
	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accept:", err.Error())
			return
		}
		go EchoFunc(conn)
	}
}

func EchoFunc(conn net.Conn) {
  for {
	buf := make([]byte, 1024)
	n, err := conn.Read(buf)
	if err != nil {
		fmt.Println("Error reading:", err.Error())
		return
	}
	recMsg(conn, string(buf[:n]))
  }
}

func recMsg(netCon net.Conn, msg string) {
  if _, ok := connections[netCon.RemoteAddr().String()]; !ok {
    connections[netCon.RemoteAddr().String()] = &Client{
      Conn: netCon,
      Authed: false,
    }
  }
	fmt.Println(msg)
  multiRec(connections[netCon.RemoteAddr().String()], msg)
}

func (client *Client) SendMsg(msg string) {
  client.Conn.Write([]byte(msg+"\n"))
}
