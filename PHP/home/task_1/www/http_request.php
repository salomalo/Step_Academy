<?php
sesion_start();

if(isset ($_SESSION['counter'])){
	$_SESSION['counter']=0;
}
else{
	$_SESSION['counter']++;
}
<a href=""><test>