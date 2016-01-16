<?php
require_once  './common.php';
define('DOC_ROOT',_DIR_);

class CodeManager{
	private static $fileDir= '';

	public static function loader($className){	
		$dir = DOC_ROOT . self::$fileDir . '/' ;	
		$path = $dir . $className . '.php';
			
		if(!file_exists($path))
		{
			throw new Exeption ("error no such ");		
		}
	require_once $path;
	}
}

spl_autoload_register ('CodeManager::loader');

$user = new User();
$data = new DataBase();


if(!isset($_Get['c'])OR isset($_Get['m'])) {
	fie('no class');
}

$class = ucfirst($_Get['c']);
$controler = new $class();

$methods = $_Get['m'];
$params = $_Get['p'];

call_user_func_array([$controller,$method],$params);





