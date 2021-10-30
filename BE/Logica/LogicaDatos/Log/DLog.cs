using MongoDB.Bson;
using MongoDB.Driver;
using Utilities;
using ViewModel.Logs;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LogicaDatos
{
    public class DLog
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;

        public async static Task Acceso(LogAccesoVM log)
        {
            var ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;
            _client = new MongoClient(Comun.ConfigApp.GetSection("CADENA-CONEXION-lOG-" + ambiente).Value);
            _database = _client.GetDatabase("_log");

            var collection = _database.GetCollection<BsonDocument>("LogAcceso");
            await collection.InsertOneAsync(log.ToBsonDocument());
        }

        public async static Task Auditoria(LogAuditoriaVM log)
        {
            var ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;
            _client = new MongoClient(Comun.ConfigApp.GetSection("CADENA-CONEXION-lOG-" + ambiente).Value);
            _database = _client.GetDatabase("_log");

            var collection = _database.GetCollection<BsonDocument>("LogAuditoria");
            await collection.InsertOneAsync(log.ToBsonDocument());
        }

        public async static Task Error(LogErrorVM log)
        {
            try
            {
                var ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;
                _client = new MongoClient(Comun.ConfigApp.GetSection("CADENA-CONEXION-lOG-" + ambiente).Value);
                _database = _client.GetDatabase("_log");

                var collection = _database.GetCollection<BsonDocument>("LogError");
                await collection.InsertOneAsync(log.ToBsonDocument());
            }
            catch
            {
                AnadirLogErrorArchivo(log);
            }
        }      

        private static void AnadirLogErrorArchivo(LogErrorVM error)
        {
            string rutaApp = AppDomain.CurrentDomain.BaseDirectory;

            string carpetaLogs = "Logs";

            string nombreArchivo = string.Format("{0}-{1}-{2}.log.txt",
                                DateTime.Today.Day.ToString().PadLeft(2, '0'),
                                DateTime.Today.Month.ToString().PadLeft(2, '0'),
                                DateTime.Today.Year);

            if (!Directory.Exists(string.Format("{0}{1}", rutaApp, carpetaLogs)))
            {
                Directory.CreateDirectory(string.Format("{0}{1}", rutaApp, carpetaLogs));
            }

            using (StreamWriter writetext = new StreamWriter(string.Format(@"{0}{1}\{2}", rutaApp, carpetaLogs, nombreArchivo), true))
            {
                writetext.WriteLine("===========Inicio de Error============= ");
                writetext.WriteLine("Fecha y Hora del error : " + error.Fecha + " " + error.Hora);
                writetext.WriteLine("Se registró un error en el espacio de nombre : " + error.EspacioNombre);
                writetext.WriteLine("Se registró un error en la clase : " + error.Clase);
                writetext.WriteLine("Se registró un error en el método : " + error.Metodo);
                writetext.WriteLine("Mensaje error: " + error.Error);
                writetext.WriteLine("============Fin de Error=============== ");
            }
        }
    }
}
