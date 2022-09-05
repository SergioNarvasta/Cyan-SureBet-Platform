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
//$proc=$_POST["Proceso"];


  //Fecha de Registo Actual en Zona horaria 'America/Lima'
  $Object = new DateTime();
  $Object -> setTimeZone(new DateTimeZone('America/Lima'));
  $frg= $Object -> format('Y-m-d h:i:s a');
  //date('Y-m-d h:i:s a',time());

  $sql = "INSERT INTO bet(IdBet, Deporte, Evento, Mercado, Competicion, Cuota, Beneficio, CasaApuesta, FechaEv,Limite,FechaReg) VALUES (NULL,'$dep','$ev','$mer','$comp',$cuo,$ben,'$casa','$fev',$lim,'$frg')";
  //$sql2  ="INSERT INTO `bet` (`IdBet`, `Deporte`, `Evento`, `Mercado`, `Competicion`, `Cuota`, `Beneficio`, `CasaApuesta`, `FechaEv`, `Limite`, `FechaReg`) VALUES (NULL, 'Futbol', 'Alianza vs Universitario', '1x', 'Liga 1 Peru', '1.32', '11', 'BET 365', '2022-08-31', '1900', '2022-08-23')";
  $n = mysqli_query($cn,$sql);

   // $sqldel ="Delete from bet  Where FechaEv < CURRENT_DATE()";

function regresarControl($message) {
    header("location: control.php?error=true&m=$message");
}
?>
<?php 
  if($n>1){
    regresarControl('Error en proceso, verificar!');
  }else{
    regresarControl('Proceso con exito');
  }
?>