<?php
require_once '../common.php';
header('Content-Type: text/html; charset=utf-8');

$url = 'http://www.imdb.com/chart/top?ref_=nv_mv_250_6';
//file_put_contents('imdb.html', $html);
//$html = file_get_contents($url);
$html = file_get_contents('imdb.html');

$regex = '#<td class="titleColumn">[^<>]+<a href="([^\"]+)"\stitle="([^\"]*)"\s>([^<]+)</a>\s*'//.''//.''
        .'<span class="secondaryInfo">\((\d{4})\)</span>\s*</td>\s*<td class="ratingColumn imdbRating">\s*'//'
        . '<strong title="([\d\,\.]+)\s*[^\d]*([\d\,\s]+) votes">'//'
        .'#ims';
if(! preg_match_all($regex, $html, $m)){
    die('No valid data!');
}
p('count = ' . count($m));
//p($m[0]);

$res = '';
foreach($m[0] as $i => $val){
    $t = '<div style="color: #800;">';
    $t .= " {$i}: {$m[3][$i]}; {$m[4][$i]}; rating:{$m[5][$i]}; votes: {$m[6][$i]};"
    . " {$m[2][$i]} <a href='{$m[1][$i]}'>link</a>";
    $t .= '</div>';
    $res .= $t;
}

p($res);