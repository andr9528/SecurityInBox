<?php
	require("../core.php");
	
	$AccessCode = $_REQUEST['code'];
	
	$DB->Query("SELECT AccessCode FROM Settings");
	
	list($Code) = $DB->next_record();

	header('Content-Type: application/json');
	
	if($AccessCode === $Code) {
		echo "true";
	} else echo "false";
?>