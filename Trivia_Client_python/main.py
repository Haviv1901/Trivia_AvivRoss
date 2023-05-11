import socket
import json

# consts
IP = "127.0.0.1"
PORT = 6969


def main():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_msg = ""

    sock = connect_to_server()
    data = {
        "username": "aviv",
        "password": "aviv123"
    }
    bytes_code =
    bytes_data =  bytes(json.dumps(data))
    length = len(bytes_data)
    fullMsg =
    print("Connected to server.")
    print("Server sent: " + server_msg)
    if server_msg == "Hello":
        send_msg_to_server(sock, "Hello")



def connect_to_server():
    """
    connect to the server
    return: the socket
    rtype: socket.Socket
    """
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_address = (IP, PORT)
    try:
        sock.connect(server_address)
    except Exception:
        print("couldn't connect to server")
        print("Error: " + str(Exception))

    return sock


def send_msg_to_server(client_soc, data):
    """
    sends msg to server
    client_soc: the socket to send msgs to
    msg: the msg to send to
    return: -
    rtype: -
    """
    try:
        client_soc.sendall(data.encode())
    except Exception:
        print("Could not not sent msg to server.")


if __name__ == '__main__':
    main()

