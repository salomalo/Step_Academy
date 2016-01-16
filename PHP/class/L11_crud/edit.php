<?php
include 'inc.php';

if(empty($_POST)){
    die('Sorry...');
}

$fields = ['id', 'title', 'text', 'color', 'category'];
$data = [];
foreach($fields as $f){
    $val = isset($_POST[$f]) ? $_POST[$f] : null;
    if(is_null($val) && $f != 'id'){
        die('Incorrect input!');
    }
    $data[$f] = $val;
}

$model = new Model('text_items');

if(! $data['id']){
    unset($data['id']);
    $id = $model->create($data);
} else {
    $id = $data['id'];
    unset($data['id']);
    $model->update($id, $data);
}

