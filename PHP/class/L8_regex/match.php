<?php

require_once '../common.php';

$logins = ['Vasya-123', '-=megaPups=-', '#438dfg9\'drop database'];
foreach($logins as $login ){
    $validation = preg_match('#^[\w\-]{4,64}$#im', $login);
    p("login '{$login}' is " . ($validation ? 'valid' : 'not valid'));
}


$passs = ['123', 'qwerty-115!', '\'insert....'];
foreach($passs as $pass ){
    $validation = preg_match('#^[\w\_\.\,\!\@\$\%\&]{8,16}$#im', $pass);
    p("pass '{$pass}' is " . ($validation ? 'valid' : 'not valid'));
}


$emails = ['admin@mail.com', '1111111111111111111.com', 'vasya@hazker', 'user1@qqq.www.eee.rrr.ttt.yyy.com'];
foreach($emails as $email ){
    $validation = preg_match('#^[\w\-\.]{2,128}@([\w\-]{1,60}\.){1,3}(com|net|info|org)$#im', $email);
    p("email '{$email}' is " . ($validation ? 'valid' : 'not valid'));
}




