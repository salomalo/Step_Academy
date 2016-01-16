<?php

require_once '../common.php';

class A {
    public static function doSmth(){
        p("Doing something...");
    }
    
    public function doDo(){
        static::doSmth();
    }
}

class B extends A {
    public static function doSmth(){
        p("Doing something else...");
    }
}

// B::doSmth();

$b = new B();
$b->doDo();
