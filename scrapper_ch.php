<?php
       include ("simple_html_dom.php");

        $file2 ="Downloads_Web/Chaskibet.html";
        $filereducido = file_get_contents($file2,FALSE,NULL,1145000,350800);
        $myhtml = file_get_html($file2);
        $content = $myhtml->find("span") ;  $i = 27;

        //$a= $content[$i]->innertext; 
        //$b= $content[$i+10]->innertext; 
        //$c= $content[$i+20]->innertext; 
        //$lo1= $content[$i]->innertext;

?>   
<center>  <div>
<?php //}  
        echo "<br>";echo "<p>Informacion de ChaskiBet</p>";
       // echo $lo1;  echo "<br>";
        //echo $a; echo "<br>"; echo $b; echo "<br>"; echo $c;
        $deporte_ch = "Futbol";
        //*******************  Datos de 1 **********************************
        foreach($myhtml->find("tbody") as $content){
              echo $content->innertext;
              echo "<br>";"<br>";   
        }
       //echo $filereducido;
       //
    
    ?>
</div></center>