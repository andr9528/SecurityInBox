<?php

class Error {
	function __construct($Code, $msg) {
		switch($Code):
			case 422:
				err422($msg);
	}
	
	function err422($msg) {
		
	}
}

?>