<?php
    include 'inc.php';
    $colModel = new Model('colors');
    $colors = $colModel->getAll();
    $catModel = new Model('categories');
    $categories = $catModel->getAll();
?><html>
    <head>
        <style type="text/css">
            
            input, select, textarea{
                display: block;
                margin: 4px 0 0 20px;
            }
        </style>
    </head>
        <body>
            <form action="edit.php" method="post">
                
                <select name="color" >
                    <?php foreach($colors as $color):?>
                    <option value="<?=$color->id?>"><?=$color->color?></option>
                    <?php endforeach;?>
                </select>
                
                <select name="category" >
                    <?php foreach($categories as $category):?>
                    <option value="<?=$category->id?>"><?=$category->name?></option>
                    <?php endforeach;?>
                </select>
                
                <input type="text" name="title" />
                <textarea name="text"  cols="50" rows="10"></textarea>
                <input type="submit" value="Save" />
            </form>
        </body>
</html>