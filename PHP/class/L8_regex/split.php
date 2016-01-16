<?php
require_once '../common.php';

$phonesInput = '11111111111111111,22222222222;33333333333333%%44444444444444444444:555555555555555555';

$phones = preg_split('#[\,\;\:\%\!]#mi', $phonesInput);
foreach($phones as $item){
    p($item);
}