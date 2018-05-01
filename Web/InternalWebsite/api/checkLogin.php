<?php
	require("../core.php");
	checkAPIKey();
	
	$AccessCode = $_REQUEST['code'];
	
	if(empty($AccessCode)) {
		header("HTTP/1.1 422 Unprocessable Entity");
		die("422 Unprocessable Entity: code Parameter Invalid.");
	}
	
	$DB->Query("SELECT AccessCode FROM Settings");
	
	list($Code) = $DB->next_record();

	header('Content-Type: application/json');
	
	if($AccessCode === $Code) {
		echo "true";
	} else echo "false";
?>