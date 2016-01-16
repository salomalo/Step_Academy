<?php

class Model {
    
    protected $table;
    protected $db;

    public function __construct($table) {
        $this->table = $table;
        $this->db = DbManager::getInstance();
    }
    
    public function create($data=null){
        if(is_null($data)){
            throw new Exception('Create: Empty data');
        }
        $fields = array_keys($data);
        $fieldsQuery = '`' . implode('`,`', $fields) . '`'; // [name, age, atata] => `name`,`age`,`atata`
        $tpl = str_repeat('?,', count($fields));
        $tpl = substr($tpl, 0, -1);
        $sql = "INSERT INTO `{$this->table}` ({$fieldsQuery}) VALUES ({$tpl}); ";
        $params = array_values($data);
        return $this->db->insert($sql, $params);
    }
    
    public function read($id){
        $sql = "SELECT * FROM `{$this->table}` WHERE id  = ? ;";
        $params = [$id];
        $rows = $this->db->select($sql, $params);
        return count($rows) > 0 ? $rows[0] : null;
    }
    
    public function update($id, $data){
        $updParts = [];
        $params = [];
        foreach($data as $field => $val){
            $updParts[] = "`$field` = ?";
            $params[] = $val;
        }
        $updStr = implode(', ', $updParts);
        
        $sql = "UPDATE `{$this->table}` SET {$updStr} WHERE id  = ? ;";
        $params[] = $id;
        return $this->db->update($sql, $params);
    }
    
    public function delete($id){
        $sql = "DELETE FROM `{$this->table}` WHERE id  = ? ;";
        $params = [$id];
        return $this->db->delete($sql, $params);
    }
    
    public function getAll(){
        $sql = "SELECT * FROM `{$this->table}`;";
        return $this->db->select($sql, []);
    }
    
    public function query($sql, $params=[]){
        return $this->db->query($sql, $params);
    }
    
    public function getDB(){
        return $this->db;
    }
}
