class AdicionarTransacao{

    constructor() {
        let $main = $("#main");

        $main.on("click", "#button-adicionar-despesa", () => {this.abrirModalAdicionar({})})
        $main.on("click", "#button-adicionar-receita", () => {this.abrirModalAdicionar({tipo : "Receita"})})
        
        $main.on("click", ".button-editar-transacao", event => {
            const codigo = $(event.target).closest('.button-editar-transacao').data("codigo")

            this.abrirModalAdicionar({codigo})
        })
        
        $main.on("click", ".button-deletar-transacao", event => {
            const codigo = $(event.target).closest('.button-deletar-transacao').data("codigo")

            this.excluirTransacao(codigo)
        })
    }

    async abrirModalAdicionar({codigo = 0, tipo = "Despesa"}) {

        const response = new ViewResponse(await new CustomAjax({
            type: "POST",
            url: "/Transacao/ModalAdicionarTransacao",
            data: {codigo : codigo, tipo: tipo}
        }).Start());

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

    async excluirTransacao(codigo){

        swal({
            title: "Atenção",
            text: "Deseja realmente excluir?",
            icon: 'warning',
            buttons: {
                cancel: 'Não',
                delete: {text:'Sim!',className:'red'}
            }
        }).then(async function (willDelete) {
            if (!willDelete) {
                return false;
            }

            const response = new ViewResponse(await new CustomAjax({
                type: "POST",
                url: "/Transacao/Excluir",
                data: {codigo}
            }).Start());

            if(response.Status()){
                $(`#div-tabela-transacoes`).html(response.View());
            }
            
            response.Swal()
        })
        
    }
}