<?php

require_once '../common.php';

p($_FILES);
$file = $_FILES['myfile'];

if($_FILES['myfile']['error'] != 0){
    p('Incorrect upload!');
    exit;
}

$content = file_get_contents($_FILES['myfile']['tmp_name']);
p($content);
$newFile = __DIR__ . '/files/' . time() . '_' . $file['name'];
if(is_uploaded_file($file['tmp_name'])){
    $loaded = move_uploaded_file($file['tmp_name'], $newFile);
}
p('tmp file ' . (file_exists($file['tmp_name']) ? 'exists' : 'no'));
