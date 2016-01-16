<?php

require_once '../common.php';

$userList = [
    ['login' => 'admin', 'pass' => '1', 'name' => 'Super Admin'],
    ['login' => 'vasya', 'pass' => '2', 'name' => 'Vasya Pupkin'],
    ['login' => 'boss', 'pass' => '3', 'name' => 'Semen Petrovych Nalyvajko'],
    ['login' => 'user1', 'pass' => '4', 'name' => 'User Robert']
];

function redirectToForm(){
    $url = 'http://'. $_SERVER['HTTP_HOST'] . '/L7_post/auth.form.php';
    header("location:" . $url);
    exit;
}

if(empty($_POST) && !isset($_POST['login']) ){
    redirectToForm();
}

$login = $_POST['login'];
$pass = $_POST['pass'];

$auth = false;
$currentUser = null;
foreach($userList as $next){
    if($next['login'] == $login && $next['pass'] == $pass){
        $auth = true;
        $currentUser = $next;
        break;
    }
}

if(! $auth){
    p("Login ot password is not valid try another. Go to <a href='auth.form.php'>login form</a>");
    redirectToForm();
}

$name = $currentUser['name'];
p("Hello {$name} !");
session_start();
$_SESSION['auth'] = 1;
$_SESSION['name'] = $name;
$url = 'http://'. $_SERVER['HTTP_HOST'] . '/L7_post/content.php';
header("location:" . $url);


