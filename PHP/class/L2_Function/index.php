<?php

require_once '../common.php';

function plus($x, $y){
    return $x + $y;
}

function getHash($str, $salt='123456'){
    return md5($str . $salt);
}

function doubleNumbers(&$arr){
    foreach($arr as $key => $val){
        $arr[$key] = $val * 2;
    }
}

$numbers = [1,2,3,4,5];

doubleNumbers($numbers);
p($numbers);

function counter(){
    static $x = 0;
    $x++;
    return $x;
}

for($i=0; $i<5; ++$i){
    counter();
}
p(counter());

$wordsCount = function($text){
    $arr = explode(' ', $text);
    return count($arr);
};

$text = 'qqq www rrr ttt yyy uuu ppp';

p('words count = ' . $wordsCount($text));

function functionGenerator($k){
    $y = $k;
    return function($x)use($y){
        return $x * $y;
    };
}

$mult10 = functionGenerator(10);
p($mult10(12));
$mult50 = functionGenerator(50);
p($mult50(12));
$mult1000000 = functionGenerator(1000000);
p($mult1000000(12));

function multiParam(){
    $params = func_get_args();
    return implode(' = - = ', $params);
}

p(multiParam('q', 'w', 'e', 'r', '1', '2', '3', '4'));

if(! function_exists('is_null')){
    function is_null($x){ return $x === null; }
}

//foreach(get_defined_functions() as $name){
//    p($name);
//}

class Abc {
    public $values = [1,2,3,'q','a','z'];
    public $num = 123456;
    public $name = "Vasya Krosavcheg!";
}

$abc = new Abc();

p($abc);
print "<pre>";
var_dump($abc);
print "</pre><br>\n";




