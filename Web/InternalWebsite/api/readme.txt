API Endpoints:

* REQUIRES API KEY

/api/getDevices.php
Returns all devices in JSON Format

/api/setDeviceStatus.php
2 Parameters (GET/POST) *
mac > MAC Address of Device
status > New Status Indicator (numeric)

/api/checkLogin.php
1 Parameter (GET/POST) *
code > Input from login box
Returns TRUE if "code" is the expected and FALSE if not.

Responses:
422 > Invalid Parameters
200 > OK
