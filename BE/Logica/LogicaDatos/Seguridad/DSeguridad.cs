using Microsoft.EntityFrameworkCore;
using Utilities;
using ViewModel.Seguridad;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDatos.Seguridad
{
    public class DSeguridad
    {
        public async Task<UserAdminVM> Login(LoginVM login)
        {
            UserAdminVM userAdmin = null;

            using (DB db = new DB())
            {
                // Se recomienda hacer un SP
                var usuario = await db.Usuario.Where(x => x.Email == login.Email && x.Password == Comun.SHA(login.Password)).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    userAdmin = new UserAdminVM();                   
                    userAdmin.LoginUser.IdUsuario = usuario.IdUsuario;
                    userAdmin.LoginUser.Nombre = usuario.Nombre;
                }
            }

            return userAdmin;
        }        


    }
}
