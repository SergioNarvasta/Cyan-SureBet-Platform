<?php
   //Install purpeteer with -> npm i puppeteer     // Run node Scrapper_Pinnacle.js  //SELECT * FROM bet_cab A left join bet_det B ON A.idbet = B.idbet;
   include ("simple_html_dom.php");    include ("conexion.php") ;
  $file ="Downloads_Web/Pinnacle.html";
  $filereducido = file_get_contents($file,FALSE,NULL,57761,30800);
  $myhtml = file_get_html($file); $content = $myhtml->find("span") ;  $i = 27;
  $deporte = "Futbol";    $casa ="Pinnacle";
  //*******************  Datos de 1 ***********************************
  try {
    //Llave random
    $idcab1=substr(sha1(time()), 0, 16);
    $lo1   = $content[$i]->innertext;
    if(Empty($lo1) or $lo1 >0){
    $lo1   = $content[$i+1]->innertext;  $vi1  = $content[$i+2]->innertext;  $fe1  = $content[$i+3]->innertext; 
    }
    $vi1  = $content[$i+1]->innertext;  $fe1  = $content[$i+2]->innertext;  
    $cl1 = $content[$i+3]->innertext;
    if($cl1=="Ver porcentaje de apuestas"){
      $cl1 = $content[$i+4]->innertext;   $ce1 = $content[$i+5]->innertext;    $cv1 = $content[$i+6]->innertext;
    }else{
      $ce1 = $content[$i+4]->innertext;   $cv1 = $content[$i+5]->innertext;    $i = $i+6;
    }
    $insert_cab1 = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES('$idcab1','$deporte','$lo1','$vi1','$fe1',CURRENT_TIME)";
    $res_insert_cab1 = mysqli_query($cn,$insert_cab1);
    if($res_insert_cab1<1){
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_cab]";echo $res_insert_cab1;
    }else{echo "<br>";echo "---Insert con exito [bet_cab]"; echo $lo1.$vi1;echo $res_insert_cab1;} 
    
    $insert_det1 = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`)VALUES('$idcab1',NULL,'$casa',$cl1,$ce1,$cv1)";
    $res_insert_det1 = mysqli_query($cn,$insert_det1);
    if($res_insert_det1<1){
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_det]";echo $res_insert_det1;
    }else{echo "<br>";echo "---Insert con exito [bet_det] ";echo $res_insert_det1;} 

  }catch(Exception $ex){  }
?>
<head>
    <meta charset="UTF-8">
    <title>SCRAPPING WEB</title>
</head>
<body>
<center><div class="Info">
  <?php
    echo "<br>";echo "<p>Informacion de Pinnacle</p>";
    echo $lo1."  -"; echo $vi1."  -"; echo $fe1; echo "<br>";
    echo $cl1."  -"; echo $ce1."  -"; echo $cv1; echo "<br>";echo "<br>";
   
    echo $lo2."  -";echo strlen($lo2); echo $vi2."  -"; echo $fe2; echo "<br>";
    echo $cl2."  -"; echo $ce2."  -"; echo $cv2; echo "<br>";echo "<br>";

    echo $lo3."  -"; echo $vi3."  -"; echo $fe3; echo "<br>";
    echo $cl3."  -"; echo $ce3."  -"; echo $cv3; echo "<br>";echo "<br>";

    echo $filereducido;
  
  ?>
</div></center>

</body>