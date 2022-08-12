
using DreamyApi.Dominio.Context;

namespace Negocio.BBLs
{

    public class NegocioBase
    {
        protected ApplicationDbContext db;
        public NegocioBase()
        {
            db = new ApplicationDbContext();
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            Dispose(disposing);
        }
    }
}
