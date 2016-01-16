<?php

$code = file_get_contents('text.php');
ob_start();
eval('?>'.$code.'<?');
$content = ob_get_contents();
ob_get_clean();
print $content;

?>