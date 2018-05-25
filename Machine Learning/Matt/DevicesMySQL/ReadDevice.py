from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from DeviceDeclarative import Device, Base
import sys

engine = create_engine('mysql+pymysql://root:1ziggycat@localhost:3306/testingformachinelearning')
Base.metadata.bind = engine

DBSession = sessionmaker(bind=engine)
session = DBSession()

device = session.query(Device).filter_by(MACAddress=sys.argv[1]).first()
session.commit()

print(device.MACAddress)