
function getDevices()
{
    var devices = { Device1 : {deviceName: "Device1", IP: "127.0.0.1", status: "1"}, 
                    Device2 : {deviceName: "Device2", IP: "127.0.0.2", status: "0"}
                  };
    
    var devicesData = "";
    var deviceIndex;
    
    for(deviceIndex in devices)
        {
            var dataIndex;
            var device = devices[deviceIndex];
            var deviceData = ""; 
            
            
            deviceData+= "<td>" + device["deviceName"] + "</td>";
            
            deviceData+="<td>"+device["IP"]+"</td>";
            
            if(device["status"] == "1")
                      {
	                      deviceData += "<td>Approved</td>";
                      }
                      else 
                      {
	                    deviceData += "<td>Blocked</td>";
                      }
            
            
            
            devicesData += "<tr>" + deviceData+ "</tr>";
            
        }
    
    var currentContent = document.getElementById("table").innerHTML;
    document.getElementById("table").innerHTML = currentContent + devicesData;
    
    
}



getDevices();
