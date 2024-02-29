class CustomAjax {
    constructor({
                    url = "",
                    type = "get",
                    data,
                    contentType = "application/x-www-form-urlencoded; charset=UTF-8",
                    processData = true,
                    global = true
                }) {
        this._url = url;
        this._type = type;
        this._data = data;
        this._contentType = contentType;
        this._processData = processData;
        this._global = global;
    }

    async Start() {
        let response;
        try {
            await $.ajax({
                type: this._type,
                url: this._url,
                data: this._data,
                contentType: this._contentType,
                processData: this._processData,
                global: this._global,
                success: (promise) => {
                    response = promise;
                }
            });
        } catch (e) {
            response = "";
            console.log(e);
        }

        return response;
    }
}