<?php
  include ("simple_html_dom.php");   include ("conexion.php");
  //DELETE FROM bet_cab A WHERE A.fecreg < CURRENT_TIME   //SELECT * FROM bet_cab A left join bet_det B ON A.idcab = B.idcab
    $file ="Downloads_Web/OnceBet.html";
    $filereducido = file_get_contents($file,FALSE,NULL,76000,123000);
    $myhtml  = file_get_html($file);   $content = $myhtml->find("div");
    $deporte = "Futbol";               $casa ="OnceBet";

  function insertBet($cn,$file,$i){
    $myhtml  = file_get_html($file);   $content = $myhtml->find("div");  $content_c = $myhtml->find("span"); 
    $deporte = "Futbol";               $casa = "OnceBet";                 $idcab = substr(sha1(time()), 0, 16);
    $ini  = $content[$i]->innertext;   //$bus  = strpos($ini,"UEFA",1);
    
    //Corta la cadena          //busca la posicion              //Corta la cadena inicial desde 14 hasta la pos(bcar)
    $fe = substr($ini,1,14);    $bcar  = strpos($ini,"-",1);   $lo = substr($ini,15,$bcar-15);   $vi = substr($ini,$bcar+2,15);

    $cl = $content_c[$i-169]->innertext;  $ce = $content_c[$i-168]->innertext;  $cv = $content_c[$i-167]->innertext;
       
      echo "Local ".$lo." -";       echo "Visita ".$vi." ";       echo "Fecha ".$fe;echo "<br>";
      echo "Cuota_Local ".$cl." -"; echo "Cuota_Empate ".$ce." -"; echo "Cuota_Visita ".$cv;
     /* $insert_cab = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES('$idcab','$deporte','$lo','$vi','$fe',CURRENT_TIME)";
      $res_insert_cab = mysqli_query($cn,$insert_cab);
      if($res_insert_cab<1){
        echo "<br>";echo "--Ocurrio un error al Insertar [bet_cab]";
      }else{echo "<br>";echo "---Insert con exito [bet_cab]"; echo $lo.$vi;} 
      
      $insert_det = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`,`fecreg`)VALUES('$idcab',NULL,'$casa',$cl,$ce,$cv,CURRENT_TIME)";
      $res_insert_det1 = mysqli_query($cn,$insert_det);
      if($res_insert_det1<1){
        echo "<br>";echo "--Ocurrio un error al Insertar [bet_det]";
      }else{echo "<br>";echo "---Insert con exito [bet_det] ";} 
      */
  }
?>   
<center><div>
<?php //}  
  insertBet($cn,$file,175);echo "<br>";
  insertBet($cn,$file,185);echo "<br>";
  echo "<p>Informacion de $casa</p>";

  //insertBet($cn,$file,8); insertBet($cn,$file,14); 
  //Recorrer archivo y mostrar su contenido
  /* foreach($myhtml->find("div") as $content){
      echo $content->innertext;
      echo "<br>";  
   }
  */ 
   echo $filereducido;
?>
</div></center>