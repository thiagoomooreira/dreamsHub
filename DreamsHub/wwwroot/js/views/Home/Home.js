class Home {
    
    constructor({
            metas
    }) {
        
        const body = $("body")

        body.on("click", ".item-categoria", (e) => {
            let categoria = $(e.target).closest('.item-categoria').data("categoria");
            
            this.abrirModalListaTransacoes(categoria)
        })

        $.each(metas, function( key, value ) {
            let meta = metas[key];
            let percentual = Math.round((meta.Valor * 100)/meta.Meta)

            new Chartist.Pie(
                "#current-balance-donut-chart-" + meta.Id,
                {
                    labels: [1, 2],
                    series: [
                        { meta: meta.Descricao, value: meta.Valor},
                        { meta: "Meta", value: meta.Meta - meta.Valor }
                    ]
                },
                {
                    donut: true,
                    donutWidth: 8,
                    showLabel: false,
                    plugins: [
                        Chartist.plugins.fillDonut({
                            items: [
                                {
                                    content:
                                        `<p class="small center">Total</p><h5 class="mt-0 mb-0">${percentual} %</h5>`
                                }
                            ]
                        })
                    ]
                }
            )
        });
        
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