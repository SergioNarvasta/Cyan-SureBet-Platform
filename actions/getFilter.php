<?php 
include("conexion.php") ;
$sql = "Select * from bet order by Idbet asc";
$data=mysqli_query($cn,$sql);
?>