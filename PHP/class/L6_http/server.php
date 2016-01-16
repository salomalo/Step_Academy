<?php
require_once '../common.php';

p('['. file_get_contents('php://input') . ']');
//p($_SERVER);

?>
<form method="post" action="server.php">
    <input type="text" value="123" name="name" />
    <input type="submit" value="send post" />
</form>