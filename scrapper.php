<?php
   //Install purpeteer with -> npm i puppeteer     // Run node Scrapper_Pinnacle.js  
   //SELECT * FROM bet_cab A left join bet_det B ON A.idcab = B.idcab;
   include ("simple_html_dom.php");      include ("conexion.php") ;
  $file ="Downloads_Web/Pinnacle.html";  $casa ="Pinnacle";
  $filereducido = file_get_contents($file,FALSE,NULL,57761,30800);
  $myhtml = file_get_html($file); $content = $myhtml->find("span");
   
  function fx_todo($file,$fin){
    $myhtml = file_get_html($file); $data = $myhtml->find("span");
    $con = 0;
    echo "<p>Mostrando toda la Informacion de span  </p>";
    foreach($myhtml->find("span") as $content){
      $con++;
      if($con<$fin){
        $lo = $data[$con]->innertext;  $type=settype($lo,"string"); 
        echo $con."-->".$lo;echo "<br>";
      }
    }
  }
  function fx_Bet($cn,$file,$fin){
    $myhtml = file_get_html($file); $con = 0; $data = $myhtml->find("span"); 
    $deporte = "Futbol";                  $casa = "Pinnacle";  
    $array = [];  $aux=0;
    foreach($myhtml->find("span") as $content){
      $con++;
      if($con<$fin){
      $main = $content->innertext;  $type=settype($main,"string"); 
      $buscuota = strpos($main,"Cuota",0); //Si encuentra el flag graba info en variables
      if($buscuota>1){
        array_push($array,$con+4); 
       //echo $con."--Encontrado Guion".$lo;echo "<br>";
        foreach($myhtml->find("span") as $content2){ //for para iterara todos los registros
          $aux++; $nv=$array[0];
          if($aux<$fin){
            $test = $data[$nv]->innertext;  $busguion = strpos($test,"-",0); $filtro = strpos($test,"apuestas",0);
            $span=htmlentities($test, ENT_QUOTES); $busspan= strpos($span,"span",0);
            if($busguion>1 and $filtro==false and $busspan==false){
              $array[0] = $nv+2;   $nv=$array[0];
            }
            $lo = $data[$nv]->innertext; $vi = $data[$nv+1]->innertext;  $fe = $data[$nv+2]->innertext;
            $cl=$data[$nv+3]->innertext; $ce = $data[$nv+4]->innertext;  $cv = $data[$nv+5]->innertext;
            $idcab = substr(substr($lo,0,8).substr($vi,0,8),0,16);
            $array[0] = $nv+6;

            /*$insert_cab = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`)VALUES('$idcab','$deporte','$lo','$vi','$fe',CURRENT_TIME)";
              $res_insert_cab = mysqli_query($cn,$insert_cab);
              if($res_insert_cab<1){
                echo "<br>";echo "--Error [bet_cab]";
              }else{
                echo "<br>";echo "--Exito [bet_cab]"; echo $lo.$vi;
              }
            
            $insert_det = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`,`fecreg`)VALUES('$idcab',NULL,'$casa',$cl,$ce,$cv,CURRENT_TIME)";
            $res_insert_det = mysqli_query($cn,$insert_det);
              if($res_insert_det<1){
                echo "<br>";echo "--Error [bet_det]";
              }else{
                echo "<br>";echo "--Exito [bet_det] ";
              }*/
            echo $lo."  -"; echo $vi."  -"; echo $fe; echo "<br>";
            echo $cl."  -"; echo $ce."  -"; echo $cv; echo "<br>";echo "<br>"; 
          }
        }
      } 
    }}
  }
?>
<head>
    <meta charset="UTF-8">
    <title>SCRAPPING WEB</title>
</head>
<body>
<center><div class="Info">
  <?php
    fx_todo($file,153);
    echo "<br>";echo "<p>---------------------</p>";
    fx_Bet($cn,$file,153);
    echo "<br>";echo "<p>Informacion de Pinnacle</p>";
    
    //echo $filereducido;
  ?>
</div></center>

</body>