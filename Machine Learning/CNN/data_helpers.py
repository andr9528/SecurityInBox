import numpy as np
import os

def load_data():
	positive_examples = list()
	for filename in os.listdir('./data/positive/'):
		print("Loading file: ./data/positive/"+ filename)
		file = list(open('./data/positive/' + filename).readlines())
		positive_examples = positive_examples + file
		print("done\n")
 
	negative_examples = list()
	for filename in os.listdir('./data/negative/'):
		print("Loading file: ./data/negative/"+ filename)
		file = list(open('./data/negative/' + filename).readlines())
		negative_examples = negative_examples + file
		print("done\n")
		
	return [positive_examples, negative_examples]

def load_data_and_labels():
	positive_examples, negative_examples = load_data()
	
	# Formatting
	print("Merge Lists")
	x_text = positive_examples + negative_examples	
	
	print("Split by ;")
	x_text = [s.split(";") for s in x_text]
	
	print("Split by : and remove label")
	x_text = [[s.split(':')[-1] for s in t] for t in x_text]
	
	print("Remove space paddings")
	x_text = [[s.strip() for s in t] for t in x_text]
	
	#print("Convert to Numbers")
	#x_text = [[make_numbers(s) for s in t] for t in x_text]
	
	print("Generate Labels")
	positive_labels = [[1] for _ in positive_examples]
	negative_labels = [[0] for _ in negative_examples]
	y = np.concatenate([positive_labels, negative_labels], 0)
	
	return[x_text, y]
	
def make_numbers(string):
	result = list()
	for x in string:
		x = ord(x)
		x = bin(x)[2:] # remove the 0b label
		#x = str(x)
		result.append(x)
		
	return ''.join(result)

	
def get_data():
	x, y = load_data_and_labels()
	data = np.array(x, dtype="bytes")	
	labels = np.array(y)
	
	return [data, labels]