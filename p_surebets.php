<?php 
include("conexion.php") ;

$eve=$_POST["Evento"];
$benf=$_POST["Beneficio"];
$casa=$_POST["Casa"];
$comp=$_POST["Competicion"];
$sql ="SELECT * FROM `bet` WHERE Idbet > 1";
if(!Empty($eve)){
    $sqlev = " AND Evento LIKE '%$eve%' " ;
    $sql   = $sql.$sqlev;
}
if(!Empty($benf)){
   $sqlbenf = " AND Beneficio < $benf ";
   $sql     = $sql.$sqlbenf;
}
if(!Empty($casa) and ($casa != "Todas")){
    $sqlcasa = " AND CasaApuesta = '$casa' ";
    $sql     = $sql.$sqlcasa;
}
if(!Empty($comp)){
    $sqlcomp=" AND Competicion = '$comp' ";
    $sql =$sql.$sqlcomp;
}
$data=mysqli_query($cn,$sql);

if ($data > 1){
    header("Location: ../form_validation.php?$_Proceso=$_Proceso");
}
?>

<br><br><br>
<p> <?php echo $sql?></p>