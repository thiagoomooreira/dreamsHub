namespace DreamsHub.Models.Infra;

public static class Tratamentos
{
    public static DateTime ConverterMes(string mes)
    {
        int anoAtual = DateTime.Now.Year;
        
        string dataString = $"01/{GetNumeroMes(mes)}/{anoAtual}";
        return DateTime.ParseExact(dataString, "dd/MM/yyyy", null);
    }
    
    static string GetNumeroMes(string nomeMes)
    {
        return DateTime.ParseExact(nomeMes, "MMMM", null).ToString("MM");
    }
}