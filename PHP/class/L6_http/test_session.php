<?php
require_once '../common.php';

session_start();

if(isset($_SESSION['counter'])){
    p($_SESSION['counter']);
}

?>

<a href="session.php">session</a>