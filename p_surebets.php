<?php 
include("conexion.php") ;

$casa=$_POST["Casa"];
$comp=$_POST["Competicion"];

//SELECT * FROM `bet` WHERE CasaApuesta = 'BET365'  and Competicion = ''ORDER by IdBet desc
$sql = "Select * from bet order by Idbet desc";
$data=mysqli_query($cn,$sql);
?>