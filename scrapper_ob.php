<?php
  include ("simple_html_dom.php");   include ("conexion.php");
  //DELETE FROM bet_cab A WHERE A.fecreg < CURRENT_TIME   //SELECT * FROM bet_cab A left join bet_det B ON A.idcab = B.idcab
  $file ="Downloads_Web/OnceBet.html"; $casa ="OnceBet";
  $filereducido = file_get_contents($file,FALSE,NULL,101000,150000);
  $myhtml  = file_get_html($file);   $content = $myhtml->find("div");  $content_c = $myhtml->find("span");  
  $keys = []; $idcab = substr(sha1(time()), 0, 16);
  function usingDOM(){
    /*$doc = new DomDocument;          
    @$doc->loadHTMLFile($file);
    $info = $doc->getElementById('quotation_box_1_data_body');
    $label = $info->getElementsByTagName('cell label',)->item(0)->nodeValue.'';
    echo $label;*/
  }
  function fx_todo($file,$fin){
     $myhtml = file_get_html($file); $data = $myhtml->find("span"); $con = 0;
     echo "<p>Mostrando toda la Informacion de span  </p>";
     foreach($myhtml->find("span") as $content){
       $con++;
       if($con<$fin){
         $lo = $data[$con]->innertext; settype($lo,"string"); 
         echo $con."-->".$lo;echo "<br>";
       }
     }
   }
  function fx_insertBet($cn,$ini,$cuo){
    $file ="Downloads_Web/OnceBet.html";  $myhtml=file_get_html($file);  $con=0;  
    $content=$myhtml->find("div"); $content_c = $myhtml->find("span");  
    $deporte = "Futbol";                  $casa = "OnceBet";             
    $array = [];                          array_push($array,$cuo);       $valida=0;
    for($n=$ini;$n<=160,$n++;){                             
      //if($n<$fin){
      $dat = $content[$n]->innertext; settype($dat,"string");  
      $bus22=strpos($dat,"22",0);  $busma=strpos($dat,"+",0);  $busg=strpos($dat,"-",0);  $busot=strpos($dat,"Tinco",0); 
      $enti=htmlentities($dat, ENT_QUOTES); $busdiv= strpos($enti,"div",0);
        if($bus22>1 and $busma==false and $busg>1 and $busot==false and strlen($dat)>30 and $busdiv==false){ 
          //echo "--Contador ".$con."--";echo $dat;echo "<br>";
          $fe = substr($dat,0,14);          $bcar = strpos($dat,"-",1);
          $lo = substr($dat,15,$bcar-15);   $vi   = substr($dat,$bcar+2,20);
          $idcab = substr(substr($lo,0,8).substr($vi,0,8),0,16);
          echo $lo;      echo "-".$vi." ";      echo "-".$fe;   echo "<br>";
          /*$insert_cab = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`)
                         VALUES('$idcab','$deporte','$lo','$vi','$fe',CURRENT_TIME)";
          $res_insert_cab = mysqli_query($cn,$insert_cab);
          if($res_insert_cab<1){
            echo "<br>";echo "--Error [bet_cab]";
          }else{
          echo "<br>";echo "--Exito [bet_cab]"; echo $lo.$vi;
          }*/
            
          $nv=$array[0];  $valida++; settype($dat,"string"); 
          if($nv<500){
            $cl=$content_c[$nv]->innertext;  $ce=$content_c[$nv+1]->innertext;  $cv=$content_c[$nv+2]->innertext;
            $bus1=strpos($cl,"refresh",0);   $bus2=strpos($ce,"LIVE",0); $bus3=strpos($cv,"Registrarse",0);
            if($bus1==false or $bus2==false or $bus3==false){ $con++; //Contador asigna limite a 13
              if($con<50){ 
                echo $valida."-"."Cl ".$cl;      echo "Ce ".$ce;      echo "Cv ".$cv;    echo "<br>";  
                /*$insert_det = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`,`fecreg`)
                               VALUES('$idcab',NULL,'$casa',$cl,$ce,$cv,CURRENT_TIME)";
                $res_insert_det1 = mysqli_query($cn,$insert_det);
                if($res_insert_det1<1){
                  echo "<br>";echo "--Error [bet_det]";
                }else{
                  echo "<br>";echo "--Exito [bet_det] ";
                }*/
                if($valida>22 ){
                  $array[0] = $nv+9;
                }else {
                  $array[0] = $nv+10;
                }
              }
            } 
          }else echo" ";
        }
    }
  }
  //try{} catch(Exception $e){echo 'Excepción capturada: ',  $e->getMessage(), "\n";}finally {echo "Finally.\n";}
?>   
<center><div>
  <button><a href="operaciones.php">Volver</a> </button> <br> <br>
  <title>Scraping Web</title>
<?php 
  //fx_todo($file,100);
  echo "<p>Informacion de $casa</p>";
  fx_insertBet($cn,154,6);
  
  /* foreach($myhtml->find("span") as $content){
      echo " ".$content->innertext;
      echo "<br>";  
   }*/
  
  //echo $filereducido;
?>
</div> </center>