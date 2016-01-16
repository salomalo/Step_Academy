<?php

include 'inc.php';

$model = new Model('articles'); 

//$model->create(['title'=>'title1', 'content'=>'test content']);
//$model->read(2);
//$model->update(3, ['title'=>'title2', 'content'=>'test content 2']);
//$model->delete(10);
$catModel = new Model('categories');
$categories = $catModel->getAll();
$curCat = isset($_GET['category']) ? $_GET['category'] : null;
if($curCat){
    $category = $catModel->read($curCat);
} else {
    $categoryRows = $catModel->getDB()->
            select('SELECT * FROM `categories` ORDER BY id LIMIT 0,1 ;');
    $category = $categoryRows[0];
}

// **************************
$textModel = new Model('text_items');
$list = $textModel->getDB()->select("SELECT * FROM `text_items` WHERE `category` = ? ", 
    [$category->id]);

include 'list.tpl.php';