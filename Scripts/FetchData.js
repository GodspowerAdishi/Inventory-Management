$(document).ready(function () {
    $(".click").click(function () {
        var productName = $("#ProductName").val();
        var productBarcode = $("#ProductBarcode").val();
        var productexpiry = $("#exdatePicker").val();
        var cartons = $("#Cartons").val();
        var pieces = $("#Pieces").val();
        var costPrice = $("#CostPrice").val();

        var code = "<tr><td><input type='checkbox' name='chk'/></td><td>" + productName + "</td><td>" + productBarcode + "</td><td>" + productexpiry + "</td><td>" + cartons + "</td><td>" + pieces + "</td><td>" + costPrice + "</td></tr>"

        $("table .tbody").append(code);
    })
});