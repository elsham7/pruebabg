using ModeloVista;
using System.Linq;
using Utilities;

namespace API.Util
{
    public class ConfigApp
    {
        public static LoginUserVM UsuarioSolicitud(string token)
        {
            LoginUserVM user = new LoginUserVM();

            var principal = JWT.ConsultarClaim(token);

            user.IdUsuario = Comun.ToInt(principal.Claims.Where(x => x.Type == "IdUsuario").Select(x => x.Value).FirstOrDefault());

            return user;

        }
    }
}
