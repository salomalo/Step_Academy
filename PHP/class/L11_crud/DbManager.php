<?php

class DbManager extends PDO {
    
    protected static $instance = null;
    
    public function __construct() {
        $dsn = "mysql:dbname=php-2015-2;host=localhost";
        parent::__construct($dsn, 'root', '');
    }
    
    public static function getInstance(){
        if(is_null(self::$instance)){
            self::$instance = new self();
        }
        return self::$instance;
    }
    
    public function query($sql, $params=[]){
//        p($sql);
//        p($params); return;
        $stat = $this->prepare($sql);
        $stat->execute($params);
        return $stat;
    }
    
    public function insert($sql, $params=[]){
        $stat = $this->query($sql, $params);
        return $this->lastInsertId();
    }
    public function select($sql, $params=[]){
        $stat = $this->query($sql, $params);
        return $stat->fetchAll(PDO::FETCH_OBJ);
    }
    public function update($sql, $params=[]){
        $stat = $this->query($sql, $params);
        return $stat->columnCount();
    }
    public function delete($sql, $params=[]){
        $stat = $this->query($sql, $params);
        return $stat->columnCount();
    }
}
