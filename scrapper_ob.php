<?php
  include ("simple_html_dom.php");   include ("conexion.php");
  //DELETE FROM bet_cab A WHERE A.fecreg < CURRENT_TIME   //SELECT * FROM bet_cab A left join bet_det B ON A.idcab = B.idcab
    $file ="Downloads_Web/OnceBet.html";
    $filereducido = file_get_contents($file,FALSE,NULL,101000,150000);
    $myhtml  = file_get_html($file);   $content = $myhtml->find("div");  $content_c = $myhtml->find("span");  
    $deporte = "Futbol";               $casa ="OnceBet";

  function usingDOM(){
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
  function fx_lee($ini,$fin,$cuo){
    $file ="Downloads_Web/OnceBet.html";  $myhtml=file_get_html($file);  $con=0;  
    $content=$myhtml->find("div"); $content_c = $myhtml->find("span");  
    $deporte = "Futbol";                  $casa = "OnceBet";             $idcab = substr(sha1(time()), 0, 16);
    $array = [];                          array_push($array,$cuo);       $valida=0;
    for($n=$ini;$n<=160,$n++;){           $con++;
      if($n<$fin){
        $dat = $content[$n]->innertext;     $type=settype($dat,"string");  
        if($type==true){ 
          $bus22=strpos($dat,"22",0);       $busma=strpos($dat,"+",0);     $busg=strpos($dat,"-",0);     $busot=strpos($dat,"Tinco",0); 
          $enti=htmlentities($dat, ENT_QUOTES); $busdiv= strpos($enti,"div",0);
          if($bus22>1 and $busma==false and $busg>1 and $busot==false and strlen($dat)>30 and $busdiv==false){ 
            //echo "--Contador ".$con."--";echo $dat;echo "<br>";
            $fe = substr($dat,1,14);          $bcar = strpos($dat,"-",1);
            $lo = substr($dat,15,$bcar-15);   $vi   = substr($dat,$bcar+2,20);
            echo $lo;      echo "** ".$vi." ";      echo " **".$fe;   echo "<br>";  
            
          }   
        }
      } 
      $nv=$array[0];  $valida++; $type=settype($dat,"string"); 
          if($nv<164){
            $cl=$content_c[$nv]->innertext;  $ce=$content_c[$nv+1]->innertext;  $cv=$content_c[$nv+2]->innertext;
            $bus1=strpos($cl,"refresh",0);   $bus2=strpos($ce,"LIVE",0); $bus3=strpos($cv,"Registrarse",0);
            if($bus1==false or $bus2==false or $bus3==false){
              echo $valida."Cl ".$cl;      echo "Ce ".$ce;      echo "Cv ".$cv;    echo "<br>";  
              if($valida>1){
                $array[0] = $nv+10;
              }else{
                $array[0] = $nv+9;
              }
            } 
          }else echo" ";
    }
  
  }
  //try{}< catch(Exception $e){echo 'Excepción capturada: ',  $e->getMessage(), "\n";}finally {echo "Finally.\n";}
?>   
<center><div>
  <button><a href="operaciones.php">Volver</a> </button> <br> <br>
<?php 
  /*        
  insertBet($cn,$file,181,175);echo "<br>";echo "<br>";// Flujo Normal es 44, i=175 antes ..ahora 177
  insertBet($cn,$file,224,184);echo "<br>";echo "<br>";
  insertBet($cn,$file,268,194);echo "<br>";echo "<br>";//If Competicion 66
  */
  fx_lee(154,1000,5);
  echo "<p>Informacion de $casa</p>";

  //insertBet($cn,$file,8); insertBet($cn,$file,14); 
  /*Recorrer archivo y mostrar su contenido
   foreach($myhtml->find("span") as $content){
      echo " ".$content->innertext;
      echo "<br>";  
   }*/
   
    $cl = $content_c[24]->innertext;  //1. 567 2. 14 15 16 3. 24 25 26
    $ce = $content_c[25]->innertext;  
    $cv = $content_c[26]->innertext;
    //echo "Cl ".$cl." ";      echo "Ce ".$ce."";      echo "Cv ".$cv; echo "<br>";  
  
  echo $filereducido;
?>
</div> </center>