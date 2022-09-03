
function updateTextInput(val) 
          document.getElementById('textInput').value=val; 

function getFilter() {
    getRequest(
        
        'getFilter.php', // URL for the PHP file
        drawOutput,  // handle successful request
        drawError    // handle error
        
    );
    return false;
}  