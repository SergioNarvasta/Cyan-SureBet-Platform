<<<<<<< HEAD

<?php include("conexion.php") ;  include("conecctionPDO.php") ;

$sql= "SELECT *FROM bet WHERE idbet >0 ";
if(isset($_GET["sql"])){
  $sql1= "SELECT *FROM bet WHERE idbet >0 ";
  $sqlwhere = $_GET["sql"];
  $sql = $sql1.$sqlwhere;
 }
# Cuántos productos mostrar por página
$productosPorPagina = 2;
// Por defecto es la página 1; pero si está presente en la URL, tomamos esa
$pagina = 1;
if (isset($_GET["pagina"])) {
    $pagina = $_GET["pagina"];
}
# El límite es el número de productos por página
$limit = $productosPorPagina;
# El offset es saltar X productos que viene dado por multiplicar la página - 1 * los productos por página
$offset = ($pagina - 1) * $productosPorPagina;
# Necesitamos el conteo para saber cuántas páginas vamos a mostrar
$sentencia = $base_de_datos->query("SELECT count(*) AS conteo FROM bet");
$conteo = $sentencia->fetchObject()->conteo;
# Para obtener las páginas dividimos el conteo entre los productos por página, y redondeamos hacia arriba
$paginas = ceil($conteo / $productosPorPagina);

# Ahora obtenemos los productos usando ya el OFFSET y el LIMIT
$sentencia = $base_de_datos->prepare("$sql LIMIT ? OFFSET ?");
$sentencia->execute([$limit, $offset]);
$data = $sentencia->fetchAll(PDO::FETCH_OBJ);
?>
<head>
	<title>SureBet Platform </title>
	<link href="css/surebets.css" rel="stylesheet" type="text/css">
  <link href="css/footer.css" rel="stylesheet" type="text/css">
</head>
<body>
<div id="main">
  <div id="header">
      <div class="boxhead">
        <div class="logo"><a href="index.php"><img class="Logo" src="img/logo.jpg" width="80" height="80" ></a></div>
        <div class="title"><h1>Lista de Apuestas Seguras</h1></div>
      </div>
  </div>    
</div>
<br >
<div id="Box-Main-Bet">
   <?php foreach ($data as $r){   ?> 
    <div class="BetList">
        <div class="Cab"> 
          <div><img src="img/soccer.png" alt="Football" height="30" width="30"> </div>    
          <div><?php echo $r->Competicion ?></div>
          <div><?php echo $r->Evento ?></div>
          <div><?php echo $r->FechaEv ?> </div>
        </div>
        <div class="Det">           
          <div><?php echo $r->Casa1 ?></div>
          <div class="Res"> <?php echo $r->Mercado1 ?></div>
          <div><?php echo $r->Cuota1 ?> </div>
       </div>
       <div class="Det">           
          <div><?php echo $r->Casa2 ?></div>
          <div class="Res"> <?php echo $r->Mercado2 ?></div>
          <div><?php echo $r->Cuota2 ?> </div>
       </div>
       <div class="Det">           
          <div><?php echo $r->Casa3 ?></div>
          <div class="Res"> <?php echo $r->Mercado3 ?></div>
          <div><?php $cuo= $r->Cuota3; if($cuo>1){echo $cuo;}else echo " "; ?> </div>
       </div>
       
       <div class="Beneficio"> 
          <p><?php echo $r->Beneficio ?> GARANTIZADO BENEFICIO</p>
        </div>
    </div>
    <?php }  ?>
    <div id="Pagination"> 
        <nav>
            <div class="row">
                <div class="col-xs-12 col-sm-6">
                    <p>Mostrando <?php echo $productosPorPagina ?> de <?php echo $conteo ?> productos disponibles</p>
                </div>
                <div class="col-xs-12 col-sm-6">
                    <p>Página <?php echo $pagina ?> de <?php echo $paginas ?> </p>
                </div>
            </div>
            <ul class="pagination">
                <!-- Si la página actual es mayor a uno, mostramos el botón para ir una página atrás -->
                <?php if ($pagina > 1) { ?>
                    <li>
                        <a href="./surebets.php?pagina=<?php echo $pagina - 1 ?>">
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>
                <?php } ?>
                <!-- Mostramos enlaces para ir a todas las páginas. Es un simple ciclo for-->
                <?php for ($x = 1; $x <= $paginas; $x++) { ?>
                    <li class="<?php if ($x == $pagina) echo "active" ?>">
                        <a href="./surebets.php?pagina=<?php echo $x ?>">
                            <?php echo $x ?></a>
                    </li>
                <?php } ?>
                <!-- Si la página actual es menor al total de páginas, mostramos un botón para ir una página adelante -->
                <?php if ($pagina < $paginas) { ?>
                    <li>
                        <a href="./surebets.php?pagina=<?php echo $pagina + 1 ?>">
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                <?php } ?>
            </ul>
        </nav>
    </div>    
</div> <br>   
</body>
<?php 
   include("footer.php");
?>
=======
>>>>>>> a6de037f4cc8535e2e1424c4fc78d97a67521d9a
