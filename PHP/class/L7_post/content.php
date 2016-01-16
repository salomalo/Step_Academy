<?php
require_once '../common.php';
session_start();

if(! isset($_SESSION['auth'])){
    header('Content-Type: text/html; charset=utf-8');
//    print '<html>
//        <head></head>'; // <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    p("Вы не авторизованы, перейдите на страницу авторизации > <a href='auth.form.php'>login form</a>");
//    print '</html>';
    exit;
}


$content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. "
. "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
        . "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. "
        . "Excepteur sint occaecat cupidatat non proident, "
. "sunt in culpa qui officia deserunt mollit anim id est laborum.";

p("Hello {$_SESSION['name']} !");
p("Read this secret text:");
p($content);
