import sys
sys.path.insert(0, 'Users\Matt\Documents\Github\SecurityInBox\Machine Learning\Matt\DevicesMySQL')
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from DeviceDeclarative import Device, Base

engine = create_engine('mysql+pymysql://root:1ziggycat@localhost:3306/testingformachinelearning')
Base.metadata.bind = engine

DBSession = sessionmaker(bind=engine)
session = DBSession()

new_device = Device(MACAddress='00098c006964', IPAddress='192.168.0.1', Name='PC1')
session.add(new_device)
session.commit()