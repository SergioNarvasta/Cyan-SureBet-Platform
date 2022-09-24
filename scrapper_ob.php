<?php
  include ("simple_html_dom.php");   include ("conexion.php");
  //DELETE FROM bet_cab A WHERE A.fecreg < CURRENT_TIME   //SELECT * FROM bet_cab A left join bet_det B ON A.idcab = B.idcab
    $file ="Downloads_Web/OnceBet.html";
    $filereducido = file_get_contents($file,FALSE,NULL,101000,150000);
    $myhtml  = file_get_html($file);   $content = $myhtml->find("div");
    $deporte = "Futbol";               $casa ="OnceBet";

  function insertData($file){
    $myhtml  = file_get_html($file);   //$content = $myhtml->find('quotation_box_1_data_body'); quotation_box_1_data_body
    foreach($myhtml->find("quotation_box_1_data_body") as $content){
      echo $content->innertext;
      echo "<br>";  
    }
  }

  function usingDOM($file){
    /*$doc = new DomDocument;          
    @$doc->loadHTMLFile($file);
    $info = $doc->getElementById('quotation_box_1_data_body');
    $label = $info->getElementsByTagName('cell label',)->item(0)->nodeValue.'';
    echo $label;*/
  }
  function insertBet($cn,$file,$i,$n){
    $myhtml  = file_get_html($file);   $content = $myhtml->find("div");   $content_c = $myhtml->find("span"); 
    $deporte = "Futbol";               $casa = "OnceBet";                 $idcab = substr(sha1(time()), 0, 16);
    $ini  = $content[$i]->innertext;         //$bus  = strpos($ini,"UEFA",1);
    
    //Corta la cadena                               //busca la posicion          
    // try{ $fe = str_replace(" ","",substr($ini,1,14));  }catch(Exception $e) {}   try{ $bcar  = strpos($ini,"-",1); }catch(Exception $e) {}
    //$lo = str_replace(" ","",substr($ini,15,$bcar-15));   $vi = str_replace(" ","",substr($ini,$bcar+2,20));
  
    $cl = $content_c[$n-169]->innertext;  
    $ce = $content_c[$n-168]->innertext;  
    $cv = $content_c[$n-167]->innertext;
      echo $ini; 
      //echo " ".$lo." ";        echo "** ".$vi." ";     echo " **".$fe;echo "<br>";
      echo "Cl ".$cl." ";      echo "Ce ".$ce."";      echo "Cv ".$cv;
      /*$insert_cab = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`) VALUES('$idcab','$deporte','$lo','$vi','$fe',CURRENT_TIME)";
      $res_insert_cab = mysqli_query($cn,$insert_cab);
      if($res_insert_cab<1){
        echo "<br>";echo "--Error [bet_cab]";
      }else{echo "<br>";echo "--Exito [bet_cab]"; echo $lo.$vi;} 
      
      $insert_det = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`,`fecreg`)VALUES('$idcab',NULL,'$casa',$cl,$ce,$cv,CURRENT_TIME)";
      $res_insert_det1 = mysqli_query($cn,$insert_det);
      if($res_insert_det1<1){
        echo "<br>";echo "--Error [bet_det]";
      }else{echo "<br>";echo "--Exito [bet_det] ";} */  
  }
?>   
<center><div>
<?php 
try{  
  /*
  //$r=175;  $val=$content[$r]->innertext;  $bus=strpos($val,"Fútbol",1);  $bus22=strpos($val,"22",1);
  if($bus>1){
    insertBet($cn,$file,$r+63,$r+10);echo "<br>";echo "<br>";//Saltea66
  }else{ if($bus22>1){insertBet($cn,$file,$r+44,$r+10);echo "<br>";echo "<br>";}
         else{insertBet($cn,$file,$r+66,$r+10);echo "<br>";echo "<br>";}
        }         
  insertBet($cn,$file,181,175);echo "<br>";echo "<br>";// Flujo Normal es 44, i=175 antes ..ahora 177
  insertBet($cn,$file,224,184);echo "<br>";echo "<br>";
  insertBet($cn,$file,268,194);echo "<br>";echo "<br>";//If Competicion 66
  $s=268;$s4=44;$s6=66;
  insertBet($cn,$file,$s+$s6,204);echo "<br>";echo "<br>";//Sigue 44...
  insertBet($cn,$file,($s+$s6)+$s4,215);echo "<br>";echo "<br>";
  insertBet($cn,$file,414,225);echo "<br>";echo "<br>";
  insertBet($cn,$file,458,235);echo "<br>";echo "<br>";
  insertBet($cn,$file,521,245);echo "<br>";echo "<br>";//If 63 Ligue1
  insertBet($cn,$file,565,255);echo "<br>";echo "<br>";//Sigue 44...
  insertBet($cn,$file,609,265);echo "<br>";echo "<br>";
  insertBet($cn,$file,653,275);echo "<br>";echo "<br>";
  insertBet($cn,$file,697,285);echo "<br>";echo "<br>";
  insertBet($cn,$file,741,295);echo "<br>";echo "<br>";
  insertBet($cn,$file,785,305);echo "<br>";echo "<br>";
  insertBet($cn,$file,851,315);echo "<br>";echo "<br>";//If 63 SerieA 
  insertBet($cn,$file,892,325);echo "<br>";echo "<br>";
  insertBet($cn,$file,936,335);echo "<br>";echo "<br>";
  insertBet($cn,$file,980,345);echo "<br>";echo "<br>";
  */
}catch(Exception $e) {}
  insertData($file);
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