import pymysql.cursors
import pymysql
   
cnx = mysql.connector.connect(user='SIB_User', password='wiv84xNx0NmjGaSO',
                              host='10.217.16.154',
                              database='SIB')

try:
    with connection.cursor() as cursor:
        # Create a new record
        sql = "SELECT * FROM `Devices`"

    with connection.cursor() as cursor:
        # Read a single record
        sql = "SELECT `id`, `password` FROM `users` WHERE `email`=%s"
        cursor.execute(sql, ('webmaster@python.org',))
        result = cursor.fetchone()
        print(result)
finally:
    connection.close()
