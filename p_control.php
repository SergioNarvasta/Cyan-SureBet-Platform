<?php 
include("conexion.php") ;

$dep=$_POST["Deporte"];
$ev=$_POST["Evento"];
$mer=$_POST["Mercado"];
$comp=$_POST["Competicion"];
$cuo=$_POST["Cuota"];
$ben=$_POST["Beneficio"];
$casa=$_POST["Casa"];
$fev=$_POST["FechaEv"];
$lim=$_POST["Limite"];
$frg=$_POST["FechaReg"];

$sql = "INSERT INTO bet(IdBet, Deporte, Evento, Mercado, Competicion, Cuota, Beneficio, CasaApuesta, FechaEv,Limite,FechaReg) VALUES (NULL,'$dep','$ev','$mer','$comp',$cuo,$ben,'$casa','$fev',$lim,'$frg')";
//$sql2  ="INSERT INTO `bet` (`IdBet`, `Deporte`, `Evento`, `Mercado`, `Competicion`, `Cuota`, `Beneficio`, `CasaApuesta`, `FechaEv`, `Limite`, `FechaReg`) VALUES (NULL, 'Futbol', 'Alianza vs Universitario', '1x', 'Liga 1 Peru', '1.32', '11', 'BET 365', '2022-08-31', '1900', '2022-08-23')";
$n = mysqli_query($cn,$sql);
?>
<p>Se Registro con exito - <?php echo $n ?></p>
<p>Deporte <?php echo $dep ?></p>
<p>Evento <?php echo $ev ?></p>
<p>Mercado <?php echo $comp ?></p>
<p>Cuota <?php echo $cuo ?></p>
<p>Beneficio <?php echo $ben ?></p>
<p>Casa <?php echo $casa ?></p>
<p>FechaEv <?php echo $fev ?></p>
<p>Limite <?php echo $lim ?></p>
<p>FechaReg <?php echo $frg ?></p>