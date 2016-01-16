<?php

/* https://myphpsite.com/createarr.php  */

if(isset($_GET['name'])){
	$name = $_GET['name'];
	$age = $_GET['age'];
	$gender = $_GET['gender'];
	
	print "<div>name = {$name}</div> 
	<div>age = {$age}</div>";
	

	//showuser($name,$age,$gender);
	
		
	unset($_GET['name']);
}

showuser('name', 'age', 'gender');
function showuser($name, $age, $gender) {	
	$row=10;
	$col=3;
	
	/* $color=99996;  */  
	print "<table>\n";      
        for ($i = 0; $i < $row; $i++) {       
	print"<tr>\n";
        
        for ($j = 0; $j < $col; $j++) {  
            print "<td>$name</td>";          
        }	       
        print"</tr>\n";		
    }
    print "</table>\n";
//html_table($name.$age.$gender);
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
