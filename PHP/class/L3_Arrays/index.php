<?php

require_once '../common.php';

$arr1 = [1,2,3,4,5];
$arr2 = array(6,7,8,9,0);

p("\$arr count = " . count($arr1));

$arr3 = array_merge($arr1, $arr2);
pa($arr3);

$nums = [];
$nums = [];
for($i=0; $i<10; $i++){
    $nums[] = mt_rand(100, 999);
    $knums[mt_rand(100, 999)] = mt_rand(100, 999);
}
pa($nums);
sort($nums);
pa($nums);

pk($knums);
ksort($knums);
pk($knums);
pk(array_values($knums));

$res1 = array_product($nums);
p("res1 = $res1 ");

$fruits = array_fill(100, 10, 'banana');
pk($fruits);

$a1 = [1,2,3,4,5,6,7,8,9,0];
$a2 = [5,7,9,11,13];
pa( array_diff($a1, $a2, [6, 0]) );

$options = [
    'size' => 12,
    'count' => 100,
    'length' => 10000,
    'width' => 800,
    'height' => 600
];

$someCase = ['count', 'width', 'height'];
pk(array_flip($someCase));
$caseOptions = array_intersect_key($options, array_flip($someCase));
pk($caseOptions);

$nums = [1,2,3,4,5,6,7,8,9];
$squres = array_map(
        function($x){
            return $x * $x;
        }, 
        $nums);
pa($squres);
pa($nums);

pa(array_unique([1,2,5,4,2,3,2,7,4,2,4,6,7,1]));

class User {
    public $name;
    public $age;
    function __construct($name, $age){
        $this->name = $name;
        $this->age = $age;
    }
}

$users = [];
for($i=1; $i<=10; $i++){
    $users[] = new User("User{$i}", mt_rand(18, 60));
}

function pu($users){
    foreach($users as $u){
        p("{$u->name} : {$u->age}");
    }
}

pu($users);
usort($users, function(User $a, User $b){
    if($a->age == $b->age){
        return 0;
    }
    return $a->age > $b->age ? 1 : -1;
});
p("<br>");
pu($users);