<?php

require_once '../common.php';

//p($_FILES);
$file = $_FILES['myfile'];

if($_FILES['myfile']['error'] != 0){
    p('Incorrect upload!');
    exit;
}

$newFileName = '/files/' . time() . '_' . $file['name'];
$newFile = __DIR__ . $newFileName;
if(is_uploaded_file($file['tmp_name'])){
    $loaded = move_uploaded_file($file['tmp_name'], $newFile);
}
//p('tmp file ' . (file_exists($file['tmp_name']) ? 'exists' : 'no'));
$imgUrl = '/L7_post' . $newFileName;
?>

<img src="<?=$imgUrl?>" />
