<html>
    <head></head>
    <body>
        <div>
            <?php foreach($ids as $id):?>
                [<a href="?id=<?=$id?>"><?=$id?></a>]
            <?php endforeach?>
        </div>
        <h4><?=$article['title']?></h4>
        <div>
            <?=$article['content']?>
        </div>
        
        <div style="color: #aaa; font-size:10px;">
            <?=$article['date']?>
        </div>
    </body>
</html>