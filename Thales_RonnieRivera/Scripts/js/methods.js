$("#searchbyId").click(function () {
    var idEmployee = $('#idEmployee').val();
    if (idEmployee != "") {
        $.ajax({
            url: "/employee/details/" + idEmployee,
            type: "GET"
        })
            .done(function (partialViewResult) {
                $("#refTable").html(partialViewResult);
            });
    } else {
        $.ajax({
            url: "/employee/getAllEmployees",
            type: "GET"
        })
            .done(function (partialViewResult) {
                $("#refTable").html(partialViewResult);
            });
    }

});