from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from DeviceDeclarative import Device, Base

engine = create_engine('mysql+pymysql://root:1ziggycat@localhost:3306/testingformachinelearning')
Base.metadata.bind = engine

DBSession = sessionmaker(bind=engine)
session = DBSession()

devices = session.query(Device).all()
session.commit()

for device in devices:
    print(device.MACAddress)