function Caixao() {

    var cx = document.getElementById("dropCaixao");
    var caixao = cx.options[cx.selectedIndex].value;

    caixao = caixao.substring(7,caixao.length);

    if (caixao == "alto") {
        document.getElementById("Altura").value = "0.70";
        document.getElementById("Largura").value = "2.20";
        document.getElementById("Profundidade").value = "0.30";
        document.getElementById("Valor").value = "1250.00";
    } else {
        document.getElementById("Largura").value = "0.50";
        document.getElementById("Altura").value = "1.30";
        document.getElementById("Profundidade").value = "0.30";
        document.getElementById("Valor").value = "750.00"

    }
}


function Urna() {

    var drp = document.getElementById("dropUrna");
    var urna = drp.options[drp.selectedIndex].value;

    if (urna == "Urna alta") {
        document.getElementById("largura").value = "0.20";
        document.getElementById("altura").value = "0.29";
        document.getElementById("profundidade").value = "0.27";
        document.getElementById("valor").value = "360.00"

    } else {
        document.getElementById("largura").value = "0.14";
        document.getElementById("altura").value = "0.23";
        document.getElementById("profundidade").value = "0.20";
        document.getElementById("valor").value = "300.00"
    }
}




$(document).ready(function () {

    $('[data-toggle="offcanvas"]').click(function () {
        $('#wrapper').toggleClass('toggled');
    });

    if (document.getElementById("Cep").value) {
        jQuery.getJSON("https://viacep.com.br/ws/" + document.getElementById("Cep").value + "/json/").then(function (response) {
            $("#Rua").val(response.logradouro);
            $("#Bairro").val(response.bairro);
            $("#Cidade").val(response.localidade);
            $("#Estado").val(response.uf);
            console.log(response);
        })
    }
    
    $("#Cep").change(function () {
        jQuery.getJSON("https://viacep.com.br/ws/" + document.getElementById("Cep").value + "/json/").then(function (response) {
            $("#Rua").val(response.logradouro);
            $("#Bairro").val(response.bairro);
            $("#Cidade").val(response.localidade);
            $("#Estado").val(response.uf);
            console.log(response);
        });
    });

    //coloca thead nas tabelas geradas pelo asp
    $("#tabela-principal tbody").before("<thead><tr></tr></thead>");
    $("#tabela-principal thead tr").append($("#gvCustomers th"));
    $("#tabela-principal tbody tr:first").remove();
    $("#tabela-principal thead tr th").scope = "col";


    


});
