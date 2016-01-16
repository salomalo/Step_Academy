<?php

/* https://myphpsite.com/createTable.php  */

createTable(5, 10);

function createTable($col, $row) {
	
	$color=99996;
        $xColorStep = floor(255/$col);
    $yColorStep = floor(255/$row);
	print "<table>\n";

    for ($i = 0; $i < $row; $i++) {
        
		print"<tr>\n";
		
        for ($j = 0; $j < $col; $j++) {  
		
//             print "<th style="."color:white;background-color:$color;".">$i</td>";   
//		            
            $r = 255- $xColorStep * $i;
            $g = 255 - $yColorStep * $j;
            $style= "width:30px; height:30px; border:1px solid #888; background-color:rgb({$r}, {$g}, 0);";
            print "<td style=\"{$style}\"></td>\n";	 
        }
		
        print"</tr>\n";
		
    }

    print "</table>\n";
}


