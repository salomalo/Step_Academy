<?php 
if(isset($_GET['p'])){
	$p = $_GET['p'];
	print "<div>p = {$p}</div>" ;

	$t=$p . ".txt";	
	$txt =  file_get_contents($t,FILE_USE_INCLUDE_PATH,NULL,1,20);
	print "<div>txt = {$txt}</div>" ;
	
	
	unset($_GET['p']);	
	
}
?>

<html>
<body>

<!-- WORK
<a href=https://myphpsite.com/page.php?p=1>1</a>
<a href=https://myphpsite.com/page.php?p=2>2</a>-->


<!-- STEP-->
<a href= http://test1.com:81/page.php?p=1>1</a>
<a href= http://test1.com:81/page.php?p=2>2</a>



<table width=100% height=100%>

<tr><td align=center>
<h2 align=center>Page......</h2>
</td></tr>
</table>

</body>
</html>
