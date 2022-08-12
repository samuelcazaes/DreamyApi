using Dominio.Models.Log;
using DreamyApi.Dominio.Context;
using System;

namespace Negocio.BBLs
{

    public static class LogBBL
    {      
        public static void Write(string ExceptionName, string ExceptionMessage, string Message)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            try
            {              
                Log exceptionObject = new()
                {
                    ExceptionMessage = ExceptionMessage,
                    ExceptionName = ExceptionName,
                    Message = Message,
                };

                db.Logs.Add(exceptionObject);
            }
            catch (Exception ex)
            {
                Log exceptionObject = new()
                {
                    ExceptionMessage = ex.Message,
                    ExceptionName = ex.ToString(),
                    Message = ex.Message,
                };
                db.Logs.Add(exceptionObject);
            }              
        }
    }
}
