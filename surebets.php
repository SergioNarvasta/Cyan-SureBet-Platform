<?php 
include("conexion.php") ;
$sql = "Select * from bet";
$data=mysqli_query($cn,$sql);
?>
<head>
	<title>SureBet Platform </title>
	<link href="css/surebets.css" rel="stylesheet" type="text/css">
</head>
<body>
<div id="main">
  <div id="header">
      <div class="boxhead">
        <div class="logo"><a href="index.html"><img class="Logo" src="img/logo.png" width="80" height="80"></a></div>
        <div class="title"><h1>Lista de Apuestas Seguras</h1> <h2>¡ Slogan !</h2></div>
      </div>
  </div>
  <div class="sports">
      <div><a href="index.php"> <img src="img/home.png"/>Inicio </a></div>
      <div><img src="img/football2.png"/>Futbol</div>
      <div><img src="img/football_a.png"/>Futbol Americano</div>
      <div><img src="img/basketball.png"/>Baloncesto</div>
      <div><img src="img/baseball.png"/>Beisbol</div>
      <div><img src="img/tennis.png"/>Tenis</div>
  </div>      
</div>
<br />
<div class="Main">
   <div class="filter">
        <div class="app-filter">
            <div class=""><span><strong>Porcentaje de Beneficio</strong></span></div>
            <div class="">
                <div id="range-overround" style="margin: 10px 10px 55px 10px"></div>
            </div>
        </div>
   </div>
       <?php   while($r = mysqli_fetch_array($data)) {   ?>   
      <div class="BetList">

        <div class="Cab"> 
          <div><img src="img/soccer.png" alt="Football" height="30" width="30"> </div>
                  
          <div><?php echo $r["Competicion"] ?></div>
          <div><?php echo $r["FechaEv"] ?> </div>
        </div>

        <div class="Det"> 
          <div><?php echo $r["Evento"] ?></div>
          <div><?php echo $r["Cuota"] ?> </div>
          <div><?php echo $r["CasaApuesta"] ?></div>
       </div>

       <div class="Res">Resultado Final <?php echo $r["Mercado"] ?></div>
       <div class="Beneficio"> 
          <p><?php echo $r["Beneficio"] ?>% GARANTIZADO BENEFICIO</p>
                <a class="btn btn-primary" asp-area="" asp-controller="BetData" asp-action="Detalles" asp-route-id="@item.IdBet">Detalles</a>
            </div>
     </div>
     <?php }  ?>
</div>
</body>
