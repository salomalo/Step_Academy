<?php

include '../common.php';

$padding = 4;
$cellSize = 64;
$image = imagecreate (($cellSize+$padding)*8+$padding, ($cellSize+$padding)*8+$padding);

$black = imagecolorallocate($image, 150, 150, 150);
$red = imagecolorallocate($image, 127, 0, 0);
$yellow = imagecolorallocate($image, 255, 255, 0);

imagefill($image, 0, 0, $black);

$w = $cellSize;
$h = $cellSize;

for($i=0; $i<8; ++$i){
    for($j=0; $j<8; ++$j){
        $x1 =  $i * ($w + $padding)+ $padding;
        $y1 =  $j * ($h + $padding) + $padding;
        $x2 = $x1 + $w;
        $y2 = $y1 + $h;
        $di = $i%2 == 0;
        $dj = $j%2 == 0;
        $color = ($di && $dj ) || (!$dj && !$di) ? $yellow : $red;
        imagefilledrectangle ($image, $x1, $y1, $x2, $y2, $color);
//        p("$x1, $y1, $x2, $y2");
    }
}

header('Content-type: image/png');
imagepng($image);
imagedestroy($image);
