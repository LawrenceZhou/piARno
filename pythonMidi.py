import mido, socket

UDP_IP = "172.20.10.5"
UDP_PORT = 12345

device_name = mido.get_input_names()
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

print(device_name)
if len(device_name) > 0:
	inport = mido.open_input(device_name[1])

	for msg in inport:   # msg.note, msg.velocity
		print(msg)
		if msg.type == "note_on":
			if (msg.note >= 48 and msg.note <= 72) and msg.velocity != 0:
				msgToSend = "K" + str(msg.note - 48).zfill(2) + "V1"
				sock.sendto(msgToSend, (UDP_IP, UDP_PORT))
				print "sent regular note " + msgToSend
			elif (msg.note < 48 or msg.note > 72) and msg.velocity != 0:
				msgToSend = "W" + str(msg.note - 48).zfill(2) + "V0"
				sock.sendto(str("-2"), (UDP_IP, UDP_PORT))
				print "sent wrong note signal " + + msgToSend
			elif msg.velocity == 0:
				msgToSend = "K" + str(msg.note - 48).zfill(2) + "V0"
				sock.sendto(msgToSend, (UDP_IP, UDP_PORT))
				print "sent noteOff message " + msgToSend






	
	
