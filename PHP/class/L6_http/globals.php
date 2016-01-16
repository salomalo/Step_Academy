<?php

require_once '../common.php';

session_start();

p($GLOBALS);

?>
<form method="post" action="globals.php?page=123&age=21vek">
    <input type="text" value="123" name="name" />
    <input type="submit" value="send post" />
</form>
