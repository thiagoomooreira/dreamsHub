class AdicionarMeta {

    constructor() {
        let $main = $("#main");

        $main.on("click", "#button-adicionar-meta", () => {this.abrirModalAdicionar()})
        
    }

    async abrirModalAdicionar(codigo = 0) {

        const response = new ViewResponse(await new CustomAjax({
            type: "POST",
            url: "/Metas/Adicionar/",
            data: {codigo : codigo}
        }).Start());

        if(response.Status()){
            $("#div-modal-adicionar-meta").html(response.View())

            $('.modal').modal({
                dismissible: false,
            });

            $(`#modal-adicionar-meta`).modal('open');
        }else{
            response.Swal()
        }
    }
}