<?php
require_once  '../common/php';
define('DOC_ROOT',_DIR_);

class Tester{
	private static $fileDir= '';

	public static function test($x=1){	
		p();
	}
}

spl_autoload_register ('CodeManager::loader');

$user = new User();
$data = new DataBase();



