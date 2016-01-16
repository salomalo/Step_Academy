<?php

class Tester {
    function test($x = 1){
        p("test result = " . ($x%2==0 ? 'true' : 'false'));
    }
}