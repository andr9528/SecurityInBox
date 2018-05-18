from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from DeviceDeclarative import Device, Base
import sys

engine = create_engine('mysql+pymysql://root:1ziggycat@localhost:3306/testingformachinelearning')
Base.metadata.bind = engine

DBSession = sessionmaker(bind=engine)
session = DBSession()

new_device = Device(MACAddress=sys.argv[1], IPAddress=sys.argv[2], Name=sys.argv[3])
session.add(new_device)
session.commit()