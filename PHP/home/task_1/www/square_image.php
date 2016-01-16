<?php
$image = imagecreate(500,500);

$black = imagecolorallocate($image, 150, 150, 150);
$white = imagecolorallocate($image, 255, 255, 0);

imagefill($image,0,0,$black);
$cellsize=50;
for($i=0; $i<8; $i++)
{
    for($n=0; $n<8; $n++)
    {       
        $x = $i * $cellsize;
        $y = $n * $cellsize;       
        $x2 = $x + $cellsize;
        $y2 = $y + $cellsize;    
        $di = $i%2 == 0;
        $dj = $n%2 == 0;     
        $color = ($di && $dj) || (!$di && !$dj)? $black : $white;
        imagefilledrectangle($image, $x, $y, $x2, $y2, $color);        
    }
}
header('Content-type: image/png');
imagepng($image);