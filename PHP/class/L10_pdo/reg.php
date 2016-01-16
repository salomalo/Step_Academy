<?php

require_once '../common.php';

$host = 'localhost'; 
$user = 'root'; 
$password = ''; 
$database = 'php-2015-2';

$dsn = "mysql:dbname={$database};host={$host}";

try{
    $pdo = new PDO($dsn, $user, $password);
} catch (PDOException $ex) {
    die('No connection!');
}

function getPost($key){
    return isset($_POST[$key]) ? $_POST[$key] : null;
}

function hashStr($str){
    $salt = 'DSJsdf834jf7fdG5';
    $algo = 'sha512';
    return hash($algo, ($str . $salt));
}

$login = getPost('login');
$name = getPost('name');
$pass = getPost('pass');
$pass2 = getPost('pass2');
$email = getPost('email');
$age = getPost('age');
$gender = getPost('gender');

if ($pass != $pass2){
    die('Check password confirmation!');
}
// check all input values

$sql = "INSERT INTO `users` (login, name, pass, email, age, gender, regisration_date) "
        . "VALUES (:login, :name, :pass, :email, :age, :gender, NOW()); ";

$params = [
    ':login' => $login, 
    ':name'  => $name, 
    ':pass'  => hashStr($pass), 
    ':email' => $email, 
    ':age'   => $age, 
    ':gender' => $gender
];

$stat = $pdo->prepare($sql);
$stat->execute($params);
$id = $pdo->lastInsertId();
p("Inserted id: {$id}");
