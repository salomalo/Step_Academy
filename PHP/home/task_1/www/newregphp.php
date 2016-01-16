<?php

require_once '/common.php';

$host = 'localhost';
$user = 'root';
$password = '';
$database = 'melnykdb';

$dsn="mysql:dbname={$database};host={$host}";

try{
    $pdo = new PDO ($dsn, $user, $password);
} catch (PDOException $ex){
    die('No connection');
}

function getPost($key) {
return isset($_POST[$key]) ? $_POST[$key] : null;
}

//function Hash($param) {
//    
//}



$login = getPost('login');
$name  = getPost('name');
$pass  = getPost('pass');
$pass2 = getPost('pass2');
$email = getPost('email');
$age   = getPost('age');
$gender= getPost('gender');



$sql="INSERT INTO `users` (login,name,pass,email,age,gender,registration_date)"
        ."VALUES (:login, :name, :pass,:email,:age,:gender,NOW()); ";

$params=[
    ':login' =>$login,
    ':name'  =>$name,   
    ':pass'  =>$pass,   
    ':email' =>$email,
    ':age'   =>$age,
    ':gender'=>$gender,
];

$stat = $pdo->prepare($sql);
$stat->execute($params);

//$stat->





/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

