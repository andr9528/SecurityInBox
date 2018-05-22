import numpy as np
import os
import base64

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

        print("Convert IP to Decimal")
        for e in x_text:
                e[4] = IPToDec(e[4])
                e[5] = IPToDec(e[5])

        print("Convert Data to Decimals")
        for e in x_text:
                e[11] = str(make_number(e[11]))

        print("Make pretty numbers!")
        x_text = [[int(s) for s in t] for t in x_text]
                
        
        #print("Convert to Numbers")
        #x_text = [[make_numbers(s) for s in t] for t in x_text]
        
        print("Generate Labels")
        positive_labels = [[1] for _ in positive_examples]
        negative_labels = [[0] for _ in negative_examples]
        y = np.concatenate([positive_labels, negative_labels], 0)
        print("Done")
        return[x_text, y]
        
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

        
def get_data():
        x, y = load_data_and_labels()
        data = np.array(x, dtype="float")      
        labels = np.array(y)
        
        return [data, labels]

def test_writelist(x):
        for y in x:
                print(y)
