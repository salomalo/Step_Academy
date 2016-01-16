        <div class="list">
            <?php foreach($list as $item):?>
            <a href="/L12_eval/item.php?id=<?=$item->id?>"><?=$item->title?></a> <br> 
            <?php endforeach;?>
        </div>