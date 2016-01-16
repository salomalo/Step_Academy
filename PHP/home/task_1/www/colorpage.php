<?php 
for($i=0; $i<10;++$i){
	//$color = ($i%2 == 0) ? '#fff' : '#888';
	if($i%2 == 0){
		$color = '#fff';
	} elseif($i%3 == 0) {
		$color = '#888';
	} else {
		$color = '#f80';
	}
	print "<div style='background-color:{$color}'>line2: {$i}</div>\n";
}
	

?>

<html>
<body>

<a href=https://myphpsite.com/page.php?p=1 onclick=" <?php header('Location: https://myphpsite.com/page.php?p=1')?> " >1</a>
<a href=https://myphpsite.com/page.php?p=2 onclick=" <?php header('Location: https://myphpsite.com/page.php?p=2')?> " >2</a>



<table width=100% height=100%>

<tr><td align=center>
<h2 align=center>Page......</h2>
</td></tr>
</table>

</body>
</html>
