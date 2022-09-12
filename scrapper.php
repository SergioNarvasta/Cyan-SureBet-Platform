<?php
   //Install purpeteer with -> npm i puppeteer     // Run node Scrapper_Pinnacle.js  //SELECT * FROM bet_cab A left join bet_det B ON A.idbet = B.idbet;
   include ("simple_html_dom.php");    include ("conexion.php") ;
  $file ="Downloads_Files/Pinnacle2.html";
  $filereducido = file_get_contents($file,FALSE,NULL,57761,30800);
  $myhtml = file_get_html($file);     $content = $myhtml->find("span") ;  $i = 27;
  $deporte = "Futbol";    $casa ="Pinnacle";
  //*******************  Datos de 1 **********************************
  try {
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
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_cab]"; echo "<br>";echo $res_insert_cab1;
    }else{echo "<br>";echo "---Insert con exito [bet_cab]"; echo $lo1.$vi1;echo $res_insert_cab1;} 
    
    $insert_det1 = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`)VALUES('$idcab1',NULL,'$casa',$cl1,$ce1,$cv1)";
    $res_insert_det1 = mysqli_query($cn,$insert_det1);
    if($res_insert_det1<1){
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_det]"; echo "<br>";echo $res_insert_det1;
    }else{echo "<br>";echo "---Insert con exito [bet_det] ";echo $res_insert_det1;} 
  }catch(Exception $ex){  }
   //*******************  Datos de 2 **********************************
  try {
    $idcab2=substr(sha1(time()), 0, 16);
    $lo2   = $content[$i]->innertext;
    if(($lo2=="España - La Liga")or ($lo2=="Italia - Serie A")($lo2=="UEFA - Champions League")or($lo2="UEFA - Europa League")){
    $lo2 = $content[$i+2]->innertext;  
    $vi2 = $content[$i+3]->innertext;  $fe2 = $content[$i+4]->innertext; 
    $cl2 = $content[$i+5]->innertext;  $ce2 = $content[$i+6]->innertext;  $cv2 = $content[$i+7]->innertext;$i = $i+6;
    }else{  
    $vi2 = $content[$i+1]->innertext;  $fe2 = $content[$i+2]->innertext; 
    $cl2 = $content[$i+3]->innertext;  $ce2 = $content[$i+4]->innertext;  $cv2 = $content[$i+5]->innertext;$i = $i+6;
    }
    //$insert_cab2 = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES('$idcab2','$deporte','$lo2','$vi2','$fe2',CURRENT_TIME)";
    //$res_insert_cab2 = mysqli_query($cn,$insert_cab2);
    //if($res_insert_cab2<1){
    //  echo "<br>";echo "Ocurrio un error al Insertar en table [bet_cab]"; echo "<br>";echo $res_insert_cab2;
    //}else{echo "<br>";echo "---Insert con exito [bet_cab]"; echo $lo1.$vi1;echo $res_insert_cab2;} 
    
    //$insert_det2 = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`)VALUES('$idcab2',NULL,'$casa',$cl2,$ce2,$cv2)";
    //$res_insert_det2 = mysqli_query($cn,$insert_det2);
    //if($res_insert_det2<1){
    //  echo "<br>";echo "Ocurrio un error al Insertar en table [bet_det]"; echo "<br>";echo $res_insert_det2;
    //}else{echo "<br>";echo "---Insert con exito [bet_det] ";echo $res_insert_det2;} 
  }catch(Exception $ex){  }
    //*******************  Datos de 3 **********************************
  try{
    $lo3   = $content[$i]->innertext;
    if(($lo3=="España - La Liga")or ($lo3=="Italia - Serie A")or($lo3=="UEFA - Champions League")or($lo3="UEFA - Europa League")){
    $lo3 = $content[$i+2]->innertext;  
    $vi3 = $content[$i+3]->innertext;  $fe3 = $content[$i+4]->innertext; 
    $cl3 = $content[$i+5]->innertext;  $ce3 = $content[$i+6]->innertext;  $cv3 = $content[$i+7]->innertext;$i = $i+6;
    }else{  
    $vi3 = $content[$i+1]->innertext;  $fe3 = $content[$i+2]->innertext; 
    $cl3 = $content[$i+3]->innertext;  $ce3 = $content[$i+4]->innertext;  $cv3 = $content[$i+5]->innertext;$i = $i+6;
    }
  }catch(Exception $ex){  }  
   //*******************************************************
       //*******************  Datos de 4 **********************************
  try{
    $lo4   = $content[$i]->innertext;
    if(($lo4=="España - La Liga")or ($lo4=="Italia - Serie A")or($lo4=="UEFA - Champions League")or($lo4="UEFA - Europa League")){
    $lo4 = $content[$i+2]->innertext;  
    $vi4 = $content[$i+3]->innertext;  $fe4 = $content[$i+4]->innertext; 
    $cl4 = $content[$i+5]->innertext;  $ce4 = $content[$i+6]->innertext;  $cv4 = $content[$i+7]->innertext;$i = $i+6;
    }else{  
    $vi4 = $content[$i+1]->innertext;  $fe4 = $content[$i+2]->innertext; 
    $cl4 = $content[$i+3]->innertext;  $ce4 = $content[$i+4]->innertext;  $cv4 = $content[$i+5]->innertext;$i = $i+6;
    }
  }catch(Exception $ex){  }  
   //*******************************************************

?>
<head>
    <meta charset="UTF-8">
    <title>SCRAPPING WEB</title>
</head>
<body>
<center><div class="Info">
  <?php
    echo "<br>";echo "<p>Informacion de Pinnacle</p>";
    echo $lo1; echo $vi1; echo $fe1; echo "<br>";
    echo $cl1; echo $ce1; echo $cv1; echo "<br>";echo "<br>";
   
    echo $lo2; echo $vi2; echo $fe2; echo "<br>";
    echo $cl2; echo $ce2; echo $cv2; echo "<br>";echo "<br>";

    echo $lo3; echo $vi3; echo $fe3; echo "<br>";
    echo $cl3; echo $ce3; echo $cv3; echo "<br>";echo "<br>";

    echo $lo4; echo $vi4; echo $fe4; echo "<br>";
    echo $cl4; echo $ce4; echo $cv4; echo "<br>";


    echo $filereducido;
    //echo "<br>";echo "<br>";echo "<br>";
    //    foreach($myhtml->find("span") as $content){
    //    echo $content->innertext;
    //    echo "<br>";"<br>";   }
    // $sql_cab = mysqli_query($cn,$selcab);
    //while($r = mysqli_fetch_array($sql_cab)){
  ?>
</div></center>

</body>