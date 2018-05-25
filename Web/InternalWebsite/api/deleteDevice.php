<?php
	require("../core.php");
	
	$MAC = isset($_REQUEST['mac']) ? $DB->escape_str($_REQUEST["mac"]) : "";
	
	if(empty($MAC)) {
		header("HTTP/1.1 422 Unprocessable Entity");
		die("422 Unprocessable Entity: mac Parameter Invalid.");
	}
	
	$DB->query("DETELE FROM Devices WHERE MAC_Address = '{$MAC}'");
	
	header("HTTP/1.1 200 OK");
	echo "200 OK";
	exit(0);
?>