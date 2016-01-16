<?php

createTable(4, 2);

function createTable($col, $row) {

    print "<table>\n";

    for ($i = 0; $i < $row; ++$i) {
        print"<tr>\n";

        for ($i = 0; $i < $col; ++$i) {
            print "<td>";
            
            print "style=bakgroundcolor:";
            
            print "</td>";        
        }
        print"</tr>\n";
    }

    print "</table>\n";
}

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

