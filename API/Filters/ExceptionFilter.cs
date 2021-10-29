using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Utilities;

namespace API.Filters
{
    public class ExceptionFilter : IExceptionFilter, IAuthorizationFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private Dictionary<string, string> parametrosTipoCabecera = new Dictionary<string, string>();
        private Dictionary<string, string> parametrosTipoFormulario = new Dictionary<string, string>();
        private string parametroTipoObjeto = null;
        private string ipRemota = null;

        public ExceptionFilter(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            context.HttpContext.Request.EnableBuffering();

            #region Parámetros de tipo cabecera
            parametrosTipoCabecera.Clear();
            var parametrosCabecera = context.HttpContext.Request.Query;
            foreach (var item in parametrosCabecera)
            {
                parametrosTipoCabecera.Add(item.Key, item.Value.ToString());
            }
            #endregion

            #region Parámetros de tipo formulario
            parametrosTipoCabecera.Clear();
            if (context.HttpContext.Request.HasFormContentType)
            {
                var parametrosForm = context.HttpContext.Request.Form;
                foreach (var item in parametrosForm)
                {
                    parametrosTipoCabecera.Add(item.Key, item.Value.ToString());
                }
            }
            #endregion

            #region Parámetros de tipo objeto
            parametroTipoObjeto = null;
            using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                parametroTipoObjeto = reader.ReadToEnd();
            }

            context.HttpContext.Request.Body.Position = 0;
            #endregion

            ipRemota = context.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public async void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new { mensaje = "Hubo un error, Favor comunicarse con el departamento de tecnología de Sismedic" });
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Ruta del error
            var aplicacion = _hostingEnvironment.ApplicationName;
            var accion = context.RouteData.Values["action"].ToString();
            var controlador = context.RouteData.Values["controller"].ToString();

            var fechaActual = DateTime.Now; //Tomar la fecha de la base como mejores prácticas

            string mensajeError = string.Format("MENSAJE: {0}{1}. INTERNA: {2}. PILA:{3}. ORIGEN:{4}",
                                   context.Exception.Message,
                                   Environment.NewLine,
                                   context.Exception.InnerException != null && context.Exception.InnerException.InnerException != null ? context.Exception.InnerException.InnerException.Message : "",
                                   context.Exception.StackTrace,
                                   Comun.ToString(context.Exception.Source));

            
            // Añadir Log a mongo
        }
    }
}
