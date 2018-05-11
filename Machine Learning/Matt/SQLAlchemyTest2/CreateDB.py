from sqlalchemy import Column, ForeignKey, Integer, String
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship
from sqlalchemy import create_engine
import sqlalchemy
# engine = sqlalchemy.create_engine('mysql+pymysql://website:kxAHMVTxi6Bg@securityinabox.tk:22')
# connection = pymysql.connect(host='10.217.16.154',
#                              user='Matt',
#                              password='XDHy9twawkHo8Hi4',
#                              db='Matt')

Base = declarative_base()


class Person(Base):
    __tablename__ = 'person'
    # Here we define columns for the table person
    # Notice that each column is also a normal Python instance attribute.
    id = Column(Integer, primary_key=True)
    name = Column(String(250), nullable=False)


class Address(Base):
    __tablename__ = 'address'
    # Here we define columns for the table address.
    # Notice that each column is also a normal Python instance attribute.
    id = Column(Integer, primary_key=True)
    street_name = Column(String(250))
    street_number = Column(String(250))
    post_code = Column(String(250), nullable=False)
    person_id = Column(Integer, ForeignKey('person.id'))
    person = relationship(Person)


engine = sqlalchemy.create_engine('mysql+pymysql://Matt:XDHy9twawkHo8Hi4@10.217.16.154/Matt')


Base.metadata.create_all(engine)
# engine = sqlalchemy.create_engine('mysql+pymysql://root:1ziggycat@localhost:3306')
# engine.execute("CREATE DATABASE Test2")
# engine.execute("USE dbname")
# try:
#     with connection.cursor() as cursor:
#         sql = """create database test1"""
#         cursor.execute(sql)
# finally:
#     connection.close()
# try:
#     with connection.cursor() as cursor:
#         # Create a new record
#         sql = """INSERT INTO cats (name, owner, birth) VALUES (%s, %s, %s)"""
#         cursor.execute(sql, ('ziggy', 'matt', '2009-05-05'))
#
#     # connection is not autocommit by default. So you must commit to save
#     # your changes.
#     connection.commit()
#
#     with connection.cursor() as cursor:
#         # Read a single record
#         sql = """SELECT id, name, birth FROM cats WHERE owner=%s"""
#         cursor.execute(sql, ('matt',))
#         result = cursor.fetchone()
#         print(result)
# finally:
#     connection.close()