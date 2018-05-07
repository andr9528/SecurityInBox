

function getDevices()
{
    var devices = httpGet("/internal/api/getDevices.php");
    console.log(devices);
    var devicesData = "";
    var deviceIndex;
    
    for(deviceIndex in devices)
        {
            var dataIndex;
            var device = devices[deviceIndex];
            var deviceData = ""; 
            
            
            deviceData+= "<td>" + device["Hostname"] + "</td>";
            
            deviceData+="<td>"+device["CurIP"]+"</td>";
            
            if(device["Status"] == "1")
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


function httpGet(theUrl)
{
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "GET", theUrl, false ); // false for synchronous request
    xmlHttp.send( null );
    return JSON.parse(xmlHttp.responseText);
}

function checkNewDevice()
{
    var devices = httpGet("/internal/api/getDevices.php");
    console.log(devices);
    var devicesData = "";
    var deviceIndex;
    
    for(deviceIndex in devices)
        {
            var dataIndex;
            var device = devices[deviceIndex];
            var deviceData = "";
            
            if(device["Status"] == "")
                {
                    
                     $(".popup").show();
                }
    
        }
            
            
    setTimeout(checkNewDevice, 1000)
    
    
}

checkNewDevice();


