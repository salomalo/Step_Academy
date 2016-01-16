<?php
include 'inc.php';
$id = isset($_GET['id']) ? $_GET['id'] : null;
if(! $id){
    header('location:http://test1.com:81/L11_crud/?category=1');
}
$model = new Model('text_items');
$item = $model->read($id);

$colModel = new Model('colors');
$color = $colModel->read($item->color);

?>
<html>
    <head></head>
    <body>
        <h1><?=$item->title?></h1>
        <div style="color: <?=$color->color?>; border: 1px solid <?=$color->color?>;"><?=$item->text?></div>
    </body>
</html>