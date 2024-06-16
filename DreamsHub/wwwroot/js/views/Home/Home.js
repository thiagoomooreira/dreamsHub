class Home {
    
    constructor() {
        const body = $("body")

        body.on("click", ".item-categoria", (e) => {
            let categoria = $(e.target).closest('.item-categoria').data("categoria");
            
            this.abrirModalListaTransacoes(categoria)
        })
        
    }
    
    async abrirModalListaTransacoes(categoria) {
        let mes = $("#nome-mes-filtro").text()

        const response = new ViewResponse(await new CustomAjax({
            type: "POST",
            url: "/Home/ModalListaTransacao",
            data: {
                categoria,
                mes
            }
        }).Start());

        if (response.Status()) {
            $("#div-modal-lista-transacao").html(response.View())

            $(`#modal-lista-transacao`).modal();
            $(`#modal-lista-transacao`).modal("open");

        }
    }
}