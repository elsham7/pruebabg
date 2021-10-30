using LogicaDatos.Seguridad;
using ViewModel.Seguridad;
using System.Threading.Tasks;

namespace LogicaNegocio.Seguridad
{
    public class BSeguridad
    {
        public async Task<UserAdminVM> Login( LoginVM login)
        {
            return await new DSeguridad().Login( login);
            
        }
      
    }
}
