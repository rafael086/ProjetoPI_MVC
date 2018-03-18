function configuraSobre() {
    $(".btnEditar").click(function () {
        $(this).attr("disabled","disabled");
        var idSobre = $(this).parent().parent().parent().data("sobre");
        $.ajax({
            url: "/Usuario/EditSobre",
            datatype: "html",
            type: "POST",
            data: { id: idSobre },
            success: function (html) {
                var form = $("div").find(`[data-sobre='${idSobre}']`);
                form.append(html);
                form.find(".btnFechar").click(function () {
                    $(form).find(".btnEditar").removeAttr("disabled");
                    form.find(".formEditaSobre").remove();
                });
                form.find(".btnSalvar").click(function (e) {
                    e.preventDefault();
                    var titulo = form.find("input[name='titulo']").val();
                    var texto = form.find("textarea[name='texto']").val();
                    $.ajax({
                        url: "/Usuario/AddEditSobre",
                        datatype: "json",
                        type: "POST",
                        data: { id: idSobre, titulo: titulo, texto: texto },
                        success: function (data) {
                            form.find("h3").text(titulo);
                            form.find("p").text(texto);
                        }
                    });
                });
               
                //$("div").find(`[data-sobre='${idSobre}']`).append(html);
                
            }
        });
    });
        
    $("#btnAddSobre").click(function () {
        $(this).attr("disabled","disabled");
        $.ajax({
            url: "/Usuario/NovoSobre",
            datatype: "html",
            type: "POST",
            data: 1,
            success: function (html) {
                $("#btnAddSobre").before(html);
                $("#btnCancelarAddSobre").click(function () {
                    $("#novoSobre").remove();
                    $("#btnAddSobre").removeAttr("disabled");
                });

                $("#btnSalvarSobre").click(function (e) {
                    e.preventDefault();
                    var titulo = $("#formNovoSobre #titulo").val();
                    var texto = $("#formNovoSobre #texto").val();
                    $("#btnAddSobre").removeAttr("disabled");
                    $.ajax({
                        url: "/Usuario/AddSobre",
                        datatype: "html",
                        type: "POST",
                        data: { titulo: titulo, texto: texto },
                        success: function (html) {
                            $("#novoSobre").before().html(html);
                        }
                    });
                });
            }
        });
       
    });
}