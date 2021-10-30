using System.Linq;
using Utilities;

namespace ViewModel.Seguridad
{
    public class LoginUserVM
    {
        #region Propiedades                    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Token { get; set; }
        public string TokenRefresh { get; set; }        
        #endregion

        #region Constructores
        public LoginUserVM()
        {

        }

        public LoginUserVM(System.Security.Principal.IPrincipal User)
        {

            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            var claims = from c in identity.Claims
                         select new
                         {
                             type = c.Type,
                             value = c.Value
                         };

            foreach (var c in claims)
            {
                switch (c.type.ToString())
                {                    
                    case "IdUsuario": IdUsuario = Comun.ToInt(c.value); break;
                    case "Token": Token = Comun.ToString(c.value); break;
                    case "TokenRefresh": Token = Comun.ToString(c.value); break;

                }
            }
        }

        #endregion
    }
}
