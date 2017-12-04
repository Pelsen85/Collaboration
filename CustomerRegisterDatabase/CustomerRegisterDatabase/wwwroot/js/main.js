
$("#addForm button").click(function () {

    $.ajax({
        url: '/api/Customers/',
        method: 'POST',
        data: {
            "FirstName": $("#addForm [name=FirstName]").val(),
        }

    })
        .done(function (result) {

            alert(`Success! Result = ${result}`)
            console.log("Success!", result)

        })

        .fail(function (xhr, status, error) {

            alert(`Fail!`)
            console.log("Error", xhr, status, error);

        })
});
