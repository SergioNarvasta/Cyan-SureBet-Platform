<?php
  include ("simple_html_dom.php");
  $file ="Downloads_Web/Chaskibet.html"; $casa="Chaskibet";
  $filereducido = file_get_contents($file,FALSE,NULL,1145000,350800);
  $myhtml = file_get_html($file);
  $content = $myhtml->find("div") ; 
  function fx_todo($file,$fin){
    $myhtml = file_get_html($file); $data = $myhtml->find("div");
    $con = 0;
     echo "<p>Mostrando toda la Informacion de span  </p>";
    foreach($myhtml->find("div") as $content){
      $con++;
      if($con<$fin){
        $lo = $data[$con]->innertext;  $type=settype($lo,"string"); 
        echo $con."-->".$lo;echo "<br>";
        }
     }
  }
?>   
<center>  <div>
<?php //}  
        echo "<br>";echo "<p>Informacion de $casa</p>";
       
        foreach($myhtml->find("tbody") as $content){
              echo $content->innertext;
              echo "<br>";"<br>";   
        }
       //echo $filereducido; 
    ?>
</div></center>