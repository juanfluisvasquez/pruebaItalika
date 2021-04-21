using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoData
{
    public class myHelperData
    {
        ProductoItalikaEntities myContext;
        public myHelperData()
        {

            var entityBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = "data source=LAPTOP-THQIV9V4;initial catalog=ProductoItalika;persist security info=True;user id=sa;password=Pass2017;";
            entityBuilder.Metadata = @"res://*/myModel.csdl|res://*/myModel.ssdl|res://*/myModel.msl";

            myContext = new ProductoItalikaEntities(entityBuilder.ToString());
        }


        public List<MotosItalika> GetMotos()
        {
            myContext.Configuration.ProxyCreationEnabled = false;
            myContext.Configuration.LazyLoadingEnabled = false;
            return myContext.MotosItalika.ToList();

        }

        public List<Tipo> GetTipo()
        {
            myContext.Configuration.ProxyCreationEnabled = false;
            myContext.Configuration.LazyLoadingEnabled = false;
            return myContext.Tipo.ToList();
        }

        public void SaveMotos(MotosItalika _moto)
        {
            myContext.Set<MotosItalika>().Add(_moto);
            myContext.SaveChanges();

        }

        public void DELETEMotos(int id)
        {
            var value = myContext.MotosItalika.Where(x => x.idMotos == id).SingleOrDefault();
            myContext.Set<MotosItalika>().Remove(value);
            myContext.SaveChanges();

        }

    }
}
