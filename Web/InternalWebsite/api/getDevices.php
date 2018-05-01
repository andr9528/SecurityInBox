<?php
	require("../core.php");
		
	$DB->query("SELECT MAC_Address, CurIP, Hostname, Displayname, Status, LastSeen FROM Devices");
	
	$Result = $DB->to_array();
	
	header('Content-Type: application/json');
	$json = json_encode($Result);
	echo $json;
?>