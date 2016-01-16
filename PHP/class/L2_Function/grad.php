<?php

function gradient2d($x=10, $y=10){
    print "<table >\n";
    $xColorStep = floor(255/$x);
    $yColorStep = floor(255/$y);
    for($i=0; $i < $y; ++$i){
        print "<tr>\n";
        for($j=0; $j<$x; ++$j){
            $r = 255- $xColorStep * $i;
            $g = 255 - $yColorStep * $j;
            $style= "width:30px; height:30px; border:1px solid #888; background-color:rgb({$r}, {$g}, 0);";
            print "<td style=\"{$style}\"></td>\n";
        }
        print "</tr>\n";
    }
    print "</table>\n";
}

gradient2d(20, 20);