function trim(cadena) {
    while (cadena.substr(0, 1) == " ")
        cadena = cadena.substr(1);
    while (cadena.substr(cadena.length - 1, 1) == " ")
        cadena = cadena.substr(0, cadena.length - 1);
    while (cadena.search(/  /) != -1)
        cadena = cadena.replace("  ", " ");
    return (cadena);
}

function ValidaCadena(cadena, campo, vacio) {
    var sCad;

    eval("sCad=" + cadena + ".value");
    sCad = trim(sCad);
    if ((sCad == null) || (sCad.length == 0) && (!vacio)) {
        eval("" + cadena + ".select()");
        alert('Debe ingresar ' + campo);
        return false;
    }
    while (sCad.indexOf("'") != -1)
        sCad = sCad.replace("'", "");
    eval(cadena + ".value='" + sCad + "'");
    return true;
}