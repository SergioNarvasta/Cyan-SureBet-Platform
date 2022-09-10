<?php
  $file ="Downloads_Files/Pinnacle.html";
  $filecompleto = file_get_contents($file,FALSE,NULL,57761,30800);
  $filehtml = "";

  $content = new DOMDocument('1.0', 'utf-8');
  $content->preserveWhiteSpace = FALSE;
  @$content->loadHTMLFile($file);
 
  
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SCRAPPING WEB</title>
</head>
<body>
<?php
   echo $filecompleto;
  //echo $content->getElementsByTagName('div');

?>
</body>
</html>