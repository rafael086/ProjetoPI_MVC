using ProjetoPI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPI_MVC.ModelBinder
{
    public class UsuarioBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeValue = bindingContext.ValueProvider.GetValue("Tipo");
            var tipo = Type.GetType("ProjetoPI_MVC.Models."+(string)typeValue.ConvertTo(typeof(string)), true);
            if (!typeof(Usuarios).IsAssignableFrom(tipo))
            {
                throw new InvalidOperationException("Tipo errado");
            }
            var modelo = Activator.CreateInstance(tipo);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => modelo, tipo);
            return modelo;

        }
    }
}