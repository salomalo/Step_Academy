
******* code.php *************

<div><?="Hello world!"?></div>

********************************
<?php
$code = file_get_contents('code.php');
ob_start();
eval('...');
$content = ob_get_contents();
ob_end_clean();
print $content;
        
        
        ?>