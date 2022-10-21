<?php 
include("conexion.php") ;

$eve=$_POST["Evento"];
$benf=$_POST["Beneficio"];
$casa=$_POST["Casa"];
$comp=$_POST["Competicion"];
$sql ="SELECT * FROM `bet` WHERE Idbet>0 ";
if(!Empty($eve)){
    $sqlev = " AND Evento LIKE '%$eve%' " ;
    $sql   = $sql.$sqlev;
}
if(!Empty($benf) and ($benf>=1)){
   $sqlbenf = " AND Beneficio < $benf ";
   $sql     = $sql.$sqlbenf;
}
if(!Empty($casa) and ($casa != "Todas")){
    $sqlcasa = " AND Casa1 = '$casa' ";
    $sql     = $sql.$sqlcasa;
}
if(!Empty($comp)and ($comp != "Todas")){
    $sqlcomp=" AND Competicion = '$comp' ";
    $sql =$sql.$sqlcomp;
}

//$data=mysqli_query($cn,$sql);

//if (!Empty($data)){
    header("Location: surebets.php?status=true&sql=$sql");
//}
?>