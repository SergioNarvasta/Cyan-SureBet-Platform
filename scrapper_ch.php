<?php
       include ("simple_html_dom.php");

        $file2 ="Downloads_Web/Chaskibet.html";
        $filereducido = file_get_contents($file2,FALSE,NULL,1145000,350800);
        $myhtml = file_get_html($file2);
        $content = $myhtml->find("span") ; 

?>   
<center>  <div>
<?php //}  
        echo "<br>";echo "<p>Informacion de ChaskiBet</p>";
/*
        foreach($myhtml->find("tbody") as $content){
              echo $content->innertext;
              echo "<br>";"<br>";   
        }
       //echo $filereducido;
       //
    
    ?>*/
</div></center>