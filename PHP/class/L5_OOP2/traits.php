<?php
require_once '../common.php';

trait Tester {
    function test1(){
        parent::test1();
        p("Tester:test1");
    }
    function test2(){
        p("Tester:test2");
    }
}

class Aster {
    function test1(){
        p("Aster:test");
    }
}

class Bster extends Aster {
    
    use Tester;
    
    function test2(){
        //p(test1());
        
        p("Bster:test2");
    }
    
    function test(){
        $this->test1();
    }
}

$b = new Bster();

$b->test1();
$b->test2();

