using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoPI_MVC.MetodosDeExtensao
{
    public static class ConfiguracoesBD
    {
        public static StringPropertyConfiguration Unique(this StringPropertyConfiguration property, string indexName, int pos)
        {
            IndexAttribute indexAttribute = new IndexAttribute(indexName, pos) { IsUnique = true };
            IndexAnnotation indexAnnotation = new IndexAnnotation(indexAttribute);
            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}