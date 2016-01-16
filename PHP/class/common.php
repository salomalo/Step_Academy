<?php 

function p($x){
	if(is_array($x) || is_object($x)){
            $x = print_r($x, true);
            $x = "<pre>$x</pre>";
        }
	print "<div>{$x}</div>\n";
}

function pa($arr){
    p('[' . implode(' , ', $arr) . ']');
}

function pk($arr){
    $r = [];
    foreach($arr as $k => $v){
        $r[] = "{$k}=>{$v}";
    }
    p('[' . implode(' , ', $r) . ']');
}

function vd($x){
    print "<pre>";
    var_dump($x);
    print "</pre>";
}


function html_table($data, $style=''){
	if(empty($data)){
		return null;
	}
	$row1 = $data[0];
	$keys = array_keys(is_array($row1) ? $row1 : get_object_vars($row1));
	
	 $valFunc = function($obj, $field){
		if(is_object($obj)) return $obj->{$field};
		elseif(is_array($obj)) return $obj[$field];
		return null;
	};
	
	$tabStyle = "";
	$tdStyle = "";
	if(is_string($style)){
		$tabStyle = $style;
		$tdStyle = $style;
	} else {
		if(isset($style['table']))
			$tabStyle = $style['table'];
		if(isset($style['td']))
			$tdStyle = $style['td'];
	}
	$tabStyle = "style=\"".$tabStyle."\"";
	$tdStyle = "style=\"".$tdStyle."\"";
	
	$html = "<table $tabStyle>\n";
	$html .= "<tr>\n";
	foreach($keys as $key){
		$html .= "<th>$key</th>\n";
	}
	$html .= "</tr>\n";
	
	foreach($data as $i => $unit){
		$html .= "<tr>\n";
		foreach($keys as $key){
			$val = $valFunc($unit, $key);
			$html .= "<td $tdStyle>{$val}</td>\n";
		}
		$html .= "</tr>\n";
	}
	
	$html .= "</table>";
	return $html;
}
