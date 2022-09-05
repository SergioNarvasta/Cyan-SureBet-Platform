<?php 
include("conexion.php") ;
$sql = "Select * from bet order by Idbet desc ";
$data=mysqli_query($cn,$sql);
?>
<head>	
    <meta charset="UTF-8">
	<title>Panel Control - SureBet Platform</title> 
	<link href="css/control.css" rel="stylesheet" type="text/css">
    <link href="css/footer.css" rel="stylesheet" type="text/css">
</head>  
<body>  
<div id="main">
    <div id="header">
      <div class="boxhead">
        <div class="logo"><a href="index.php"><img class="Logo" src="img/logo.png" width="80" height="80"></a></div>
        <div class="title"><h1>Panel Control - Administrador</h1> <h2>¡ Slogan !</h2></div>
      </div>
    </div>
</div>
  <br> 
<div id="registro">
    <div></div>
    <form class="registro-bet"  action="p_control.php" method="post">
       <!--  <fieldset> <legend>Datos Apuesta</legend>  </fieldset> -->
        <table align="center" class="table">
            <tr>
                <td>Deporte</td>
                <td>Evento</td>   
            </tr>
            <tr>
                <td><select name="Deporte">
                    <option value="Futbol">Futbol</option>
                    <option value="Futbol Americano">Futbol Americano</option>
                    <option value="Tennis">Tennis</option>
                    <option value="Baloncesto">Baloncesto</option>
                    <option value="Beisbol">Beisbol</option>
                    </select> </td>  
                 <td><input type="text" name="Evento" required="true"></td>
            </tr>
            <tr>
                <td>Mercado</td>
                <td>Competicion</td>
            <tr>
            <td><select name="Mercado">
                    <option value="Gana Local ">Gana Local </option>
                    <option value="Empate ">Empate 90min</option>
                    <option value="Gana Visita ">Gana Visita </option>
                    <option value="Doble Op. LoE">Doble Op. LoE</option>
                    <option value="Doble Op. LoV">Doble Op. LoV</option>
                    <option value="Doble Op. EoV">Doble Op. EoV</option>
                    <option value="Goles +0.5">Goles +0.5</option>
                    <option value="Goles +1.5">Goles +1.5</option>
                    <option value="Goles +2.5">Goles +2.5</option>
                    <option value="Goles +3.5">Goles +3.5</option>
                    <option value="Goles -0.5">Goles -0.5</option>
                    <option value="Goles -1.5">Goles -1.5</option>
                    <option value="Goles -2.5">Goles -2.5</option>
                    <option value="Goles -3.5">Goles -3.5</option>
                    <option value="Liga 1 Peru">Liga 1 Peru</option> </select> </td>  
                <td><select name="Competicion">
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
                    <option value="Liga 1 Peru">Liga 1 Peru</option> </select> </td>  
            <tr>
                <td>Cuota</td>
                <td>Beneficio</td>
            </tr>
            <tr>
                <td><input type="text" name="Cuota" autocomplete="on" required="true" ></td>
                <td><input type="text" name="Beneficio" autocomplete="on" required="true" ></td>
            </tr>
            <tr>
                <td>Casa Apuesta</td>
                <td>Fecha de Evento</td>
            </tr>
            <tr>
                <td><select name="Casa">
                    <option value="BET365">BET365</option>
                    <option value="Pinnacle">Pinnacle</option>
                    <option value="Te Apuesto">Te Apuesto</option>
                    <option value="Inka Bet">InkaBet</option>
                     </select>
                </td>
                <td><input type="date" name="FechaEv"></td>
            </tr>
            <tr>
                <td>Limite</td>
                <td>Fecha de Registro</td>
            </tr>
            <tr>
                <td><input type="text" name="Limite" autocomplete="on" required="true" ></td>
                <td><input type="date" name="FechaReg"></td>
            </tr>
        </table>  
        <br>
            <input class="btnregistrar" type="submit" value="Registrar">              
 
    </form>
</div>
<br><br>
<div id="BoxList">
   <?php   while($r = mysqli_fetch_array($data)) {   ?>   
    <div class="BetList">
        <div class="Cab"> 
          <div><img src="img/soccer.png" alt="Football" height="30" width="30"> </div>    
          <div><?php echo $r["Competicion"] ?></div>
          <div><?php echo $r["Evento"] ?></div>
          <div><?php echo $r["FechaEv"] ?> </div>
        </div>

        <div class="Det">           
          <div><?php echo $r["CasaApuesta"] ?></div>
          <div class="Res">Resultado Final <?php echo $r["Mercado"] ?></div>
          <div><?php echo $r["Cuota"] ?> </div>
       </div>
       
       <div class="Beneficio"> 
          <p><?php echo $r["Beneficio"] ?>% GARANTIZADO BENEFICIO</p>
          <p>Habilitar</p>
          <p>Editar</p>
          <p>Eliminar</p>
        </div>
    </div>
    <?php }  ?>
</div>    
</body> <br>
<?php 
   include("footer.php");
?>

