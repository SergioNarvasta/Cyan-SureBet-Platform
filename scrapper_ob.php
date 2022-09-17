<?php
       include ("simple_html_dom.php");

        $file2 ="Downloads_Files/OnceBet.html";
        $filereducido = file_get_contents($file2,FALSE,NULL,76000,123000);
        $myhtml = file_get_html($file2);
        $content = $myhtml->find("div") ;  $i = 3;
        $deporte = "Futbol";    $casa ="OnceBet";
        $a= $content[$i]->innertext; 
        $b= $content[$i+2]->innertext; 
        $c= $content[$i+3]->innertext; 
        $lo1= $content[$i+4]->innertext;
          //*******************  Datos de 1 **********************************
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
<center>  <div>
<?php //}  
        echo "<br>";echo "<p>Informacion de OnceBet</p>";
          
        echo $a; echo "<br>"; echo $b; echo "<br>"; echo $c;echo "<br>"; echo $lo1;  echo "<br>";
        $deporte_ch = "Futbol";
        //*******************  Datos de 1 **********************************
        foreach($myhtml->find("div") as $content){
            //  echo $content->innertext;
            //  echo "<br>";"<br>";   
        }
       echo $filereducido;
       
    
    ?>
</div></center>