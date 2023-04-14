$(document).ready(function () {
    // Aplica a máscara de telefone nos campos com a classe "phone-mask"
    $('.phone-mask').mask('(00) 00000-0000');

    // Aplica a máscara de CPF nos campos com a classe "cpf-mask"
    $('.cpf-mask').mask('000.000.000-00');
});