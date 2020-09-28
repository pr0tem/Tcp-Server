import socket

port=##insert port here###

s=socket.socket()
s.connect(('127.0.0.1', port)) 

while(True):
	x = input()
	s.send(str.encode(x))
