class AdicionarTransacao{

    constructor() {
        let $main = $("#main");

        $main.on("click", "#button-adicionar-despesa", () => {this.abrirModalAdicionar()})
        // $main.on("submit", "#form-adicionar-cliente", (e) => {
        //     this.salvarCliente(e)
        // })

        // $main.on("click", ".button-editar-cliente", event => {
        //     const codigo = $(event.target).closest('.button-editar-cliente').data("codigo")
        //
        //     this.abrirModalAdicionar(codigo)
        // })
        //
        // $main.on("click", ".button-deletar-cliente", event => {
        //     const codigo = $(event.target).closest('.button-deletar-cliente').data("codigo")
        //
        //     this.excluirCliente(codigo)
        // })
    }

    async abrirModalAdicionar(codigo = 0, tipo = "Despesa") {
        
        const response = new ViewResponse(await new CustomAjax({
            type: "POST",
            url: "/Transacao/ModalAdicionarTransacao",
            data: {codigo : codigo, tipo: tipo}
        }).Start());

        debugger
        if(response.Status()){
            $("#div-modal-adicionar-transacao").html(response.View())

            $('.modal').modal({
                dismissible: false,
            });

            $(`#modal-adicionar-transacao`).modal('open');
        }else{
            response.Swal()
        }
    }
}