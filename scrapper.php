<?php
   //Install purpeteer with -> npm i puppeteer     // Run node Scrapper_Pinnacle.js  //SELECT * FROM bet_cab A left join bet_det B ON A.idcab = B.idcab;
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
  function fx_Bet($file,$fin){
    $myhtml = file_get_html($file); $con = 0; $data = $myhtml->find("span"); 
    $array = [];  $aux=0;
    foreach($myhtml->find("span") as $content){
      $con++;
      $main = $content->innertext;  $type=settype($main,"string"); 
      $buscuota = strpos($main,"Cuota",0); //Si encuentra el flag graba info en variables
      if($buscuota>1){
        array_push($array,$con+4); 
       //echo $con."--Encontrado Guion".$lo;echo "<br>";
        foreach($myhtml->find("span") as $content){ //for para iterara todos los registros
          $aux++; $nv=$array[0];
          if($aux<$fin){
            $test = $data[$nv]->innertext;  $busguion = strpos($test,"-",0); 
            if($busguion>1){
              $array[0] = $nv+2;   $nv=$array[0];
            }
            $lo = $data[$nv]->innertext; $vi = $data[$nv+1]->innertext;  $fe = $data[$nv+2]->innertext;
            $cl = $data[$nv+3]->innertext; $ce = $data[$nv+4]->innertext;  $cv = $data[$nv+5]->innertext;
            echo $lo."  -"; echo $vi."  -"; echo $fe; echo "<br>";
            echo $cl."  -"; echo $ce."  -"; echo $cv; echo "<br>";echo "<br>";
            $array[0] = $nv+6;
            
          }
        }
      } 
    }
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
    fx_Bet($file,153);
    echo "<br>";echo "<p>Informacion de Pinnacle</p>";
    
    //echo $filereducido;
  ?>
</div></center>

</body>