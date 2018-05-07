import socket, sys
from struct import *

#create an INET, STREAMing socket
try:
    s = socket.socket(socket.AF_INET, socket.SOCK_RAW, socket.IPPROTO_IP)
    s.bind(("10.140.68.31", 0))
    s.setsockopt(socket.IPPROTO_IP, socket.IP_HDRINCL, 1)
    s.ioctl(socket.SIO_RCVALL, socket.RCVALL_ON)
except socket.error , msg:
    print 'Socket could not be created.\n\rError Code : ' + str(msg[0]) + '\n\rMessage: ' + msg[1]
    sys.exit()

# receive a packet
while True:
    packet = s.recvfrom(65565)

    #packet string from tuple
    packet = packet[0]

    #take first 20 characters for the ip header
    ip_header = packet[0:20]

    #now unpack them :)
    iph = unpack('!BBHHHBBH4s4s' , ip_header)

    version_ihl = iph[0]
    version = version_ihl >> 4
    ihl = version_ihl & 0xF

    iph_length = ihl * 4

    ttl = iph[5]
    protocol = iph[6]
    s_addr = socket.inet_ntoa(iph[8]);
    d_addr = socket.inet_ntoa(iph[9]);

    tcp_header = packet[iph_length:iph_length+20]

    #now unpack them :)
    if len(tcp_header) >= 20:
     tcph = unpack('!HHLLBBHHH' , tcp_header)

     source_port = tcph[0]
     dest_port = tcph[1]
     sequence = tcph[2]
     acknowledgement = tcph[3]
     doff_reserved = tcph[4]
     tcph_length = doff_reserved >> 4

     h_size = iph_length + tcph_length * 4
     data_size = len(packet) - h_size

     #get data from the packet
     data = packet[h_size:]

     print 'Version: ' + str(version) + '; IP Header Length: ' + str(ihl) + '; TTL: ' + str(ttl) + '; Protocol: ' + str(protocol) + '; Source Address: ' + str(s_addr) + '; Destination Address: ' + str(d_addr)
     print 'Source Port: ' + str(source_port) + '; Dest Port: ' + str(dest_port) + '; Sequence Number: ' + str(sequence) + '; Acknowledgement: ' + str(acknowledgement) + '; TCP header length: ' + str(tcph_length)
     print 'Data:'
     print data
     print 

