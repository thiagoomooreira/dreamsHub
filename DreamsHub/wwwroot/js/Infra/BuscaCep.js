class BuscaCep{
    constructor({
        $campoCep,
        $campoRua,
        $campoBairro
                }) {
        
        this._campoCep = $campoCep
        this._campoRua = $campoRua
        this._campoBairro = $campoBairro
        
        $("#main").on("change", ".campoCep", ()=>{
            this.buscar()})
    }
    
    async buscar() {
        let cep = this._campoCep.val().replace("-", "")

        let url = "https://viacep.com.br/ws/" + cep + "/json/"
        let request = await new CustomAjax({
            type: "GET",
            url: url,
            "Access-Control-Allow-Origin": '*',
        }).Start()
        
        if(request.erro === undefined){
            this._campoRua.val(request.logradouro)
            this._campoBairro.val(request.bairro)
            
            M.updateTextFields();
        }else{
            swal("Cep Inválido", "O cep digitado não existe, verifique!", "warning")
        }
    }
}