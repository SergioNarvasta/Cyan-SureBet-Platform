<?php 
include("conexion.php") ;

$dep=$_POST["Deporte"];
$ev=$_POST["Evento"];
$mer=$_POST["Mercado"];
$comp=$_POST["Competicion"];

$sql = "Select * from bet order by Idbet desc";
$data=mysqli_query($cn,$sql);
?>