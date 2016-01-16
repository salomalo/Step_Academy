<?php

include 'inc.php';
define('DOC_ROOT', __DIR__);

$model = new Model('articles'); 

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

$menuTpl = new Template('menu', ['categories' => $categories]);
$itemsTpl = new Template('item_list', ['list' => $list]);
$mainTpl = new Template('list.tpl', [
    'menu' => $menuTpl->render(),
    'list' => $itemsTpl->render()
    ]);
$mainTpl->category = $category;
print $mainTpl->render();
