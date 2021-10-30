using LogicaDatos;
using MassTransit;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModel.Logs;
using ViewModel.Mensajeria;

namespace ApiMensajeria.Consumer
{
    public class LogAccesoConsumer: IConsumer<MensajeAsincronoVM>
    {
        private readonly IBusControl _bus;
        public LogAccesoConsumer(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<MensajeAsincronoVM> context)
        {
            var data = context.Message;
            var logAcceso = JsonSerializer.Deserialize<LogAccesoVM>(data.Contenido);

            try
            {
                await DLog.Acceso(logAcceso);
            }
            catch (Exception ex)
            {
                #region Log de Error
                //Log de archivo on ILogger
                #endregion
            }

        }
    }
}
