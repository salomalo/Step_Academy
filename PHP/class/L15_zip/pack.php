<?php
$time = time();
$srcDir = 'source';
$zipFile = __DIR__ . "/arc/z{$time}.zip";
$zip = new ZipArchive();
file_put_contents("$srcDir/$time.txt", 'time:' . time());

$files = scandir($srcDir);

$zip->open($zipFile, ZIPARCHIVE::CREATE);
$subFolder = 'time_list';
$zip->addEmptyDir($subFolder);
foreach($files as $f){
    if(! preg_match('#\.txt#', $f)){
        continue;
    }
    $zip->addFile("$srcDir/$f", "$subFolder/$f");
}

$zip->addFile("$srcDir/1.txt");

$content = file_get_contents('http://www.itnews.com.au/RSS/rss.ashx?type=Category&ID=207');
$zip->addFromString("$srcDir/2.txt", $content);

$zip->close();

$fileSize = strlen(file_get_contents($zipFile));
print "File {$zipFile} with size = $fileSize bytes";



