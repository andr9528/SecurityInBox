from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from DeviceDeclarative import Device, Base
import sys

engine = create_engine('mysql+pymysql://root:1ziggycat@localhost:3306/testingformachinelearning')
Base.metadata.bind = engine

DBSession = sessionmaker(bind=engine)
session = DBSession()

device_to_delete = session.query(Device).filter_by(MACAddress='00098c006964').first()
session.delete(device_to_delete)
session.commit()