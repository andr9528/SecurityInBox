import MySQLdb

db = MySQLdb.connect(host = "localhost",
                     user = "SIB_User",
                     passwd = "wiv84xNx0NmjGaSO",
                     db = "SIB")

cur = db.cursor()

cur.execute("SELECT * FROM Devices")

for row in cur.fetchall():
    print row[0]
