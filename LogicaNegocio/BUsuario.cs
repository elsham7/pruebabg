using AccesoDatos;
using ModeloVista;
using System;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class BUsuario
    {
        public async Task<LoginUserVM> Login(LoginVM login) {
            return await new DUsuario().Login(login);
        }
    }
}
