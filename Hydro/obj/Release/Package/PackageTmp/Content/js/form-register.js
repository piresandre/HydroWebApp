$(document).ready(function () {
    $('.step').hide()
    $('.step').first().show()

    var faseIndex = function () {
        var index = parseInt($(".step:visible").index())
        switch (index) {
            case 0:
                $("#prev").hide();
                $("#next").show();
                $("#salvar").hide();
                break
            case 1:
                $("#prev").show()
                $("#next").show()
                $("#salvar").hide()
                break
            case 2:
                $("#next").hide()
                $("#prev").show()
                $("#salvar").show()
                break
            default:
                $("#prev").prop('disabled', false)
                $("#next").prop('disabled', false)
        }
        mudarStep(index)
    };
    
    var proximo = function () {
        $("#next").click(function () {
            $(".step:visible").hide().next().show()
            faseIndex()
        })
    } 
    var anterior = function () {
        $("#prev").click(function () {

            $(".step:visible").hide().prev().show()
            faseIndex()
        })
    }

    var mudarStep = function (index) {
        switch (index) {
            case 0:
                $("#step-pessoal").addClass("item-ativo")
                $("#step-endereco").removeClass("item-ativo")
                $("#step-endereco").addClass("item-default")
                $("#step-acesso").removeClass("item-ativo")
                break
            case 1:
                $("#step-pessoal").removeClass("item-ativo")
                $("#step-pessoal").addClass("item-default")
                $("#step-endereco").addClass("item-ativo")
                $("#step-acesso").removeClass("item-ativo")
                break
            case 2:
                $("#step-pessoal").removeClass("item-ativo");
                $("#step-endereco").removeClass("item-ativo");
                $("#step-acesso").addClass("item-ativo");
                break
            default:
                addClass("fa-user-plus, fa-home, fa-check-double");
        }
    }
    faseIndex();
    proximo();
    anterior();

});

let codPlano = 0;
$(document).on("click", "#ddlPlano1", function (event) {
    $("#plano").val("1");
    codPlano = 1;
});
$(document).on("click", "#ddlPlano2", function (event) {
    $("#plano").val("2");
    codPlano = 2;
});
$(document).on("click", "#ddlPlano3", function (event) {
    $("#plano").val("3");
    codPlano = 3;
});

$(document).on("click", "#salvar", (e) => {
    e.preventDefault();
    NProgress.start();
    let nome = $("#nome").val();
    let email = $("#email").val();
    let telefone = $("#telefone").val();
    let cpf = $("#cpf").val();
    let cep = $("#cep").val();
    let cidade = $("#cidade").val();
    let rua = $("#rua").val();
    let bairro = $("#bairro").val();
    let uf = $("#uf").val();
    let numero = $("#numero").val();
    let id = $("#id").val();
    let senha = $("#senha").val();
    let confirmaSenha = $("#confirmarSenha").val();
    if (senha == confirmaSenha) {
        $.ajax({
            type: "POST",
            url: "/Login/CadastarCliente",
            data: { nome, email, telefone, cpf, cep, cidade, rua, bairro, uf, numero, id, senha, codPlano},
            dataType: "json",
            success: function (data) {
                NProgress.done();
                //Cookies.set('CC', { expires: 730 });
                $(".msg").append("<h1>Usuario Cadastrado<h1>");
            },
            error: function (data) {
                console.log(data);
                console.log("erro");
            }
        });
    }
});
