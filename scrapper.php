<?php
   //Install purpeteer with -> npm i puppeteer
   // Run node Scrapper_Pinnacle.js
   //style_row__3q4g_ style_row__3hCMX
   include ("simple_html_dom.php");    include ("conexion.php") ;
   //SELECT * FROM bet_cab A left join bet_det B ON A.idbet = B.idbet;
   // INSERT INTO bet_cab(`idbet`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES(001,'Futbol','Marseille','Eintracht Frankfurt','9/13/2022 14:00',CURRENT_TIME)
  $file ="Downloads_Files/Pinnacle2.html";
  $filereducido = file_get_contents($file,FALSE,NULL,57761,30800);
  $myhtml = file_get_html($file);
  $content = $myhtml->find("span") ;  $i = 27;
  $deporte = "Futbol";
  //*******************  Datos de 1 **********************************
  $lo1   = $content[$i]->innertext;
  if(Empty($lo1) or $lo1 >0){
    $lo1   = $content[$i+1]->innertext;  $vi1  = $content[$i+2]->innertext;  $fe1  = $content[$i+3]->innertext; 
  }
  $vi1  = $content[$i+1]->innertext;
  $fe1  = $content[$i+2]->innertext;
  $cl1 = $content[$i+3]->innertext;
  if($cl1=="Ver porcentaje de apuestas"){
    $cl1 = $content[$i+4]->innertext;   $ce1 = $content[$i+5]->innertext;    $cv1 = $content[$i+6]->innertext;
  }else{
    $ce1 = $content[$i+4]->innertext;   $cv1 = $content[$i+5]->innertext;    $i = $i+6;
  }
   //*******************  Datos de 2 **********************************
   $lo2   = $content[$i]->innertext;
   //if(Empty($lo2) or $lo2 >0){
   //$lo2   = $content[$i+1]->innertext;  $vi2  = $content[$i+2]->innertext;  $fe2  = $content[$i+3]->innertext; }
   $vi2  = $content[$i+1]->innertext;
   $fe2  = $content[$i+2]->innertext;
   $cl2 = $content[$i+3]->innertext;
   if($cl2=="Ver porcentaje de apuestas"){
     $cl2 = $content[$i+4]->innertext;   $ce2 = $content[$i+5]->innertext;    $cv2 = $content[$i+6]->innertext;
   }else{
     $ce2 = $content[$i+4]->innertext;   $cv2 = $content[$i+5]->innertext;    $i = $i+6;
   }
    //*******************  Datos de 3 **********************************
    $lo3   = $content[$i]->innertext;
    //if(Empty($lo1) or $lo1 >0){
    //  $lo3   = $content[$i+1]->innertext;  $vi3  = $content[$i+2]->innertext;  $fe3  = $content[$i+3]->innertext; }
    $vi3  = $content[$i+1]->innertext;
    $fe3  = $content[$i+2]->innertext;
    $cl3  = $content[$i+3]->innertext;
    if($cl3=="Ver porcentaje de apuestas"){
      $cl3 = $content[$i+4]->innertext;   $ce3 = $content[$i+5]->innertext;    $cv3 = $content[$i+6]->innertext;
    }else{
      $ce3 = $content[$i+4]->innertext;   $cv3 = $content[$i+5]->innertext;    $i = $i+5;
    }
    //************************ SCRAPING WEB CHASKIBET 
        
   //*******************************************************
 //$sql = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES(NULL,$deporte,$local,$visita,$feceve,CURRENT_TIME)";
 //$insert = mysqli_query($cn,$sql);
 //$selcab = "SELECT*FROM bet_cab A WHERE A.local=$local AND A.visita =$visita  AND A.feceve =$feceve ";
?>
<head>
    <meta charset="UTF-8">
    <title>SCRAPPING WEB</title>
</head>
<body>
<center><div class="Info">
  <?php
    echo "<br>";echo "<p>Informacion de Pinnacle</p>";
    echo $lo1;  echo "<br>"; echo $vi1; echo "<br>";
    echo $fe1; echo "<br>";
    echo $cl1;echo "<br>";  echo $ce1 ;echo "<br>"; echo $cv1;echo "<br>";echo "<br>";

    echo $lo2;  echo "<br>"; echo $vi2; echo "<br>";
    echo $fe2; echo "<br>";
    echo $cl2;echo "<br>"; echo $ce2 ;echo "<br>"; echo $cv2;echo "<br>";echo "<br>";

    echo $lo3;  echo "<br>";echo $vi3; echo "<br>";
    echo $fe3; echo "<br>";
    echo $cl3;echo "<br>"; echo $ce3 ;echo "<br>"; echo $cv3;echo "<br>";echo "<br>";
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