<?php 
include("conexion.php") ;
$sql = $_GET["sql"];
$status= $_GET["status"];

if($status = true){
  $sql = $sql;
}
$data=mysqli_query($cn,$sql);
?>
<head>
	<title>SureBet Platform </title>
  <script src="js/live.js"></script>
	<link href="css/surebets.css" rel="stylesheet" type="text/css">
  <link href="css/footer.css" rel="stylesheet" type="text/css">
  <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</head>
<body>
<div id="main">
  <div id="header">
      <div class="boxhead">
        <div class="logo"><a href="index.php"><img class="Logo" src="img/logo.jpg" width="80" height="80" ></a></div>
        <div class="title"><h1>Lista de Apuestas Seguras</h1> <h2>¡ --- !</h2></div>
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
<br >
<div id="BoxList">
  <form action="p_surebets.php" method="post">
  <div class="Filter">
     <p> <strong>Filtro de Busqueda</strong></p><br>
     <p>Evento </p> 
    <div class="box">
      <div class="container-1">
        <span class="icon"><i class="fa fa-search"></i></span>
        <input type="text" name="Evento" id="search" placeholder="Filtrar Evento..."/> 
        <input class="btnregistrar" type="submit" value="    Filtrar   "> <br><br>
        <p>Rango de Beneficio </p> 
        <input type="range"name="rangeInput"min="1"max="20"onchange="updateTextInput(this.value);">
        <input class="txtcant" type="text" name="Beneficio" id="textInput"value="  0">%
      </div> <br>
      <table>
      <tr>
        <td>Casa de Apuesta</td>
      </tr>  
        <td><select name="Casa">
            <option value="Todas">Todas</option>
            <option value="BET365">BET365</option>
            <option value="Pinnacle">Pinnacle</option>
            <option value="Te Apuesto">Chaskibet</option>
            <option value="Inka Bet">OnceBet</option>
            </select>
        </td> 
      </tr> 
      <tr>
        <td>Competicion</td>
      </tr>
      <tr>
        <td><select name="Competicion">
            <option value="Todas">Todas</option>
            <option value="UEFA Champions League">UEFA Champions League</option>
            <option value="UEFA Europa League">UEFA Europa League</option>
            <option value="Copa Libertadores">Copa Libertadores</option>
            <option value="Copa Sudamericana">Copa Sudamericana</option>
            <option value="La Liga">La Liga</option>
            <option value="Premier League">Premier League</option>
            <option value="League One">League One</option>
            <option value="Bundesliga">Bundesliga</option>
            <option value="Serie A">Serie A</option>
            <option value="Liga Austria">Liga Austria</option>
            <option value="Primeira Liga">Primeira Liga</option>
            <option value="Brasileirao Serie A">Brasileirao Serie A</option>
            <option value="Liga Colombia">Liga Colombia</option>
            <option value="Liga BetCris">Liga BetCris</option>
            <option value="Liga 1 Peru">Liga 1 Peru</option> </select> 
        </td> 
      </tr>
      </table>
    </div>
    
  </div>
  </form>
</div>
<div>
   <?php   while($r = mysqli_fetch_array($data)) {   ?>   
    <div class="BetList">
        <div class="Cab"> 
          <div><img src="img/soccer.png" alt="Football" height="30" width="30"> </div>    
          <div><?php echo $r["Competicion"] ?></div>
          <div><?php echo $r["Evento"] ?></div>
          <div><?php echo $r["FechaEv"] ?> </div>
        </div>
        <div class="Det">           
          <div><?php echo $r["Casa1"] ?></div>
          <div class="Res"> <?php echo $r["Mercado1"] ?></div>
          <div><?php echo $r["Cuota1"] ?> </div>
       </div>
       <div class="Det">           
          <div><?php echo $r["Casa2"] ?></div>
          <div class="Res"> <?php echo $r["Mercado2"] ?></div>
          <div><?php echo $r["Cuota2"] ?> </div>
       </div>
       <div class="Det">           
          <div><?php echo $r["Casa3"] ?></div>
          <div class="Res"> <?php echo $r["Mercado3"] ?></div>
          <div><?php $cuo= $r["Cuota3"]; if($cuo>1){echo $cuo;}else echo "<br>"; ?> </div>
       </div>
       
       <div class="Beneficio"> 
          <p><?php echo $r["Beneficio"] ?> GARANTIZADO BENEFICIO</p>
        </div>
    </div>
    <?php }  ?>
</div> <br>   
</body>
<?php 
   include("footer.php");
?>
