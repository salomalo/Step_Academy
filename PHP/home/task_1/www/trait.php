<?php

interface Informer {	
	static function counter();
}

trait PrintInfo{
	function getInfo()
	{
		print "Counter =". $this->counter();
		
	}
}

class Caravan implements Informer
{
	use PrintInfo;
	public static function counter(){
		return (10);
	}
}

class Caravan2 implements Informer
{
	use PrintInfo;
	public static function counter(){
		return (20);
	}
}

$exemp = new Caravan;
$exemp->getInfo();
print "</br>";

$exemp2 = new Caravan2;
$exemp2->getInfo();