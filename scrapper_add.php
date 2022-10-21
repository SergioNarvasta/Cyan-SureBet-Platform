<?php
  include ("simple_html_dom.php");        include ("conexion.php");
  $file ="Downloads_Web/SureBets_ES.html";
  $filereducido = file_get_contents($file,FALSE,NULL,1145000,350800);
  $myhtml = file_get_html($file);
  $content = $myhtml->find("div"); 

  function fx_todo($file,$fin){
    $myhtml = file_get_html($file); $data = $myhtml->find("td");
    $con = 0;
     echo "<p>Mostrando toda la Informacion de td  </p>";
    foreach($myhtml->find("tr") as $content){
      $con++;
      if($con<$fin){
        $lo = $data[$con]->innertext;  $type=settype($lo,"string"); 
        echo $con."-->".$lo;echo "<br>";
        }
     }
  }
  function fx_testBet($cn,$file,$fin){
    $myhtml = file_get_html($file); $data = $myhtml->find("a");//a para leer benf,feve y mercados
    $array = []; $arraytd = [];     $datatd = $myhtml->find("td"); $con=0;
    foreach($myhtml->find("a") as $content){   $con++;
      if($con<$fin){
        $dat = $data[$con]->innertext;  settype($dat,"string"); 
        $busbnf=strpos($dat,"Beneficio",0); 
        if($busbnf>1){    array_push($array,$con+3); array_push($arraytd,1); //Ingreso 1 como inicio de td
          foreach($myhtml->find("a") as $content2){ //for para iterar todos los registros
            $nv=$array[0]; $td=$arraytd[0];
            if($nv<$fin){ 
              $casa1=$data[$nv]->innertext;     $eve1=$data[$nv+1]->innertext;    $cu1=$data[$nv+2]->innertext;
              $casa2=$data[$nv+3]->innertext;   $cu2=$data[$nv+5]->innertext;     $eve3valid=$data[$nv+7]->innertext;
              $feve=$datatd[$td+2]->plaintext;  $benf=$datatd[$td]->plaintext;      //settype($bn,"string");$benf=substr($bn,0,4);  
              $mer1=$datatd[$td+4]->plaintext;  $mer2=$datatd[$td+10]->plaintext; $mer3=$datatd[$td+16]->plaintext;  
              settype($eve3valid,"string");     $cuteve1=substr($eve1,0,6);       $cuteve3=substr($eve3valid,0,6);
              if($cuteve1==$cuteve3){
                $casa3=$data[$nv+6]->innertext; $cu3=$data[$nv+8]->innertext; 
                $array[0]=$nv+11;  $arraytd[0]=$td+21;
              }else{
                $casa3=null;$mer3=null; $cu3=null;  $array[0]=$nv+7;  $arraytd[0]=$td+15;
              }echo"--------------";echo "<br>";
              
              $insert ="INSERT INTO `bet`(`IdBet`, `Deporte`, `Competicion`, `Evento`, `FechaEv`, `Mercado1`, `Mercado2`, `Mercado3`, `Cuota1`, `Cuota2`, `Cuota3`, `Casa1`, `Casa2`, `Casa3`, `Beneficio`, `Resultado`, `Limite`, `FechaReg`)
                          VALUES (null,'Futbol',null,'$eve1','$feve','$mer1','$mer2','$mer3',$cu1,$cu2,$cu3,'$casa1','$casa2','$casa3','$benf',101,1500,CURRENT_TIME)";
              $res_insert = mysqli_query($cn,$insert);
              if($res_insert<1){
                echo "--Error [bet]";echo "<br>";
              }else{
                echo "--Exito [bet]";echo "<br>";
              }  
              echo $eve1." -  ".$feve." - ".$benf;echo "<br>";
              echo $casa1." - ".$mer1." - ".$cu1; echo "<br>";
              echo $casa2." - ".$mer2." - ".$cu2; echo "<br>";
              echo $casa3." - ".$mer3." - ".$cu3; echo "<br>";echo "<br>";      
            }        
          }
        } 
      }else{ echo"";}
    }
  }
?>   
<center>  <div>
<?php 
  
  fx_testBet($cn,$file,60);
  echo "--------------------------";
  fx_todo($file,60);
  //Beneficio,Deporte span    Casa,Evento,Cuota a 
  //Fecha td         Mercado abbr/td
?>
</div></center>