<?php

require_once("classes/mysql.php");

$DB = new DB_MYSQL("SIB", "SIB_User", "wiv84xNx0NmjGaSO", "localhost", "3306", "");
$DB->connect();

function display_array($Array, $Escape = array()) {
    foreach ($Array as $Key => $Val) {
        if ((!is_array($Escape) && $Escape == true) || !in_array($Key, $Escape)) {
            $Array[$Key] = display_str($Val);
        }
    }
    return $Array;
}

function display_str($Str) {
    if ($Str === NULL || $Str === FALSE || is_array($Str)) {
        return '';
    }
    if ($Str != '' && !is_number($Str)) {
        $Str = make_utf8($Str);
        $Str = mb_convert_encoding($Str, "HTML-ENTITIES", "UTF-8");
        $Str = preg_replace("/&(?![A-Za-z]{0,4}\w{2,3};|#[0-9]{2,5};)/m", "&amp;", $Str);

        $Replace = array(
            "'", '"', "<", ">",
            '&#128;', '&#130;', '&#131;', '&#132;', '&#133;', '&#134;', '&#135;', '&#136;', '&#137;', '&#138;', '&#139;', '&#140;', '&#142;', '&#145;', '&#146;', '&#147;', '&#148;', '&#149;', '&#150;', '&#151;', '&#152;', '&#153;', '&#154;', '&#155;', '&#156;', '&#158;', '&#159;'
        );

        $With = array(
            '&#39;', '&quot;', '&lt;', '&gt;',
            '&#8364;', '&#8218;', '&#402;', '&#8222;', '&#8230;', '&#8224;', '&#8225;', '&#710;', '&#8240;', '&#352;', '&#8249;', '&#338;', '&#381;', '&#8216;', '&#8217;', '&#8220;', '&#8221;', '&#8226;', '&#8211;', '&#8212;', '&#732;', '&#8482;', '&#353;', '&#8250;', '&#339;', '&#382;', '&#376;'
        );

        $Str = str_replace($Replace, $With, $Str);
    }
    return $Str;
}

function is_number($Str) {
    $Return = true;
    if ($Str < 0) {
        $Return = false;
    }
    // We're converting input to a int, then string and comparing to original
    $Return = ($Str == strval(intval($Str)) ? true : false);
    return $Return;
}

function make_utf8($Str) {
    if ($Str != "") {
        if (is_utf8($Str)) {
            $Encoding = "UTF-8";
        }
        if (empty($Encoding)) {
            $Encoding = mb_detect_encoding($Str, 'UTF-8, ISO-8859-1');
        }
        if (empty($Encoding)) {
            $Encoding = "ISO-8859-1";
        }
        if ($Encoding == "UTF-8") {
            return $Str;
        } else {
            return @mb_convert_encoding($Str, "UTF-8", $Encoding);
        }
    }
}

function is_utf8($Str) {
    return preg_match('%^(?:
        [\x09\x0A\x0D\x20-\x7E]          // ASCII
        | [\xC2-\xDF][\x80-\xBF]            // non-overlong 2-byte
        | \xE0[\xA0-\xBF][\x80-\xBF]        // excluding overlongs
        | [\xE1-\xEC\xEE\xEF][\x80-\xBF]{2} // straight 3-byte
        | \xED[\x80-\x9F][\x80-\xBF]        // excluding surrogates
        | \xF0[\x90-\xBF][\x80-\xBF]{2}  // planes 1-3
        | [\xF1-\xF3][\x80-\xBF]{3}      // planes 4-15
        | \xF4[\x80-\x8F][\x80-\xBF]{2}  // plane 16
        )*$%xs', $Str
    );
}

function checkAPIKey() {
	global $DB;
	$Key = isset($_REQUEST['apikey']) ? $DB->escape_str($_REQUEST['apikey']) : "";
	
	$DB->query("SELECT Code FROM APIKey WHERE Code = '{$Key}'"); // Should be parameterized, but our mysqli wrapper does not support this.
	$Record = $DB->next_record();
	
	if($Record['Code'] == $Key) { // Can never do enough validation...
		return true;
	} else {
		header('HTTP/1.0 403 Forbidden');
		die("Could not validate API Key.");
	}
	
	die("Unknown Error Occurred.");
}
?>