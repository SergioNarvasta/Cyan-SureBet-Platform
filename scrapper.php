<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SCRAPPING WEB</title>
</head>
<body>
<?php
if(isset($_GET['btn'])):
    function file_get_contents_curl($url){
        $ch = curl_init();
        curl_setopt($ch, CURLOPT_HEADER, 0);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_URL, $url);
        curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1);
        $data = curl_exec($ch);
        curl_close($ch);
        return $data;
    }
    function limpiarString($String){ 
        $String = str_replace(array("|","|","[","^","´","`","¨","~","]","'","#","{","}",".",""),"",$String);
        return $String;
    }
    $url 	=	$_GET['url'];
	$html 	= 	file_get_contents_curl($url);                    
    $doc 	= 	new DOMDocument();
    @$doc->loadHTML($html);
    $nodes 	= 	$doc->getElementsByTagName('title');
    $title 	= 	limpiarString($nodes->item(0)->nodeValue);
    $metas 	= 	$doc->getElementsByTagName('meta');
    for ($i = 0; $i < $metas->length; $i++):
		$meta = $metas->item($i);
        if($meta->getAttribute('name') == 'description')
        	$description = limpiarString($meta->getAttribute('content'));
        if($meta->getAttribute('name') == 'keywords')
        	$keywords = limpiarString($meta->getAttribute('content'));
    endfor;
	echo "TITLE :<br>".$title."<br>";
    echo "DESCRIPTION :<br>".$description."<br>";
    echo "KEYWORDS :<br>".$keywords;
else:
?>
<form>
	<input type="url" name="url" placeholder="Ej. http://empresa.com" required>
	<button name="btn" type="submit">SCRAPEAR</button>		
</form>
<?php endif; ?>
</body>
</html>