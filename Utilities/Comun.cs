using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public static class Comun
    {
        public static IConfiguration ConfigApp { get; set; }

        public static bool In(this object me, params object[] set)
        {
            return set.Contains(me);
        }

        public static double ToDouble(Object objecto)
        {
            double numero = 0;

            try
            {
                numero = Convert.ToDouble(objecto);
            }
            catch
            {
            }

            return numero;
        }
        public static int ToInt(Object objecto)
        {
            int numero = 0;

            try
            {
                numero = Convert.ToInt32(objecto);
            }
            catch
            {
            }

            return numero;
        }
        public static short ToShort(Object objecto)
        {
            short numero = 0;

            try
            {
                numero = Convert.ToInt16(objecto);
            }
            catch
            {
            }

            return numero;
        }
        public static string ToString(Object objecto)
        {
            string cadena = string.Empty;

            try
            {
                cadena = Convert.ToString(objecto);
            }
            catch
            {
            }

            return cadena;
        }
        public static bool ToBoolean(Object objecto)
        {
            bool cadena = false;

            try
            {
                cadena = Convert.ToBoolean(objecto);
            }
            catch
            {
            }

            return cadena;
        }
        public static decimal ToDecimal(Object objecto)
        {
            decimal numero = 0;

            try
            {
                numero = Convert.ToDecimal(objecto);
            }
            catch
            {
            }

            return numero;
        }
        public static DateTime ToDate(Object objecto)
        {
            DateTime fecha = new DateTime(1900, 1, 1);

            try
            {
                fecha = Convert.ToDateTime(objecto);
            }
            catch
            {
            }

            return fecha;
        }

        public static string ConvertDateToString(DateTime fecha)
        {
            return fecha.ToString("ddd dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("es-EC"));
        }

        public static string SHA(string cadena)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(cadena);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return ConvertirBytesAString(hashBytes);
        }
        public static string ConvertirBytesAString(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
        public static string EncriptarBase64(string _cadenaAencriptar)
        {

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(_cadenaAencriptar);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string DesEncriptarBase64(string _cadenaAdesencriptar)
        {

            var base64EncodedBytes = System.Convert.FromBase64String(_cadenaAdesencriptar);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static byte[] ConvertirStreamAByte(Stream input)
        {

            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return bytes;
        }
        public static Stream ConvertirByteAStream(byte[] byteData)
        {
            return new MemoryStream(byteData);
        }
        public static string CrearMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static byte[] ComprimirArchivo(byte[] data)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }



    }
}
