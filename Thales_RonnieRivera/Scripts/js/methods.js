$("#searchbyId").click(function () {
    var idEmployee = $('#idEmployee').val();
    if (idEmployee.length == 0) {
        alert('Please fill the id');
        return true;
    }
    $.ajax({
        url: "/employee/details/" + idEmployee,
        type: "GET"
    })
        .done(function (partialViewResult) {
            $("#refTable").html(partialViewResult);
        });

});