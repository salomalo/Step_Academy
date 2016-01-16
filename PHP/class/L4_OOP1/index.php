<?php

require_once '../common.php';

abstract class Unit{
    abstract function getWeight();
}

class User extends Unit {
    var $name;
    public $name2;
    protected $age;
    private $code;
    private $weight = 1;
    const MAX_AGE = 120;
    protected static $counter = 0;


    public static function getInstance($age){
        return new self($age);
    }
    
    public function getAge(){
        return $this->age;
    }
    
    public function setAge($age){
        if($age > self::MAX_AGE){
            return;
        }
        $this->age = $age;
    }
    
    public function cloneUser(User $user){
        // ...
    }


    public function __construct($age, $name=""){
        self::$counter++;
    }
    
    public function __destruct(){
        
    }

    public function getWeight() {
        return $this->weight;
    }

}

interface Flyer {
    public function fly();
}

interface Driver {
    function drive();
}

class SuperMan extends User implements Flyer, Driver {
    
    public function __construct($age, $name=""){
        parent::__construct($age, 'Super' . $name);
    }
    
    public function getWeight() {
        return parent::getWeight() * 10;
    }

    public function drive() {
        print 'dur dur dur';
    }

    public function fly() {
        print "I can Fla-a-a-ay!!";
    }

}

$user = User::getInstance(20);


//**********

abstract class Car{
    abstract function move();
}

class LCar extends Car {
    function move(){
        p("brrrrr");
    }
}
class BCar extends Car {
    function move(){
        p("drrrrr");
    }
}

$cars = [new LCar(), new BCar()];

function parkMove(Car $car){
    $car->move();
}

foreach($cars as $car){
    parkMove($car);
}

/**********************************************/

class Action {
    private $date;
    private $time;
    private $name;
    private $description;
    private $duration;
    private $location;
    
    private $aval = ['name', 'date', 'time', 'description'];
    
    public function __construct($name) {
        $this->name = $name;
    }
    
    public function __get($key){
        if(isset($this->{$key})){
            return $this->{$key};
        }
        return null;
    }
    
    public function __set($key, $val){
        $this->{$key} = $val;
    }
    
    public function __call($method, $args){
        $prefix = substr($method, 0, 3);
        if(in_array($prefix, ['get', 'set'])){
             $field = strtolower(substr($method, 3));
             switch($prefix){
                 case 'get':
                    if(isset($this->{$field}) && in_array($field, $this->aval)){
                        return $this->{$field};
                    }
                    return null;
                    break;
                 case 'set':
                    if(isset($this->{$field}) && in_array($field, $this->aval)){
                        $this->{$field} = $args[0];
                    }
                    break;
             }
        }
    }
    
    public function __toString(){
        return "[{$this->name} : {$this->date}]";
    }
    
}

$action = new Action("Vasya's DR");

$action->date = 132456798;
print $action->date;

$action->setName("Pohmel of Vasya");
p($action->getName());
p("$action");



class Span{}
class Div{}

$span = new Span("text");
$div = new Div();
$div->add($span);
$page = new Html();
$page->add($div);
$page->render();