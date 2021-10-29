using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSamuelAlcivar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransaccionController : Controller
    {
        public async Task<string> Saludo() {
            return "HOLA";
        } 
    }
}
