<?php 

$x = 1;
$x = "1";
$x = '1';
$y = 1.0;
$b = true; // false
$b = TRUE;
$n = NULL;

$arr = array(1,2,3,4,5);
$arr2 = ['a', 'b'];
print $arr[0];

$user = [
	'name' => 'Vasya',
	'age' => 22,
	'gender' => true
];

$name = "Vasya";
$surName = "Pupkin";
$fullName = $name . ' ' . $surName;
print $name{0};

$text = <<<ABC
qqqq
www
eee
rrr
ABC;

class User {
	private $firstName;
	private $surName;
	const ABC = 123;
	
	public function __construct($fName='', $sName=''){
		$this->firstName = $fName;
		$this->surName = $sName;
		print "<br> classname = " . __CLASS__ ."<br>";
	}
	
	public function __destruct(){}
	
	public function getName(){
		return $this->firstName . ' ' . $this->surName;
	}
}

$user2 = new User('Vasya', 'Pupkin');
print $user2->getName();

print "Hello 1";
echo "Hello 2";
print ("Hello 3");
print "<br>\n";

$colors = ['red', 'yellow', 'green', 'blue', 'black'];

print "<pre>"; print_r($colors); print "</pre>\n";

// циклы

$i=0;
while($i < 3){
	print "<div>line '\$i': {$i}</div>\n";
	$i++;
}

for($i=0; $i<3;++$i){
	print "<div>line2: {$i}</div>\n";
}

foreach($colors as $key => $color){
	$colors[$key];
	print "<div style='background-color:{$color}; color: white;'>{$key}</div>\n";
}

/*   */

# ветвления

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
$x = 2;
switch($x){
	case 2: 
		print "<br>Two<br>";
		break;
	default: 
		print "<br>No<br>";
		break;
}

// *************************

define('NAME', 'Vasya Pupkin Superman');
define('DOC_ROOT', __DIR__);


print NAME . "<br>";

$option = 'name';
$name = 'Galina Petrovna';
print $$option;

include 'users.php';


function foo(){
	print "<br>". __FUNCTION__ ."<br>";
}
foo();
new User();

require_once 'common.php';
require_once 'common.php';

/// operators

// + - / * %
// > < >= <= != ==
$x = 1;
if($x === 1){
	print "<br>correct condition<br>";
}
// && AND  || OR
function bar($a){
	return $a * $a;
}
if($x=bar(1) && $y=bar(2)){
	
}

