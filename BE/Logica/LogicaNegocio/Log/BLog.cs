using LogicaDatos;
using LogicaNegocio.General;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Utilities;
using ViewModel.Logs;
using ViewModel.Mensajeria;
using ViewModel.Seguridad;

namespace ConLogicaNegocio
{
    public class BLog
    {
        public async static Task Acceso(int idUsuario, string modulo, StackTrace st, IBusControl bus)
        {
            StackFrame sf = st.GetFrame(0);
            MethodBase metodoActual = sf.GetMethod();

            var fechaActual = await BComun.FechaHoraSistema();

            LogAccesoVM l = new LogAccesoVM
            {
                Fecha = fechaActual.Date,
                Hora = fechaActual.ToString("HH:mm:ss"),                
                IdUsuario = idUsuario,
                Vista = metodoActual.ReflectedType.Name,
                Modulo = modulo
            };

            await DLog.Acceso(l);


            var mensaje = new MensajeAsincronoVM
            {
                Cola = ColaAsincronaVM.LogAcceso.ToString(),
                Contenido = JsonConvert.SerializeObject(l)
            };

            //await BMensajeria.EnviarMensajeAsincrono(mensaje,bus);
        }

        public async static Task Auditoria(LoginUserVM user, StackTrace st,  object parametro)
        {
            StackFrame sf = st.GetFrame(0);
            MethodBase metodoActual = sf.GetMethod();
            var fechaActual = await BComun.FechaHoraSistema();

            LogAuditoriaVM l = new LogAuditoriaVM
            {
                Fecha = fechaActual.Date,
                Hora = fechaActual.ToString("HH:mm:ss"),                
                IdUsuario = user.IdUsuario,
                EspacioNombre = metodoActual.ReflectedType.Namespace,
                Clase = metodoActual.ReflectedType.ReflectedType.Name,
                Metodo = metodoActual.ReflectedType.Name,
                Parametro = parametro,
            };

            await DLog.Auditoria(l);
        }

        public async static Task Error(int idEmpresa,int idUsuario, StackTrace st, Exception ex, object parametro)
        {

            StackFrame sf = st.GetFrame(0);
            MethodBase metodoActual = sf.GetMethod();

            string mensajeError = mensajeError = string.Format("MENSAJE: {0}{1}. INTERNA: {2}. PILA:{3}. ORIGEN:{4}",
                                   ex.Message,
                                   Environment.NewLine,
                                   ex.InnerException != null && ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : "",
                                   ex.StackTrace,
                                   Comun.ToString(ex.Source));

            var fechaActual = await BComun.FechaHoraSistema();

            LogErrorVM l = new LogErrorVM
            {
                Fecha = fechaActual.Date,
                Hora = fechaActual.ToString("HH:mm:ss"),
                IdUsuario = idUsuario,
                EspacioNombre = metodoActual.ReflectedType.Namespace,
                Clase = metodoActual.ReflectedType.ReflectedType.Name,
                Metodo = metodoActual.ReflectedType.Name,
                Parametro = parametro,
                Error = mensajeError
            };


            await DLog.Error(l);
        }

        public async static Task Error(LogErrorVM l)
        {                       
            await DLog.Error(l);
        }
    }
}
