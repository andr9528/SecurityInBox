import os
import sys
from sqlalchemy import Column, ForeignKey, Integer, String
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship
from sqlalchemy import create_engine

Base = declarative_base()


class Device(Base):
    __tablename__= 'devices'
    MACAddress = Column(String(250), primary_key=True)
    IPAddress = Column(String(250))
    Name = Column(String(250))


engine = create_engine('mysql+pymysql://root:1ziggycat@localhost:3306/testingformachinelearning')

Base.metadata.create_all(engine)