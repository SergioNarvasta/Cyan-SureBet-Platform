
<head>
	<title>SureBet Platform</title>
  <link href="css/index.css" rel="stylesheet" type="text/css">
  <link href="css/footer.css" rel="stylesheet" type="text/css">
  <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</head>
<body> 
  <div id="header">
	  <div class="navbar">
        <div class="logo">
          <img class="Logo" src="img/logo.jpg" width="100" height="100" alt="Logo Innovation Services">
        </div>
      <div id="menu">
        <div class="Inicio"><a href="control.php">Gestionar</a></div>
        <div class="Nosotros"><a href="operaciones.php">Operaciones</a></div>
        <div class="Contacto"><a href="scrapper.php">Cuotas</a></div>
        <div class="Noticias"><a href="surebets.php">SureBets</a></div>
      </div>
      <div class="login"> 
       <div class="icon"><img src="img/icon-user-header.png" width="30" height="30"></div>
       <div class="button_login"><a href="">Inicia Sesion</a></div>  
      </div>   
    </div>        
     <div id="welcome">
       <div class="caja">      
       <div class="title">
         <h1>BIENVENIDO A</h1>
         <h2>SureBet Platform</h2>
       </div>
       <div class="text">
         <p>En nuestra Plataforma, te ofrecemos los eventos en vivo, las casas en las que debes</p>
         <p>apostar y el beneficio que podrás conseguir. Además, haciendo click en la ganancia,</p>
         <p>te mostraremos cuánto tienes que apostar en cada operador para llevarte tu ganancia asegurada.</p>
       <strong>¡Siempre ganarás, así que no hay riesgo alguno!</strong> 
       </div>
       </div> 
     </div>
     <div id="Niveles">
        <div class="Niv-Basico"> 
          <a href=""><p>Competiciones</p> <p>Europeas</p></a>
          <div class="carrusel">
            <div class="carrusel-items">
            <div class="carrusel-item">
                <img width="250px" height="200px" src="img/UCL_Logo.jpg" />
            </div>
              <!--
              <div class="carrusel-item">
                <img width="400px" height="250px" src="https://phantom-marca.unidadeditorial.es/28e54d413b956822fb6e1fbe0c4546d6/resize/660/f/webp/assets/multimedia/imagenes/2022/08/25/16614474894529.jpg" alt="" />
              </div>
              <div class="carrusel-item">
                <img width="400px" height="250px" src="img/UEL.jpg" />
              </div>
              <div class="carrusel-item">
                <img width="400px" height="250px" src="img/UELFG.jpg" />
              </div> -->
            </div>  
          </div>
        </div>

        <div class="Niv-Intermedio"> 
          <a href=""><p>Ligas</p><p>Top</p> </a>
          <div class="carrusel">
            <div class="carrusel-items">
            <div class="carrusel-item">
                <img width="380px" height="250px" src="img/ligue1logo.jpg" />
            </div>
              <!--
               <div class="carrusel-item">
                <img width="380px" height="250px" src="img/Premier.png" />
              </div>
              <div class="carrusel-item">
                <img width="380px" height="250px" src="img/Seriea.jpg" />
              </div>
              <div class="carrusel-item">
                <img width="380px" height="250px" src="img/laliga.png" />
              </div> -->
            </div>
          </div>
        </div>
        <div class="Niv-Avanzado"> 
          <a href=""><p>Competiciones</p> <p>FIFA</p></a>
          <div class="carrusel">
            <div class="carrusel-items">
              <div class="carrusel-item">
                <img width="340px" height="250px" src="img/WC.jpg" />
              </div>      
              <div class="carrusel-item">
                <img width="340px" height="250px" src="img/wcf.jpg" />
              </div>
              <div class="carrusel-item">
                <img width="340px" height="250px" src="img/copa-america.jpg" />
              </div>
              <div class="carrusel-item">
                <img width="340px" height="250px" src="img/elimsud.png" />
              </div>
              <div class="carrusel-item">
                <img width="340px" height="250px" src="img/elimeurop.jpg" />
              </div>
              <div class="carrusel-item">
                <img width="340px" height="250px" src="img/elimafrc.jpg" />
              </div>
              <div class="carrusel-item">
                <img width="340px" height="250px" src="img/nations.jpg" />
              </div>     
            </div>
          </div>
        </div>
        <script src="js/carrousel.js"></script>
     </div>
    <div id="auspicio">
       <div class="centro">
        <div class="unjfsc"><a href="" target="_blank"><img src="" width="140" height="140"></a></div>
       <div class="spinout"><a href="" target="_blank"><img src="" width="140" height="140"></a></div>
       <div class="innova"> <a href=""><img src="" width="140" height="140"></a></div>
       <div class="SM1551"><a href="" target="_blank"><img src=""width="140" height="140"></a></div>
     </div>
     <div class="def">
       <div class="df1"><p>BET 365</p></div>
       <div class="df2"><p>Pinnacle</p></div>
       <div class="df3"><p>TE APUESTO</p></div>
       <div class="df4"><p>BETSSON</p></div>
     </div>
   </div>
</body>
<?php 
   include("footer.php");
?>