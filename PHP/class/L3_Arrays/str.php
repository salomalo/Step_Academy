<?php
require_once '../common.php';

p(md5(1));
p(sha1(1));
p(crc32 (1));

$html = '<table>
    <tr>
        <td>
            <div><a href="">1&$привет</a></div>
        </td>
    </tr>
</table>';

p(htmlspecialchars($html));
p(htmlentities($html));

$str = " ..-=my name is Vasya=-.. ";
p('['.trim($str, "-=. ") . ']');

p(strlen($str));
p(strpos($str, 'name'));
p(substr($str, strpos($str, 'name')));
p(str_repeat("abc ", 50));
$divs = "<div>1</div><div>2</div><div>3</div><div>4</div><div>5</div>";
p($divs);
p(str_replace('div', 'span', $divs));


// **************************************************** \\

p(time());
p(date('Y-m-d H:i:s'));
p(date('Y-m-d H:i:s', strtotime('next day')));




