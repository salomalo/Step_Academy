<?php
require_once '../common.php';

$name = 'last_time';

if(isset($_COOKIE[$name])){
    p("Hello ma dier user, you was here at {$_COOKIE[$name]}.");
} else {
    p("Who are you dude?");
}
//p(microtime());

$val = date('Y-m-d--H-i-s');

$expire = strtotime('next month');
$token = md5(mt_rand(1, 1000000000) . microtime());
setcookie($name, $val, $expire);
setcookie('token', $token, $expire);

