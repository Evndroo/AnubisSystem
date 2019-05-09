function Caixao() {

    var cx = document.getElementById("dropCaixao");
    var caixao = cx.options[cx.selectedIndex].value;

    caixao = caixao.substring(7,caixao.length);

    if (caixao == "alto") {
        document.getElementById("larguraC").value = "15";
        document.getElementById("alturaC").value = "16";
        document.getElementById("profundidadeC").value = "17";
        document.getElementById("valor").value = "15.50"
    } else {
        document.getElementById("larguraC").value = "12";
        document.getElementById("alturaC").value = "13";
        document.getElementById("profundidadeC").value = "14";
        document.getElementById("valor").value = "15.50"

    }
}


function Urna() {

    var drp = document.getElementById("dropUrna");
    var urna = drp.options[drp.selectedIndex].value;

    if (urna == "Urna alta") {
        document.getElementById("largura").value = "15";
        document.getElementById("altura").value = "16";
        document.getElementById("profundidade").value = "17";
        document.getElementById("valor").value = "20,50"

    } else {
        document.getElementById("largura").value = "12";
        document.getElementById("altura").value = "13";
        document.getElementById("profundidade").value = "14";
        document.getElementById("valor").value = "15.50"
    }
}


$(document).ready(function () {

    $('[data-toggle="offcanvas"]').click(function () {
        alert("aihsbdhasbdh");
        $('#wrapper').toggleClass('toggled');
    });
});