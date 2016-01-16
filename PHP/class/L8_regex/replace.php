<?php

require_once '../common.php';

$html = file_get_contents('input.html');
p($html);


$regexp = '#<a href="([^\\"]+)">([^<]+)</a>#';
$tpl = 'page: ${2} ; by link: ${1}';

$result = preg_replace($regexp, $tpl, $html);
p($result);
