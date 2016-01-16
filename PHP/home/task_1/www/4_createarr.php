<?php

/* https://myphpsite.com/createarr2.php  */

showuser();

function showuser() {
    $row = 10;
    $col = 3;

    /* $color=99996;  */


    $arr = [['name1', 'male', '23'],
        ['name2', 'male', '24'],
        ['name3', 'male', '25'],
        ['name4', 'male', '26']
    ];

    print "<table>\n";
    for ($i = 0; $i < $row; $i++) {
        print"<tr>\n";

        for ($j = 0; $j < $col; $j++) {

            print "<td>" . $arr[$i][$j] . "</td>";
        }
        print"</tr>\n";
    }
    print "</table>\n";
}
