<?php
include ("conexion.php");

$cantpi=0; $cantob=0;
if(isset($_GET["cpi"])){
  $cantpi= $_GET["cpi"]; settype($cantpi,"integer");
}
if(isset($_GET["cob"])){
  $cantob= $_GET["cob"]; settype($cantob,"integer");
}

?>
<head>
	<title>Operaciones - SureBet Platform </title>
	<link href="css/operaciones.css" rel="stylesheet" type="text/css">
	<link href="css/footer.css" rel="stylesheet" type="text/css">
  <script src="js/live.js"></script>
</head> 
<body>
  <div id="main">
    <div id="header">
      <div class="boxhead">
        <div class="logo"><a href="index.php"><img class="Logo" src="img/logo.jpg" width="80" height="80"></a></div>
        <div class="title"><h1>Panel de Operaciones</h1> <h2>¡      !</h2></div>
      </div>
    </div>
  </div>
<div class="main-op">
    <div></div>
</div>
<br>
<div class="Box-center">
    <div class="bot-img">
        <img src="img/bot2.gif" height="320" width="300" />
    </div>
    <div id="Niveles">
       <div class="Niv-Basico"> 
        <div><a href="js/run_process.php"><p>Extraer</p> <p>Informacion</p></a></div>  
      </div>
     <div class="Niv-Intermedio"> 
     <div class="Info"> </div>
        <a href="scrapper_pi.php"><p>Validar y</p><p>Procesar</p>
        </a>
        <h6><?php    
        if($cantpi>0){
          $cantch=$cantob+4;  settype($cantch,"string");
          $cantb3=$cantpi-8;  settype($cantb3,"string"); 
          settype($cantpi,"string"); settype($cantob,"string");
            echo "Se obtuvieron : ";                echo "<br>";
            echo "Pinnacle $cantpi registros.";     echo "<br>";
            echo "OnceBet ".$cantob." registros.";  echo "<br>";
            echo "Chaskibet ".$cantch." registros.";echo "<br>";
            echo "Bet365 ".$cantb3." registros."; }
        ?></h6>
      </div>
     <div class="Niv-Avanzado">
     <div class="Info"> </div> 
       <a href="scrapper_add.php"> <p>Actualizar</p> <p>Informacion</p>
       <img src=""></a>
     </div>
     </div>
     <div class="Recomendaciones">
      <p>Recomendaciones:</p> <br>
      <p>-El proceso de extraccion de Informacion se realiza de forma independiente y secuencial.</p>
      <p>-El tiempo de ejecucion varia entre 20 y 40 segundos segun la estabilidad de la red,</p>
      <p> cantidad de informacion y bloqueos de seguridad de las casas de apuestas.</p>
     </div>
</div>
</body>
<br>
<?php 
   include("footer.php");
?>