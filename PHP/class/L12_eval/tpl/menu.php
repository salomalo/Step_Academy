        <div class="menu">|
            <?php foreach($categories as $cat):?>
            <a href="/L12_eval/view.php?category=<?=$cat->id?>"><?=$cat->name?></a> | 
            <?php endforeach;?>
        </div>