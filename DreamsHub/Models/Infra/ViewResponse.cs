namespace DreamsHub.Models.Infra
{
    public class ViewResponse
    {
        public bool Status { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string View { get; set; }
        public string FunctionJs { get; set; }
        public object Content { get; set; }

        public ViewResponse()
        {
            
        }

        public ViewResponse(string view)
        {
            this.Status = true;
            this.View = view;
        }

        public ViewResponse(object content)
        {
            this.Status = true;
            this.Content = content;
        }

        public ViewResponse(string view, object content)
        {
            this.Status = true;
            this.View = view;
            this.Content = content;
        }

        public ViewResponse(bool status, string mensagem)
        {
            this.Status = status;
            this.Mensagem = mensagem;
        }

        public ViewResponse(bool status, string titulo, string mensagem)
        {
            this.Status = status;
            this.Titulo = titulo;
            this.Mensagem = mensagem;
        }
    }
}