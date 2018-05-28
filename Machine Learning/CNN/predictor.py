import sys
import subprocess

python2_command = 'C:\Python27\python.exe sniffer2.py'
process = subprocess.Popen(python2_command.split(), stdout=subprocess.PIPE)
output, error = process.communicate()

print(output)