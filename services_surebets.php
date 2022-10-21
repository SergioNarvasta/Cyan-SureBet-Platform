<?php 
include("conexion.php") ;
$sql ="SELECT * FROM `bet` WHERE Idbet>0 ";

header("Location: surebets.php?status=false&sql=$sql");


//Menu Bar Slider
//https://codepen.io/ctwheels/pen/EZPbWd

?>