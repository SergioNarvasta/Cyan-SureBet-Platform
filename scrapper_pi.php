<?php
  include ("simple_html_dom.php");      include ("conexion.php") ;

  function fx_todo($file,$fin){
   /* $myhtml = file_get_html($file); $data = $myhtml->find("span");
    $con = 0;
    echo "<p>Mostrando toda la Informacion de span  </p>";
    foreach($myhtml->find("span") as $content){
      $con++;
      if($con<$fin){
        $lo = $data[$con]->innertext;  $type=settype($lo,"string"); 
        echo $con."-->".$lo;echo "<br>";
      }
    }*/
  }
  function fx_redirect_operaciones($cn){
    $sqlpi = "SELECT * FROM bet_cab A LEFT JOIN bet_det B ON A.idcab = B.idcab 
     WHERE B.idcab IS NOT NULL AND B.casa='Pinnacle' AND DAY(A.fecreg) = DAY(CURRENT_TIME)"; 
    $sqlob = "SELECT * FROM bet_cab A LEFT JOIN bet_det B ON A.idcab = B.idcab 
     WHERE B.idcab IS NOT NULL AND B.casa='OnceBet' AND DAY(A.fecreg) = DAY(CURRENT_TIME)"; 
    $sqldata="SELECT a.local,a.visita,a.feceve ,b.casa,b.cuota_local,b.cuota_empate,b.cuota_visita,b.fecreg FROM bet_cab A 
               LEFT JOIN bet_det B ON A.idcab = B.idcab WHERE B.idcab IS NOT NULL";
    $data =mysqli_query($cn,$sqldata);
    $datapi=mysqli_query($cn,$sqlpi); $dataob=mysqli_query($cn,$sqlob);
    $cantpi=mysqli_num_rows($datapi); 
    $cantob=mysqli_num_rows($dataob); 
    header("Location: operaciones.php?cpi=$cantpi&cob=$cantob");
      /*echo "<center><div>";
        while($r = mysqli_fetch_array($data)) {
        echo $r["local"]; echo $r["visita"]; echo $r["feceve"]; echo $r["casa"]; echo "<br>";
        echo $r["cuota_local"]; echo $r["cuota_empate"];  echo $r["cuota_visita"]; echo $r["fecreg"];
        echo "<br>";echo "<br>";
      }   
      echo "</div></center>"; */
  }
  function fx_insertPinnacle($cn,$fin){
    $file ="Downloads_Web/Pinnacle.html";  
    $myhtml = file_get_html($file); $con = 0; $data = $myhtml->find("span"); 
    $deporte = "Futbol";                  $casa = "Pinnacle";  
    $array = [];  $aux=0;
    foreach($myhtml->find("span") as $content){
      $con++;
      if($con<$fin){
      $main = $content->innertext;  settype($main,"string"); 
      $buscuota = strpos($main,"Cuota",0); //Si encuentra el flag graba info en variables
      if($buscuota>1){
        array_push($array,$con+4); 
        //echo $con."--Encontrado Guion".$lo;echo "<br>";
        foreach($myhtml->find("span") as $content2){ //for para iterara todos los registros
          $aux++; $nv=$array[0];
          if($nv<$fin){  
            $test = $data[$nv]->innertext;  $busguion = strpos($test,"-",0); $busApuestas = strpos($test,"puesta",0);$bussocios = strpos($test,"ocios",0);
            $span=htmlentities($test,ENT_QUOTES); $busspan= strpos($span,"span",0); $img =htmlentities($test, ENT_QUOTES); $busimg = strpos($img,"img",0);
              if($busguion>1 ){
                $array[0] = $nv+2;   $nv=$array[0];
              }
              $lo = $data[$nv]->innertext; $vi = $data[$nv+1]->innertext;  $fe = $data[$nv+2]->innertext;
              $cl=$data[$nv+3]->innertext; $ce = $data[$nv+4]->innertext;  $cv = $data[$nv+5]->innertext;
              $idcab = "Pi".substr(substr($lo,0,7).substr($vi,0,7),0,14);
              $array[0] = $nv+6;
              //Filtra si encuentra en su estructura: Apuestas, span ,div 
                if($busApuestas==false AND $busspan==false AND $busimg==false AND $bussocios==false){
                  $insert_cab = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`)
                                  VALUES('$idcab','$deporte','$lo','$vi','$fe',CURRENT_TIME)";
                  $res_insert_cab = mysqli_query($cn,$insert_cab);
                  if($res_insert_cab<1){
                    //echo "<br>";echo "--Error [bet_cab]";
                  }else{
                    //echo "<br>";echo "--Exito [bet_cab]";
                  }
                  $insert_det = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`,`fecreg`)
                                  VALUES('$idcab',NULL,'$casa',$cl,$ce,$cv,CURRENT_TIME)";
                  $res_insert_det = mysqli_query($cn,$insert_det);
                  if($res_insert_det<1){
                    //echo "--Error [bet_det]";echo "<br>";
                  }else{
                    //echo "--Exito [bet_det] ";echo "<br>";
                  }
              //echo $lo."  -"; echo $vi."  -"; echo $fe; echo "<br>";
              //echo $cl."  -"; echo $ce."  -"; echo $cv; echo "<br>";echo "<br>"; 
            }
          }
        }
      } 
    }}
  }
  function fx_insertOnceBet($cn,$ini,$fin,$cuo){
    $file ="Downloads_Web/OnceBet.html";  $myhtml=file_get_html($file);  $con=0;  
    $content=$myhtml->find("div"); $content_c = $myhtml->find("span");  
    $deporte = "Futbol";                  $casa = "OnceBet";             
    $array = [];                          array_push($array,$cuo);       $valida=0;
    for($n=$ini;$n<=$fin,$n++;){                             
      if($n<$fin){  fx_redirect_operaciones($cn);}else{         //Redirige a operaciones.php
      $dat = $content[$n]->innertext; settype($dat,"string");  
      $bus22=strpos($dat,"22",0);  $busma=strpos($dat,"+",0);  $busg=strpos($dat,"-",0);  $busot=strpos($dat,"Tinco",0); 
      $enti=htmlentities($dat, ENT_QUOTES); $busdiv= strpos($enti,"div",0);
        if($bus22>1 and $busma==false and $busg>1 and $busot==false and strlen($dat)>30 and $busdiv==false){ 
          //echo "--Contador ".$con."--";echo $dat;echo "<br>";
          $fe = substr($dat,0,14);          $bcar = strpos($dat,"-",1);
          $lo = substr($dat,15,$bcar-15);   $vi   = substr($dat,$bcar+2,20);
          $idcab = "Ob".substr(substr($lo,0,7).substr($vi,0,7),0,14);
          //echo $lo;      echo "-".$vi." ";      echo "-".$fe;  
          $insert_cab = "INSERT INTO bet_cab(`idcab`,`deporte`,`local`,`visita`,`feceve`,`fecreg`)
                         VALUES('$idcab','$deporte','$lo','$vi','$fe',CURRENT_TIME)";
          $res_insert_cab = mysqli_query($cn,$insert_cab);
          if($res_insert_cab<1){
            //echo "--Error [bet_cab]";echo "<br>";
          }else{
            //echo "--Exito [bet_cab]";echo "<br>";
          }     
          $nv=$array[0];  $valida++; settype($dat,"string"); 
          if($nv<500){
            $cl=$content_c[$nv]->innertext;  $ce=$content_c[$nv+1]->innertext;  $cv=$content_c[$nv+2]->innertext;
            $bus1=strpos($cl,"refresh",0);   $bus2=strpos($ce,"LIVE",0); $bus3=strpos($cv,"Registrarse",0);
            if($bus1==false or $bus2==false or $bus3==false){ $con++; //Contador asigna limite a 13
              if($con<50){ 
                //echo $valida."-"."Cl ".$cl;      echo "Ce ".$ce;      echo "Cv ".$cv;  
                $insert_det = "INSERT INTO bet_det(`idcab`,`iddet`,`casa`,`cuota_local`,`cuota_empate`,`cuota_visita`,`fecreg`)
                               VALUES('$idcab',NULL,'$casa',$cl,$ce,$cv,CURRENT_TIME)";
                $res_insert_det1 = mysqli_query($cn,$insert_det);
                if($res_insert_det1<1){
                  //echo "--Error [bet_det]";echo "<br>";
                }else{
                  //echo "--Exito [bet_det] ";echo "<br>";
                }
                if($valida>22 ){
                  $array[0] = $nv+9;
                }else {
                  $array[0] = $nv+10;
                }
              }
            } 
          }else echo"";
        }
    }
  }}

  fx_insertPinnacle($cn,153);
  fx_insertOnceBet($cn,154,327,6);
?>
