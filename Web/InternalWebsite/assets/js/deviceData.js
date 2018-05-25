var currentDevice;
var devices;

function httpGet(theUrl)
{
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "GET", theUrl, false ); // false for synchronous request
    xmlHttp.send( null );
    return JSON.parse(xmlHttp.responseText);
}

//This function calls the checkDevices() function each second, to see if a new device has been added -- it also calls the checkNewDevice() function to check if a device has been added to the table and display it
function updateDeviceList()
{
    devices = httpGet("/internal/api/getDevices.php");
    
    checkNewDevice();
    getDevices();
    
    
    setTimeout(updateDeviceList, 1000);
}

$(document).ready(function(){
    updateDeviceList();
});

//This function loops through the devices array and and shows the data I want in the html table, it checks if status i 1 or 2 and posts it as a word "Approved" or "Blocked"
function getDevices() 
{
    var devicesData = "";
    var deviceIndex;
    
    var tableRows = "";
    for(deviceIndex in devices)
        {
            var dataIndex;
            var device = devices[deviceIndex];
            var deviceData = ""; 
            
            
            deviceData+= "<td>" + device["Hostname"] + "</td>";
            
            deviceData+="<td>" + device["Displayname"] +"</td>";
            
            deviceData+="<td>"+device["CurIP"]+"</td>";
            
            if(device["Status"] == "1")
                      {
	                      deviceData += "<td>Approved</td>";
                      }
                      else if(device["Status"]== "2")
                      {
	                    deviceData += "<td>Blocked</td>";
                      }
                      else
                      {
                          deviceData+="<td>Awaiting response</td>";
                      }
            
            
            deviceData += "<td> &nbsp; <i id = 'trashIcon' onClick='deleteDevice(\'"+ device['MAC_Address'] +"\');' class='fas fa-trash '></i> &nbsp; &nbsp; <i id = 'editIcon' class='fas fa-edit'></i> </td>";
            
            tableRows += "<tr>" + deviceData+ "</tr>";

        }
    
    tableRows = "<tr><th>Host Name</th><th>Device Name</th><th>IP Address</th><th>Status</th><th>Device Settings</th></tr>" + tableRows;
    document.getElementById("table").innerHTML = tableRows;
}

function deleteDevice(MAC_Address)
{
    $.post("api/setDeviceStatus.php", { mac: currentDevice['MAC_Address']).done(function(data) {
		if(data=="200 OK")
            {
               $(".popup").hide(); 
            }
	});
}

//This function loops through the devices array and it checks if the status of device is null then notification appears which displays the data of the device with status=null,if device wont have any ip, the ip won't be shown in the notification window
function checkNewDevice()
{
    //console.log(devices);
    var devicesData = "";
    var deviceIndex;
    
    for(deviceIndex in devices)
        {
            var dataIndex;
            var device = devices[deviceIndex];
            var deviceData = "";
            
            if(device["Status"] == "")
                {
                    //this line sets the device in the notification to the current device which will later be used to approve or block the device
                    currentDevice = device;
                    
                     $(".popup").show();
                    
                    deviceNotificationInfo = "Device Name: " + device["Hostname"]+ "<br/>";
                    
                    if(device["CurIP"] != "")
                        {
                            deviceNotificationInfo+= "IP Address: " + device["CurIP"] + "<br/>";
                        }
                    
                    deviceNotificationInfo+= "Date: " + device["FirstSeen"];
                    
                    $('#deviceDataNotification').html(deviceNotificationInfo);                   
 
                }
        }           
}

//This function sends a post request to the API Endpoint and sets the device status in the database as approved 1, if the request was succesfull the notification will dissapear 
function approveClick()
{
    $.post("api/setDeviceStatus.php", { mac: currentDevice['MAC_Address'], status: "1" } ).done(function(data) {
		if(data=="200 OK")
            {
               $(".popup").hide(); 
            }
	});
}

//this function does the same as the one above but this time it sets the status in the database as blocked 2
function blockClick()
{
    $.post("api/setDeviceStatus.php", { mac: currentDevice['MAC_Address'], status: "2" } ).done(function(data) {
		if(data=="200 OK")
            {
               $(".popup").hide(); 
            }
	});
}