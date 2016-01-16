<?php

require_once '../common.php';

function multiParam($params){
    p(implode(' * ', $params));
}

class A {
    function f1($a){ multiParam(func_get_args()); }
    function f2($a, $b){ multiParam(func_get_args()); }
}

class B{
    function f3($a){ multiParam(func_get_args()); }
    function f4($a, $b, $c){ multiParam(func_get_args()); }
}

$class = $_GET['c'];
$method = $_GET['m'];
$p = $_GET['p'];
$params = explode(',', $p);

$inst = new $class();
call_user_func_array([$inst, $method], $params);

