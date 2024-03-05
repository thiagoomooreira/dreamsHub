class ViewResponse{
    constructor(response) {
        this._status = response.status;
        this._titulo = response.titulo;
        this._mensagem = response.mensagem;
        this._view = response.view;
        this._functionJs = response.functionJs;
        this._content = response.content;

        debugger
        if (!this._status) {
            if (!this._titulo) {
                this._titulo = "Atenção";
            }

            if (!this._mensagem) {
                this._mensagem = "Não foi possível completar a ação";
            }
        } else if (this._status) {
            if (!this._titulo) {
                this._titulo = "Sucesso";
            }

            if (!this._mensagem) {
                this._mensagem = "";
            }

            if (!this._view) {
                this._view = "";
            }
        }

        if (!this._functionJs) {
            this._functionJs = "";
        }

        if (!this._content) {
            this._content = "";
        }
    }

    Status() {
        return this._status;
    }

    Titulo() {
        return this._titulo;
    }

    Mensagem() {
        return this._mensagem;
    }

    View() {
        return this._view;
    }

    ExecuteFunction() {
        if (this._functionJs) {
            eval(this._functionJs);
        }
    }

    Content() {
        return this._content;
    }

    async Swal() {
        //Se existir um sweet alert visível, esperamos um segundo para mostrar outro
        if ($(".sweet-alert:visible").length) {
            await this.sleep();
        }

        if (this.Status()) {
            swal(this.Titulo(), this.Mensagem(), "success");
        } else if (!this.Status()) {
            swal(this.Titulo(), this.Mensagem(), "warning");
        }
    }

    Notificacao() {
        if (this.Status()) {
            NotificacaoSuccess(this.Titulo(), this.Mensagem());
        } else if (!this.Status()) {
            NotificacaoWarning(this.Titulo(), this.Mensagem());
        }
    }

    async sleep(ms = 1000) {
        if (typeof Startload !== "undefined") {
            Startload();
        }

        await new Promise(resolve => setTimeout(resolve, ms));

        if (typeof Closeload !== "undefined") {
            Closeload();
        }

        return;
    }
}


