// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function FormatarValorInserirNoCampo(value) {
    return `R$ ${String(value.toFixed(2)).replace(".", ",")}`;
}
var Api = axios.create({
    baseURL: `${window.location.origin}/api/`,
})

function FloatConverter(param) {
    let valorSemFormatacao = "";
    let valor = param;
    if (valor.search(",") == -1) {
        valor = `${valor},00`;
    } else {
        let paramSeparated = valor.split(",");
        if (paramSeparated[1].length == 1) {
            valor = `${paramSeparated[0]},${paramSeparated[1]}0`;
        } else if (paramSeparated[1].length > 2) {
            valor = `${paramSeparated[0]},${paramSeparated[1].slice(0, 2)}`;
        }
    }
    for (let i = 0; i <= valor.trim().length; i++) {
        if (!isNaN(valor[i]) && valor[i] != " ") {
            valorSemFormatacao = valorSemFormatacao + valor[i].toString()
        }
    }

    let numInteiro = valorSemFormatacao.substring(0, valorSemFormatacao.length - 2)
    let numdigito = valorSemFormatacao.substring(valorSemFormatacao.length - 2, valorSemFormatacao.length)
    let num = parseFloat(parseFloat(numInteiro + "." + numdigito).toFixed(2))
    if (isNaN(num)) {
        return 0
    } else {
        return num
    }
}