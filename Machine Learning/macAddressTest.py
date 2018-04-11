import subprocess
import socket
import threading
import struct

p = subprocess.Popen('arp -a',stdout=subprocess.PIPE)
preprocessed = p.communicate()[0].decode('utf-8')
print(preprocessed)

test = []
devices = []
begin = 86
increment = 58

for i in range(0, int(len(preprocessed)/increment)):
    result = preprocessed[begin+(increment*i): begin+(increment*(i+1))]
    result2 = list(filter(None, result.split(' ')))
    try:
        #result2.remove('\r\n')
        #result2.remove('e\r\n')
        del result2[0] #
        try: # remove type
            result2.remove('dynamic')
        except:
            result2.remove('static')
    except:
        pass
    if result2 != []:
        test.append(result2)

def addName(i):
    #print(i)
    i.append(socket.getfqdn(i[0]))
    devices.append(i)


thread_list = []
for ip in test:
    # Instantiates the thread
    t = threading.Thread(target=addName, args=(ip,))
    # Sticks the thread in a list so that it remains accessible
    thread_list.append(t)

# Starts threads
for thread in thread_list:
    thread.start()

# This blocks the calling thread until the thread whose join() method is called is terminated.
# From http://docs.python.org/2/library/threading.html#thread-objects
for thread in thread_list:
    thread.join()


# sort by ip
devices = sorted(devices, key=lambda ip: struct.unpack("!L", socket.inet_aton(ip[0]))[0])

print()
print('Devices:')
for device in devices:
    print(device)

print()
print(devices)  # list of list, format: [[ip,mac,name],[....],....]

