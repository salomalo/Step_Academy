<?php
require_once '../common.php';

$fileName = '1.txt';

if(file_exists($fileName)){
    $content = file_get_contents($fileName); // {"counter" : 1}
    $obj = json_decode($content);
    $value = $obj->counter;
} else {
    $obj = new stdClass();
    $obj->counter = 0;
}

p("counter = {$obj->counter}");

$obj->counter++;
$content = json_encode($obj);
file_put_contents($fileName, $content);

