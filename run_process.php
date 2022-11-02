<?php 
//https://getcomposer.org/download/   install:  composer require symfony/process

$filepi  = "Scrapper_Pinnacle.js";
$command = "node ".$filepi;
$result  = shell_exec($command);
echo $result;


?>


