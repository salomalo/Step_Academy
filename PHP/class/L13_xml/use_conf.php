<?php
include '../common.php';

// load xml file
$conf = simplexml_load_file('config.xml');
$color = $conf->xpath('//color/@val');
vd($color);
//p($color[0]->children());
// data
$style;

// include html
?>
<style type="text/css">
    div{
        <?=$style?>
    }
</style>
<div style="<?=$style?>"></div>
