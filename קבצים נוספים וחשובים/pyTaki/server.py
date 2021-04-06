import json
import socket
import time

HOST = '127.0.0.1'  # Standard loopback interface address (localhost)
PORT = 33666  # Port to listen on (non-privileged ports are > 1023)


def send(sock, id, dict={}):
    send_from = 0
    string_dic = ""
    if dict is not {}:
        string_dic = json.dumps(dict)
    id = int(id).to_bytes(1, byteorder='big')
    message = id + len(string_dic).to_bytes(4, byteorder='little') + string_dic.encode("ASCII")
    while send_from < len(message):
        send_from += sock.send(message[send_from:])


def recv(sock):
    id = sock.recv(1)
    length = int.from_bytes(sock.recv(4), byteorder='little')
    message = ""
    while len(message) < length:
        message += (sock.recv(length)).decode("ASCII")
    message = json.loads(message)
    retArr = [id, message]
    return retArr


card = {
    "card": "4g",
    "direction": 1,
    "index": 1
}

calling = {
    "status": 1
}

err = {
    "message": "bla bla"
}

roomsData = {
    "status": 2,
    "rooms": [
        {
            "id": 1,
            "name": "meme",
            "maxPlayers": 4,
            "isActive": 0
        },
        {
            "id": 1,
            "name": "lama",
            "maxPlayers": 2,
            "isActive": 1
        }
    ]
}

startGame = {
    "player_names": ["gilad", " tomer", " ariel"],
    "turns": [3, 1, 2],
    "cardsDeck": ["3b", "4g"],
    "centralCard": "3y"
}

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    conn, addr = s.accept()
    with conn:
        print('Connected by', addr)
        while True:
            # data = conn.recv(1024)
            # send(conn, 0x44, calling)
            data = recv(conn)
            # print(data[0], "\t==>\t", data[1])
            # yo = json.loads(data[1])
            # print(yo["index"])
            # send(conn, data)
            # if data[0] == b'E':
            #    send(conn, 0x43, cardDic)
            if data[0] == b'\x10':
                send(conn, 0x12, calling)
            elif data[0] == b'\x11':
                send(conn, 0x13, calling)
            elif data[0] == b'\x24':
                send(conn, 0x24, roomsData)
            elif data[0] == b'\x21':
                print("room id: ", data[1]['roomId'])
                send(conn, 0x28, roomsData)
                time.sleep(3)
                send(conn, 0x40, startGame)
            elif data[0] == b'\x41':
                card["card"] = data["card"]
                card["direction"] = -1
                send(conn, 0x42, card)
