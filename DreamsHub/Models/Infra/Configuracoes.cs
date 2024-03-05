namespace DreamsHub.Models.Infra;

public class Configuracoes
{
    public static bool EhDebug()
    {
        #if DEBUG
            return true;
        #endif
        
        return false;
    }
}