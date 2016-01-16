<html>
    <head></head>
    <body>
        <h1><?=$category->name?></h1>
        <div class="menu">|
            <?php foreach($categories as $cat):?>
            <a href="/L11_crud/?category=<?=$cat->id?>"><?=$cat->name?></a> | 
            <?php endforeach;?>
        </div>
        <div><a href="edit.form.php">Add item</a></div>
        <div class="list">
            <?php foreach($list as $item):?>
            <a href="/L11_crud/item.php?id=<?=$item->id?>"><?=$item->title?></a> <br> 
            <?php endforeach;?>
        </div>
    </body>
</html>