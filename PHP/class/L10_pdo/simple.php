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
$id = (isset($_GET['id'])) ? intval($_GET['id']) : 1;

$sql = "SELECT * FROM articles WHERE id = :art_id LIMIT 0,1;";
$statement = $pdo->prepare($sql);
$statement->execute([':art_id' => $id]);

$article = $statement->fetch();

$menuSql = "SELECT id FROM articles;";
$menuStat = $pdo->query($menuSql);
$resultMenuSet = $menuStat->execute();
$rows = $menuStat->fetchAll();
$ids = [];

foreach($rows as $row){
    $ids[] = $row[0];
}

include 'tpl.php';