<?php
require_once '/common.php';

function redirectToForm(){
    $url = 'http://'. $_SERVER['HTTP_HOST'] . '/registration.form.php';
    header("location:" . $url);
    exit;
}

if(empty($_POST) && !isset($_POST['login']) ){
    redirectToForm();
}

$login = $_POST['login'];
$pass = $_POST['pass'];

//p($_FILES);
$file = $_FILES['photo'];

if($_FILES['photo']['error'] != 0){
    p('Incorrect upload!');
    exit;
}

$newFileName = '/files/' . time() . '_' . $file['name'];
$newFile = __DIR__ . $newFileName;
if(is_uploaded_file($file['tmp_name'])){
    $loaded = move_uploaded_file($file['tmp_name'], $newFile);
}
//p('tmp file ' . (file_exists($file['tmp_name']) ? 'exists' : 'no'));

print $login;

$f = fopen( $login . '-' .time() .'.txt', 'a');
fputs($f, $login."|".$pass);
fclose($f);

?> 