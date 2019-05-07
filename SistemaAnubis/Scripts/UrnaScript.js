function dropUrna() {
    var urna = document.getElementById("#dropUrna").value();
    var largura, altura, profundidade;
    if (urna == "Caixão alto") {
        document.getElementById("largura").value = "15";
        document.getElementById("altura").value = "16";
        document.getElementById("profundidade").value = "17";
    } else {
        document.getElementById("largura").value = "12";
        document.getElementById("altura").value = "13";
        document.getElementById("profundidade").value = "14";
    }
}