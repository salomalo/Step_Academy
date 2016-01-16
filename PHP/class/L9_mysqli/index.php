<?php
require_once '../common.php';

$host = 'localhost'; 
$user = 'root'; 
$password = ''; 
$database = 'php-2015-2';
$mysqli = mysqli_connect($host, $user, $password, $database);
if(! $mysqli){
    die('No connection!');
}

$id = (isset($_GET['id'])) ? intval($_GET['id']) : 1;

$sql = "SELECT * FROM articles WHERE id = {$id} LIMIT 0,1;";

$resultSet = mysqli_query($mysqli, $sql);

$article = mysqli_fetch_assoc($resultSet);

//p($resultRow);

$menuSql = "SELECT id FROM articles;";
$resultMenuSet = mysqli_query($mysqli, $menuSql);

$rows = mysqli_fetch_all($resultMenuSet);
$ids = [];
foreach($rows as $row){
    $ids[] = $row[0];
}
//p($ids);

$mysqli->close();

include 'tpl.php';
