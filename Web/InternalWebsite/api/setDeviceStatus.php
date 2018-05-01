<?php
	require("../core.php");
	checkAPIKey();
	//header('Content-Type: application/json');
	
	$MAC = isset($_REQUEST['mac']) ? $DB->escape_str($_REQUEST["mac"]) : "";
	$Status = isset($_REQUEST['status']) ? $_REQUEST["status"] : "";
	
	if(empty($MAC)) {
		header("HTTP/1.1 422 Unprocessable Entity");
		die("422 Unprocessable Entity: mac Parameter Invalid.");
	}
	
	if(!is_number($Status)) {
		header("HTTP/1.1 422 Unprocessable Entity");
		die("422 Unprocessable Entity: status Parameter Invalid.");
	}
	
	$DB->query("UPDATE Devices SET Approved = '{$Status}' WHERE MAC_Address = '{$MAC}'");
	
	header("HTTP/1.1 200 OK");
	echo "200 OK";
	exit(0);
?>