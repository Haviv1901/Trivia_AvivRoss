import socket

# consts
IP = "127.0.0.1"
PORT = 6969


def main():
    print(IP)
    print(PORT)


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
    else:
        server_msg = (sock.recv(1024).decode())  # print welcome msg
        print("Connected to server.")
        print("Server sent: " + server_msg)
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

