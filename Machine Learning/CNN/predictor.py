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

print('Ready')

def make_number(string):
        result = 0
        if(len(string) == 0):
                return 0
        
        for x in string:
                x = ord(x)
                result = result + x
                
        return result

def IPToDec(ip):
        octs = ip.split('.')
        dec0 = int(octs[0]) * (256**3)
        dec1 = int(octs[1]) * (256**2)
        dec2 = int(octs[2]) * (256**1)
        dec3 = int(octs[3])
        return dec0+dec1+dec2+dec3

def convert(str):
	print(str)
	str = str.split(";")
	str = [s.split(':')[-1] for s in str]
	str = [s.strip() for s in str]     
	str[4] = IPToDec(str[4])
	str[5] = IPToDec(str[5])
	print(str)
	str[11] = str(make_number(str[11]))
	
	str = [int(s) for s in str]
	
	str[8] = 0
	str[9] = 0

	return str
	

def predict(str):
	x = convert(str)
	with graph.as_default():
		#perform the prediction
		out = model.predict(x)
		print(out)
		print(np.argmax(out,axis=1))
		print ("debug3")
		#convert the response to a string
		response = np.array_str(np.argmax(out,axis=1))
		return response	


#p = Popen('sniffer2.py', stdout = PIPE, stderr = STDOUT, shell = True)	
#while True:
#	line = p.stdout.readline()
#	prediction = predict(line[:-4].decode("utf8"))
#	if not line: break


