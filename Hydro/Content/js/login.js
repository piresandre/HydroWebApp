$(document).on("click", "#login", function (e) {
    e.preventDefault();
    NProgress.start();
    let user = $("#user").val();
    let password = $("#password").val();
    $.ajax({
        type: "POST",
        url: "/Login/UserLogin",
        data: { email: user, password: password },
        dataType: "json",
        success: function (data) {
            NProgress.done();
            Cookies.set('CC', data.CodCliente, { expires: 730 });
            setTimeout(function () {
                location.href = "/Dashboard/MainDashboard"; 
            }, 1000);
        },
        error: function (data) {
            console.log(data);
            console.log("erro");
        }
    });
});

$(document).on("click", "#register", function () {
    location.href = "/Login/FormCadastro";
});


