import socket
import json
import time

# consts
IP = "127.0.0.1"
PORT = 6969

LOGIN_CODE = 10
SIGN_UP_CODE = 12
MENU_CODE = 20
SIGNOUT_CODE = 21
GET_ROOMS_CODE = 22
GET_PLAYERS_INROOM_CODE = 23
GET_PERSONAL_STATS_CODE = 24
GET_HIGH_SCORE_CODE = 25
JOIN_ROOM_CODE = 26
CREATE_ROOM_CODE = 27

def main():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_msg = ""

    sock = connect_to_server()

    login("notAvivRoss", "S3cr3t@s", sock)
    get_high_score(sock)

    #sign_in("notAvivRoss", "S3cr3t@s", "ross@gmail.com", sock)
    # create_room(5, 5, 5, "nameroom1", sock)
    #login("Lidan", "Ror1234$", sock)
    #join_room(2, sock)
    #get_players_in_room(2, sock)

    #sign_out(sock)

    
    #sign_in("Lidan", "Ror1234$", "lidan@gmail.com")

    while(True):
        print("Ideal in socket.")
        time.sleep(5)

    sock.close()


def get_high_score(soc):
    data = {}
    send_message(GET_HIGH_SCORE_CODE, data, soc)
    code, len, x = parse_data(soc)
    print(x)


def get_players_in_room(room_id, soc):
    data = {
        "roomId" : room_id
    }
    send_message(GET_PLAYERS_INROOM_CODE, data, soc)
    code, len, x = parse_data(soc)
    print(x)


def sign_out(soc):
    data = {}
    send_message(SIGNOUT_CODE, data, soc)
    code, len, x = parse_data(soc)
    print(x)


def join_room(room_id, soc):
    data = {
        "roomId" : room_id
    }
    send_message(JOIN_ROOM_CODE, data, soc)
    code, len, x = parse_data(soc)
    print(x)


def create_room(time_out, max_users, question_count, name, soc):
    data = {
        "Answer Time Out" : time_out,
        "Max Users" : max_users,
        "Question Count" : question_count,
        "Room Name" : name
    }
    send_message(CREATE_ROOM_CODE, data, soc)
    code, len, x = parse_data(soc)
    print(x)
    return x["Room Id"]

def get_personal_stats(soc):
    data = {
    }
    send_message(GET_PERSONAL_STATS_CODE, data, soc)
    code, len, x = parse_data(soc)
    print(x)
    if x["status"] == 1:
        return True
    return False



def sign_in(username, password, email, soc):
    data = {
        "username": username,
        "password": password,
        "email": email
    }
    send_message(SIGN_UP_CODE, data, soc)
    code, len, x = parse_data(soc)
    print(x)
    if x["status"] == 1:
        return True
    return False


def login(username, password, soc):
    login = {
        "username": username,
        "password": password
    }
    send_message(LOGIN_CODE, login, soc)
    code, len, x = parse_data(soc)
    print(x)
    if x["status"] == 1:
        return True
    return False


def parse_data(soc):
    code = int.from_bytes(soc.recv(1), 'big')
    len = int.from_bytes(soc.recv(4), 'big')
    x = soc.recv(4096).decode()
    x = json.loads(x)
    return code, len, x


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


def send_message(code, data, soc):
    print("sending: " + str(data))
    bytes_code = int(code).to_bytes(1, 'big')
    bytes_data = bytes(json.dumps(data).encode())
    length = len(bytes_data)
    encoded_length = length.to_bytes(4, 'big')
    full_msg_bytes = bytes_code + encoded_length + bytes_data
    send_msg_to_server(soc, full_msg_bytes)

if __name__ == '__main__':
    main()

