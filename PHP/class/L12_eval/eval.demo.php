<?php

eval("print 'Hello eval!<br>';");
eval("?><div>Div eval</div><?");

$name = 'Vasya';
ob_start();
?><div>Hello <?=$name?></div><?php
$content = ob_get_contents();
ob_end_clean();
print "<div>Some text before hello...</div>";
print $content;

$data = [
    'x1' => '123',
    'x2' => 456,
    'x3' => 'Hello!'
];

extract($data);
print "<div>{$x1}, {$x2}, {$x3}</div>";
