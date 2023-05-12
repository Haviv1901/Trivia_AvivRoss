import socket
import json

# consts
IP = "127.0.0.1"
PORT = 6969

LOGIN_CODE = 1
SIGN_UP_CODE = 2

def main():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_msg = ""

    sock = connect_to_server()
    data = {
        "username": "aviv",
        "password": "aviv123",
        "email": "ross@gmail.com"
    }
    bytes_code = bytes(str(SIGN_UP_CODE).encode())
    bytes_data = bytes(json.dumps(data).encode())
    length = len(bytes_data)
    encoded_length = length.to_bytes(4, 'big')
    full_msg_bytes = bytes_code + encoded_length + bytes_data
    #my_bytes = bytearray(full_msg_bytes)

    print("Connected to server.")
    send_msg_to_server(sock, bytes_code)
    send_msg_to_server(sock, encoded_length)
    send_msg_to_server(sock, bytes_data)
    #send_msg_to_server(sock, full_msg_bytes)
    while(True):
        print(sock.recv(4048).decode())
        continue
    sock.close()



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
            client_soc.send(data)
    except Exception:
        print("Could not sent msg to server.")
    else:
        print("message sent successfully.")

def recv_message(soc):
    """
    recv a message from the server.
    soc: socket to recv from.
    rtype: string
    return: string containing the message from the server.
    """
    try:
        recv = soc.recv(4048).decode()
    except Exception:
        print("Could not recv msg from server.")
        return ""
    else:
        return recv

if __name__ == '__main__':
    main()

