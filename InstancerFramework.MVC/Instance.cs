using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InstancerFramework.MVC
{
    public static class Instance
    {
        public static TEntity NewInstance<TEntity>(FormCollection formCollection) where TEntity : class
        {
            Type type = typeof(TEntity);

            var builderParameters = type.GetConstructors().FirstOrDefault().GetParameters();

            int numberOfBuilderParameters = builderParameters.Count();

            object[] parametros = new object[numberOfBuilderParameters];

            int cont = 0;
            foreach (var item in builderParameters)
            {
                if (formCollection.GetValue(item.Name) != null)
                {
                    var tipoItem = item.ParameterType;
                    parametros.SetValue(formCollection.GetValue(item.Name).ConvertTo(tipoItem), cont);

                    cont++;
                }
            }

            var model = (TEntity)Activator.CreateInstance(type, parametros);

            return model;
        }
    }
}
