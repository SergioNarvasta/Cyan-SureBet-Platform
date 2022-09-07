<?php

echo "Codigo de php que descarga la pagina inicial de lawebdelprogramador.com y la
guarda en un archivo.";
$URL = "https://www.pinnacle.com/es";
$nomarc = "infofut_pinnacle";
//abrimos un fichero donde guardar la descarga de la web
$fp=fopen($nomarc, "w");
 
// Se crea un manejador CURL
$actcurl=curl_init();
 
// Se establece la URL y algunas opciones
curl_setopt($actcurl, CURLOPT_URL, $URL);

//determina si descargamos las cabeceras del servidor [0-No mostramos|1-mostramos]
curl_setopt($actcurl, CURLOPT_HEADER, 0);

//determina si mostramos el resultado en el navegador [0-mostramos|1-NO mostramos]
curl_setopt($actcurl, CURLOPT_RETURNTRANSFER, 1);

//determina donde guardar el fichero
curl_setopt($actcurl, CURLOPT_FILE, $fp);
 
// Se obtiene la URL indicada
curl_exec($actcurl);
 
// Se cierra el recurso CURL y se liberan los recursos del sistema
curl_close($actcurl);
 
//se cierra el manejador de ficheros
fclose($fp);

?>