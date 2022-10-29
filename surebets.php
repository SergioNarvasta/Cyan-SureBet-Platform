<?php 
include("conexion.php") ;  include("conecctionPDO.php") ;

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
        <div class="title"><h1>Lista de Apuestas Seguras</h1> <h2>¡ --- !</h2></div>
      </div>
  </div>
  <div class="sports">
      <div><a href="index.php"> <img src="img/home.png"/>Inicio </a></div>
      <div><img src="img/football2.png"/>Futbol</div>
      <div><img src="img/football_a.png"/>Futbol Americano</div>
      <div><img src="img/basketball.png"/>Baloncesto</div>
      <div><img src="img/baseball.png"/>Beisbol</div>
      <div><img src="img/tennis.png"/>Tenis</div>
  </div>      
</div>
<br >
<div id="BoxList">
  <form action="p_surebets.php" method="post">
  <div class="Filter">
     <p> <strong>Filtro de Busqueda</strong></p><br>
     <p>Evento </p> 
    <div class="box">
      <div class="container-1">
        <span class="icon"><i class="fa fa-search"></i></span>
        <input type="text" name="Evento" id="search" placeholder="Filtrar Evento..."/> 
        <input class="btnregistrar" type="submit" value="    Filtrar   "> <br><br>
        <p>Rango de Beneficio </p> 
        <input type="range"name="rangeInput"min="1"max="20"onchange="updateTextInput(this.value);">
        <input class="txtcant" type="text" name="Beneficio" id="textInput"value="  0">%
      </div> <br>
      <table>
      <tr>
        <td>Casa de Apuesta</td>
      </tr>  
        <td><select name="Casa">
            <option value="Todas">Todas</option>
            <option value="BET365">BET365</option>
            <option value="Pinnacle">Pinnacle</option>
            <option value="Te Apuesto">Chaskibet</option>
            <option value="Inka Bet">OnceBet</option>
            </select>
        </td> 
      </tr> 
      <tr>
        <td>Competicion</td>
      </tr>
      <tr>
        <td><select name="Competicion">
            <option value="Todas">Todas</option>
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
            <option value="Liga 1 Peru">Liga 1 Peru</option> </select> 
        </td> 
      </tr>
      </table>
    </div>
    
  </div>
  </form>
</div>
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
