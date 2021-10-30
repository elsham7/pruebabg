using MassTransit;
using System;
using System.Threading.Tasks;
using Utilities;
using ViewModel.Mensajeria;

namespace LogicaNegocio.Mensajeria
{
    public class BMensajeria
    {
        public static async Task EnviarMensajeAsincrono(MensajeAsincronoVM mensaje, IBusControl bus)
        {
            string ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;

            var servidorRabbit = Comun.ConfigApp.GetSection("SERVIDOR-RABBIT-" + ambiente).Value;

            Uri uri = new Uri($"{servidorRabbit}/{mensaje.Cola}");

            var endPoint = await bus.GetSendEndpoint(uri);
            await endPoint.Send(mensaje);
        }
    }
}
