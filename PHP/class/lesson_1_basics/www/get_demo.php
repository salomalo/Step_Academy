<?php 

if(isset($_GET['name'])){
	$name = $_GET['name'];
	$age = $_GET['age'];
	print "<div>name = {$name}</div> 
	<div>age = {$age}</div>";
	unset($_GET['name']);
}
