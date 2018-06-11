import numpy as np
import keras.models
from keras.models import model_from_json
from scipy.misc import imread, imresize,imshow
import tensorflow as tf
import sys
from subprocess import Popen, PIPE, STDOUT
from load import * 

global model, graph
model, graph = init()

debug = False

print('Ready')

def make_number(string):
        if(debug): print("\n==Make String")
        result = 0
        
        if(debug): print("Length: " + str(len(string)))
        if(debug): input()
        
        if(len(string) == 0):
                return 0
       
        counter = 0
        for x in string:
                ++counter
                if(debug): print(counter)
                if(debug): print("Letter > " + x)
                y = ord(x)
                if(debug): print("Number >" + str(y))
                result = result + y
        
        if(debug): print("Result > " + str(result))
        return result

def IPToDec(ip):
        octs = ip.split('.')
        dec0 = int(octs[0]) * (256**3)
        dec1 = int(octs[1]) * (256**2)
        dec2 = int(octs[2]) * (256**1)
        dec3 = int(octs[3])
        return dec0+dec1+dec2+dec3

def convert(mystr):
    print(mystr)
    mystr = mystr.split(";")
    mystr = [s.split(':')[-1] for s in mystr]
    mystr = [s.strip() for s in mystr]     
    mystr[4] = IPToDec(mystr[4])
    mystr[5] = IPToDec(mystr[5])
    mystr[11] = make_number(mystr[11])
    
    mystr = [int(s) for s in mystr]
    
    mystr[8] = 0
    mystr[9] = 0

    return [mystr]
    

def predict(str):
    y = convert(str)
    data = np.array(y, dtype='int64') 
    
    if(debug): print(data)
    
    with graph.as_default():
        if(debug): print(data.shape)
        #perform the prediction
        out = model.predict(data)
        if(debug): print(out)
        if(debug): print(np.argmax(out,axis=1))
        if(debug): print ("==debug point==")
        #convert the response to a string
        response = np.array_str(np.argmax(out,axis=1))
        return response    


tstr = "Version: 4; IP Header Length: 5; TTL: 64; Protocol: 6; Source Address: 172.17.0.2; Destination Address: 172.17.0.1; Source Port: 22; Dest Port: 55190; Sequence Number: 4030215297; Acknowledgement: 4060907643; TCP header length: 8; Data: 5o/Xqg/6APXNsJiYPTfJsPecZuw5AmHqkXEV51KP29SKD4jTGS31vzv7KGaDsKjRRnwKmg=="
        
p = Popen('sniffer2.py', stdout = PIPE, stderr = STDOUT, shell = True)    
while True:
    line = p.stdout.readline()
    if not line: break
    if(debug): print(line)
    prepare = line[:-4].decode("utf8")
    if(debug): print(prepare)
    prediction = predict(prepare)
    
    print(prediction)

