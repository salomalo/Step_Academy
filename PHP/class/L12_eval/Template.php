<?php


class Template {
    private $file;
    private $fileContent;
    private $data = []; // ['key' => 'val', ..]
    
    function __construct($file, $data) {
        $this->file = DOC_ROOT . '/tpl/' . $file . '.php';
        $this->data = $data;
        $this->fileContent = file_get_contents($this->file);
    }
    
    function __set($key, $val){
        $this->data[$key] = $val;
    }
    
    function render($out=false){
        extract($this->data);
        ob_start();
        eval('?>' . $this->fileContent . '<?');
        $content = ob_get_contents();
        ob_end_clean();
        if($out){
            return print $content;
        }
        return $content;
    }
}
