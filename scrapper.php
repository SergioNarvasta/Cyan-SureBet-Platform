<?php
   //Install purpeteer with -> npm i puppeteer     // Run node Scrapper_Pinnacle.js  //SELECT * FROM bet_cab A left join bet_det B ON A.idbet = B.idbet;
   include ("simple_html_dom.php");    include ("conexion.php") ;
  $file ="Downloads_Web/Pinnacle.html";
  $filereducido = file_get_contents($file,FALSE,NULL,57761,30800);
  $myhtml = file_get_html($file); $content = $myhtml->find("span") ;  $i = 27;
  $deporte = "Futbol";    $casa ="Pinnacle";
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
   //*******************  Datos de 2 **********************************
  try {
    $idcab2=substr(sha1(time()), 0, 16);
    $lo2   = $content[$i]->innertext;$bus2=strpos($lo2,"UEFA",1);
    if(($lo2=="España - La Liga")or ($lo2=="Italia - Serie A")or($bus2>1)){
    $lo2 = $content[$i+2]->innertext;  
    $vi2 = $content[$i+3]->innertext;  $fe2 = $content[$i+4]->innertext; 
    $cl2 = $content[$i+5]->innertext;  $ce2 = $content[$i+6]->innertext;  $cv2 = $content[$i+7]->innertext;$i = $i+6;
    }else{  
    $vi2 = $content[$i+1]->innertext;  $fe2 = $content[$i+2]->innertext; 
    $cl2 = $content[$i+3]->innertext;  $ce2 = $content[$i+4]->innertext;  $cv2 = $content[$i+5]->innertext;$i = $i+6;
    }
    $insert_cab2 = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES('$idcab2','$deporte','$lo2','$vi2','$fe2',CURRENT_TIME)";
    $res_insert_cab2 = mysqli_query($cn,$insert_cab2);
    if($res_insert_cab2<1){
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_cab]2";echo $res_insert_cab2;
    }else{echo "<br>";echo "---Insert con exito [bet_cab]2"; echo $lo2.$vi2;echo $res_insert_cab2;} 
    
    $insert_det2 = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`)VALUES('$idcab2',NULL,'$casa',$cl2,$ce2,$cv2)";
    $res_insert_det2 = mysqli_query($cn,$insert_det2);
    if($res_insert_det2<1){
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_det]2"; echo "<br>";echo $res_insert_det2;
    }else{echo "<br>";echo "---Insert con exito [bet_det]2 ";echo $res_insert_det2;} 

  }catch(Exception $ex){  }
    //*******************  Datos de 3 **********************************
  try{
    $lo3   = $content[$i]->innertext;   $idcab3=substr(sha1(time()), 0, 16);
    if(($lo3=="España - La Liga")or ($lo3=="Italia - Serie A")or($lo3=="UEFA - Champions League")or($lo3="UEFA - Europa League")){
    $lo3 = $content[$i+4]->innertext;  
    $vi3 = $content[$i+5]->innertext;  $fe3 = $content[$i+6]->innertext; 
    $cl3 = $content[$i+7]->innertext;  $ce3 = $content[$i+8]->innertext;  $cv3 = $content[$i+9]->innertext;$i = $i+6;
    }else{  
    $vi3 = $content[$i+1]->innertext;  $fe3 = $content[$i+2]->innertext; 
    $cl3 = $content[$i+3]->innertext;  $ce3 = $content[$i+4]->innertext;  $cv3 = $content[$i+5]->innertext;$i = $i+6;
    }
    $insert_cab3 = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES('$idcab3','$deporte','$lo3','$vi3','$fe3',CURRENT_TIME)";
    $res_insert_cab3 = mysqli_query($cn,$insert_cab3);
    if($res_insert_cab3<1){
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_cab]3";echo $res_insert_cab3;
    }else{echo "<br>";echo "---Insert con exito [bet_cab]3"; echo $lo3.$vi3;echo $res_insert_cab3;} 
    
    $insert_det3 = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`)VALUES('$idcab3',NULL,'$casa',$cl3,$ce3,$cv3)";
    $res_insert_det3 = mysqli_query($cn,$insert_det3);
    if($res_insert_det3<1){
      echo "<br>";echo "Ocurrio un error al Insertar en table [bet_det]3"; echo "<br>";echo $res_insert_det3;
    }else{echo "<br>";echo "---Insert con exito [bet_det]3 ";echo $res_insert_det3;} 
  }catch(Exception $ex){  }  
   //*******************************************************
       //*******************  Datos de 4 **********************************
  try{
    $lo4   = $content[$i]->innertext;
    if(($lo4=="España - La Liga")or ($lo4=="Italia - Serie A")or($lo4=="UEFA - Champions League")or($lo4="UEFA - Europa League")){
    $lo4 = $content[$i+4]->innertext."Ingreso";  
    $vi4 = $content[$i+5]->innertext;  $fe4 = $content[$i+6]->innertext; 
    $cl4 = $content[$i+7]->innertext;  $ce4 = $content[$i+8]->innertext;  $cv4 = $content[$i+9]->innertext;$i = $i+6;
    }else{  
    $vi4 = $content[$i+1]->innertext;  $fe4 = $content[$i+2]->innertext; 
    $cl4 = $content[$i+3]->innertext;  $ce4 = $content[$i+4]->innertext;  $cv4 = $content[$i+5]->innertext;$i = $i+6;
    }
  }catch(Exception $ex){  }  
   //*******************************************************
          //*******************  Datos de 5 **********************************
  try{
    $lo5   = $content[$i]->innertext;
    if(($lo5=="España - La Liga")or ($lo5=="Italia - Serie A")or($lo5=="UEFA - Champions League")or($lo5="UEFA - Europa League")){
    $lo5 = $content[$i+4]->innertext;  
    $vi5 = $content[$i+5]->innertext;  $fe5 = $content[$i+6]->innertext; 
    $cl5 = $content[$i+7]->innertext;  $ce5 = $content[$i+8]->innertext;  $cv5 = $content[$i+9]->innertext;$i = $i+6;
    }else{  
    $vi5 = $content[$i+1]->innertext;  $fe5 = $content[$i+2]->innertext; 
    $cl5 = $content[$i+3]->innertext;  $ce5 = $content[$i+4]->innertext;  $cv5 = $content[$i+5]->innertext;$i = $i+6;
    }
  }catch(Exception $ex){  } 
  //******************************************************* 
         //*******************  Datos de 6 **********************************
         try{
          $lo6   = $content[$i]->innertext;
          if(($lo6=="España - La Liga")or ($lo6=="Italia - Serie A")or($lo6=="UEFA - Champions League")or($lo6="UEFA - Europa League")){
          $lo6 = $content[$i+4]->innertext;  
          $vi6 = $content[$i+5]->innertext;  $fe6 = $content[$i+6]->innertext; 
          $cl6 = $content[$i+7]->innertext;  $ce6 = $content[$i+8]->innertext;  $cv6 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi6 = $content[$i+1]->innertext;  $fe6 = $content[$i+2]->innertext; 
          $cl6 = $content[$i+3]->innertext;  $ce6 = $content[$i+4]->innertext;  $cv6 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 7 **********************************
         try{
          $lo7   = $content[$i]->innertext;
          if(($lo7=="España - La Liga")or ($lo7=="Italia - Serie A")or($lo7=="UEFA - Champions League")or($lo7="UEFA - Europa League")){
          $lo7 = $content[$i+4]->innertext;  
          $vi7 = $content[$i+5]->innertext;  $fe7 = $content[$i+6]->innertext; 
          $cl7 = $content[$i+7]->innertext;  $ce7 = $content[$i+8]->innertext;  $cv7 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi7 = $content[$i+1]->innertext;  $fe7 = $content[$i+2]->innertext; 
          $cl7 = $content[$i+3]->innertext;  $ce7 = $content[$i+4]->innertext;  $cv7 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 8 **********************************
         try{
          $lo8   = $content[$i]->innertext;
          if(($lo8=="España - La Liga")or ($lo8=="Italia - Serie A")or($lo8=="UEFA - Champions League")or($lo8="UEFA - Europa League")){
          $lo8 = $content[$i+4]->innertext;  
          $vi8 = $content[$i+5]->innertext;  $fe8 = $content[$i+6]->innertext; 
          $cl8 = $content[$i+7]->innertext;  $ce8 = $content[$i+8]->innertext;  $cv8 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi8 = $content[$i+1]->innertext;  $fe8 = $content[$i+2]->innertext; 
          $cl8 = $content[$i+3]->innertext;  $ce8 = $content[$i+4]->innertext;  $cv8 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 9 **********************************
         try{
          $lo9  = $content[$i]->innertext;
          if(($lo9=="España - La Liga")or ($lo9=="Italia - Serie A")or($lo9=="UEFA - Champions League")or($lo9="UEFA - Europa League")){
          $lo9 = $content[$i+4]->innertext;  
          $vi9 = $content[$i+5]->innertext;  $fe9 = $content[$i+6]->innertext; 
          $cl9 = $content[$i+7]->innertext;  $ce9 = $content[$i+8]->innertext;  $cv9 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi9 = $content[$i+1]->innertext;  $fe9 = $content[$i+2]->innertext; 
          $cl9 = $content[$i+3]->innertext;  $ce9 = $content[$i+4]->innertext;  $cv9 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 10 **********************************
         try{
          $lo10  = $content[$i]->innertext;
          if(($lo10=="España - La Liga")or ($lo10=="Italia - Serie A")or($lo10=="UEFA - Champions League")or($lo10="UEFA - Europa League")){
          $lo10 = $content[$i+4]->innertext;  
          $vi10 = $content[$i+5]->innertext;  $fe10 = $content[$i+6]->innertext; 
          $cl10 = $content[$i+7]->innertext;  $ce10 = $content[$i+8]->innertext;  $cv10 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi10 = $content[$i+1]->innertext;  $fe10 = $content[$i+2]->innertext; 
          $cl10 = $content[$i+3]->innertext;  $ce10 = $content[$i+4]->innertext;  $cv10 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 11 **********************************
         try{
          $lo11  = $content[$i]->innertext;
          if(($lo11=="España - La Liga")or ($lo11=="Italia - Serie A")or($lo11=="UEFA - Champions League")or($lo11="UEFA - Europa League")){
          $lo11 = $content[$i+4]->innertext;  
          $vi11 = $content[$i+5]->innertext;  $fe11 = $content[$i+6]->innertext; 
          $cl11 = $content[$i+7]->innertext;  $ce11 = $content[$i+8]->innertext;  $cv11 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi11 = $content[$i+1]->innertext;  $fe11 = $content[$i+2]->innertext; 
          $cl11 = $content[$i+3]->innertext;  $ce11 = $content[$i+4]->innertext;  $cv11 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 12 **********************************
         try{
          $lo12  = $content[$i]->innertext;
          if(($lo12=="España - La Liga")or ($lo12=="Italia - Serie A")or($lo12=="UEFA - Champions League")or($lo12="UEFA - Europa League")){
          $lo12 = $content[$i+4]->innertext;  
          $vi12 = $content[$i+5]->innertext;  $fe12 = $content[$i+6]->innertext; 
          $cl12 = $content[$i+7]->innertext;  $ce12 = $content[$i+8]->innertext;  $cv12 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi12 = $content[$i+1]->innertext;  $fe12 = $content[$i+2]->innertext; 
          $cl12 = $content[$i+3]->innertext;  $ce12 = $content[$i+4]->innertext;  $cv12 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 13 **********************************
         try{
          $lo13  = $content[$i]->innertext;
          if(($lo13=="España - La Liga")or ($lo13=="Italia - Serie A")or($lo13=="UEFA - Champions League")or($lo13="UEFA - Europa League")){
          $lo13 = $content[$i+4]->innertext;  
          $vi13 = $content[$i+5]->innertext;  $fe13 = $content[$i+6]->innertext; 
          $cl13 = $content[$i+7]->innertext;  $ce13 = $content[$i+8]->innertext;  $cv13 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi13 = $content[$i+1]->innertext;  $fe13 = $content[$i+2]->innertext; 
          $cl13 = $content[$i+3]->innertext;  $ce13 = $content[$i+4]->innertext;  $cv13 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 14 **********************************
         try{
          $lo14  = $content[$i]->innertext;
          if(($lo14=="España - La Liga")or ($lo14=="Italia - Serie A")or($lo14=="UEFA - Champions League")or($lo14="UEFA - Europa League")){
          $lo14 = $content[$i+4]->innertext;  
          $vi14 = $content[$i+5]->innertext;  $fe14 = $content[$i+6]->innertext; 
          $cl14 = $content[$i+7]->innertext;  $ce14 = $content[$i+8]->innertext;  $cv14 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi14 = $content[$i+1]->innertext;  $fe14 = $content[$i+2]->innertext; 
          $cl14 = $content[$i+3]->innertext;  $ce14 = $content[$i+4]->innertext;  $cv14 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 15 **********************************
         try{
          $lo15 = $content[$i]->innertext;
          if(($lo15=="España - La Liga")or ($lo15=="Italia - Serie A")or($lo15=="UEFA - Champions League")or($lo15="UEFA - Europa League")){
          $lo15 = $content[$i+4]->innertext;  
          $vi15 = $content[$i+5]->innertext;  $fe15 = $content[$i+6]->innertext; 
          $cl15 = $content[$i+7]->innertext;  $ce15 = $content[$i+8]->innertext;  $cv15 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi15 = $content[$i+1]->innertext;  $fe15 = $content[$i+2]->innertext; 
          $cl15 = $content[$i+3]->innertext;  $ce15 = $content[$i+4]->innertext;  $cv15 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 16 **********************************
         try{
          $lo16  = $content[$i]->innertext; 
          if(($lo16=="España - La Liga")or ($lo16=="Italia - Serie A")or($lo16=="UEFA - Champions League")or($lo16="UEFA - Europa League")){
          $lo16 = $content[$i+4]->innertext;
          $vi16 = $content[$i+5]->innertext;  $fe16 = $content[$i+6]->innertext; 
          $cl16 = $content[$i+7]->innertext;  $ce16 = $content[$i+8]->innertext;  $cv16 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi16 = $content[$i+1]->innertext;  $fe16 = $content[$i+2]->innertext; 
          $cl16 = $content[$i+3]->innertext;  $ce16 = $content[$i+4]->innertext;  $cv16 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 17 **********************************
         try{
          $lo17  = $content[$i]->innertext; $bus=strpos($lo16,"UEFA",1);
          if(($lo17=="España - La Liga")or ($lo17=="Italia - Serie A")or($bus>1)){
          $lo17 = $content[$i+4]->innertext."ingreso";  
          $vi17 = $content[$i+5]->innertext;  $fe17 = $content[$i+6]->innertext; 
          $cl17 = $content[$i+7]->innertext;  $ce17 = $content[$i+8]->innertext;  $cv17 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi17 = $content[$i+1]->innertext;  $fe17 = $content[$i+2]->innertext; 
          $cl17 = $content[$i+3]->innertext;  $ce17 = $content[$i+4]->innertext;  $cv17 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 18 **********************************
         try{
          $lo18  = $content[$i]->innertext;
          if(($lo18=="España - La Liga")or ($lo18=="Italia - Serie A")or($lo18=="UEFA - Champions League")or($lo18="UEFA - Europa League")){
          $lo18 = $content[$i+4]->innertext;  
          $vi18 = $content[$i+5]->innertext;  $fe18 = $content[$i+6]->innertext; 
          $cl18 = $content[$i+7]->innertext;  $ce18 = $content[$i+8]->innertext;  $cv18 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi18 = $content[$i+1]->innertext;  $fe18 = $content[$i+2]->innertext; 
          $cl18 = $content[$i+3]->innertext;  $ce18 = $content[$i+4]->innertext;  $cv18 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 19 **********************************
         try{
          $lo19  = $content[$i]->innertext;
          if(($lo19=="España - La Liga")or ($lo19=="Italia - Serie A")or($lo19=="UEFA - Champions League")or($lo19="UEFA - Europa League")){
          $lo19 = $content[$i+4]->innertext;  
          $vi19 = $content[$i+5]->innertext;  $fe19 = $content[$i+6]->innertext; 
          $cl19 = $content[$i+7]->innertext;  $ce19 = $content[$i+8]->innertext;  $cv19 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi19 = $content[$i+1]->innertext;  $fe19 = $content[$i+2]->innertext; 
          $cl19 = $content[$i+3]->innertext;  $ce19 = $content[$i+4]->innertext;  $cv19 = $content[$i+5]->innertext;$i = $i+6;
          }
        }catch(Exception $ex){  }  
//*******************************************************
         //*******************  Datos de 20 **********************************
         try{
          $lo20  = $content[$i]->innertext;
          if(($lo20=="España - La Liga")or ($lo20=="Italia - Serie A")or($lo20=="UEFA - Champions League")or($lo20="UEFA - Europa League")){
          $lo20 = $content[$i+4]->innertext;  
          $vi20 = $content[$i+5]->innertext;  $fe20 = $content[$i+6]->innertext; 
          $cl20 = $content[$i+7]->innertext;  $ce20 = $content[$i+8]->innertext;  $cv20 = $content[$i+9]->innertext;$i = $i+6;
          }else{  
          $vi20 = $content[$i+1]->innertext;  $fe20 = $content[$i+2]->innertext; 
          $cl20 = $content[$i+3]->innertext;  $ce20 = $content[$i+4]->innertext;  $cv20 = $content[$i+5]->innertext;$i = $i+6;
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
    echo $lo1."  -"; echo $vi1."  -"; echo $fe1; echo "<br>";
    echo $cl1."  -"; echo $ce1."  -"; echo $cv1; echo "<br>";echo "<br>";
   
    echo $lo2."  -";echo strlen($lo2); echo $vi2."  -"; echo $fe2; echo "<br>";
    echo $cl2."  -"; echo $ce2."  -"; echo $cv2; echo "<br>";echo "<br>";

    echo $lo3."  -"; echo $vi3."  -"; echo $fe3; echo "<br>";
    echo $cl3."  -"; echo $ce3."  -"; echo $cv3; echo "<br>";echo "<br>";

    echo $lo4."  -"; echo $vi4."  -"; echo $fe4; echo "<br>";
    echo $cl4."  -"; echo $ce4."  -"; echo $cv4; echo "<br>";echo "<br>";

    echo $lo5."  -"; echo $vi5."  -"; echo $fe5; echo "<br>";
    echo $cl5."  -"; echo $ce5."  -"; echo $cv5; echo "<br>";echo "<br>";

    echo $lo6."  -"; echo $vi6."  -"; echo $fe6; echo "<br>";
    echo $cl6."  -"; echo $ce6."  -"; echo $cv6; echo "<br>";echo "<br>";

    echo $lo7."  -"; echo $vi7."  -"; echo $fe7; echo "<br>";
    echo $cl7."  -"; echo $ce7."  -"; echo $cv7; echo "<br>";echo "<br>";

    echo $lo8."  -"; echo $vi8."  -"; echo $fe8; echo "<br>";
    echo $cl8."  -"; echo $ce8."  -"; echo $cv8; echo "<br>";echo "<br>";
    
    echo $lo9."  -"; echo $vi9."  -"; echo $fe9; echo "<br>";
    echo $cl9."  -"; echo $ce9."  -"; echo $cv9; echo "<br>";echo "<br>";
  
    echo $lo10."  -"; echo $vi10."  -"; echo $fe10; echo "<br>";
    echo $cl10."  -"; echo $ce10."  -"; echo $cv10; echo "<br>";echo "<br>";

    echo $lo11."  -"; echo $vi11."  -"; echo $fe11; echo "<br>";
    echo $cl11."  -"; echo $ce11."  -"; echo $cv11; echo "<br>";echo "<br>";

    echo $lo12."  -"; echo $vi12."  -"; echo $fe12; echo "<br>";
    echo $cl12."  -"; echo $ce12."  -"; echo $cv12; echo "<br>";echo "<br>";
    
    echo $lo13."  -"; echo $vi13."  -"; echo $fe13; echo "<br>";
    echo $cl13."  -"; echo $ce13."  -"; echo $cv13; echo "<br>";echo "<br>";
    
    echo $lo14."  -"; echo $vi14."  -"; echo $fe14; echo "<br>";
    echo $cl14."  -"; echo $ce14."  -"; echo $cv14; echo "<br>";echo "<br>";
    
    echo $lo15."  -"; echo $vi15."  -"; echo $fe15; echo "<br>";
    echo $cl15."  -"; echo $ce15."  -"; echo $cv15; echo "<br>";echo "<br>";
    
    echo $lo16."  -"; echo $vi16."  -"; echo $fe16; echo "<br>";
    echo $cl16."  -"; echo $ce16."  -"; echo $cv16; echo "<br>";echo "<br>";
    
    echo $lo17."  -"; echo $vi17."  -"; echo $fe17; echo "<br>";
    echo $cl17."  -"; echo $ce17."  -"; echo $cv17; echo "<br>";echo "<br>";
    
    echo $lo18."  -"; echo $vi18."  -"; echo $fe18; echo "<br>";
    echo $cl18."  -"; echo $ce18."  -"; echo $cv18; echo "<br>";echo "<br>";
    
    echo $lo19."  -"; echo $vi19."  -"; echo $fe19; echo "<br>";
    echo $cl19."  -"; echo $ce19."  -"; echo $cv19; echo "<br>";echo "<br>";
    
    echo $lo20."  -"; echo $vi20."  -"; echo $fe20; echo "<br>";
    echo $cl20."  -"; echo $ce20."  -"; echo $cv20; echo "<br>";echo "<br>";


    echo $filereducido;
  
  ?>
</div></center>

</body>