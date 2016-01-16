<?php

require_once '../common.php';

define('DOC_ROOT', __DIR__);

class CodeManager {
    
    private static $fileDir = '/classes';
    
    public static function loader($className){
        $dir = DOC_ROOT . self::$fileDir . '/';
        $path = $dir . $className . '.php';
        if(!file_exists($path)){
            throw new Exception("No file for class {$className}");
        }
        p('load: ' . $path);
        require_once $path;
    }
}

spl_autoload_register('CodeManager::loader');

//$user = new User();
//$db = new DataBase();

if(! isset($_GET['c']) OR ! isset($_GET['m'])){
    die('no class');
}

$class = ucfirst($_GET['c']);
$controller = new $class();
$method = $_GET['m'];
$params = $_GET['p'];

call_user_func_array([$controller, $method], $params);
