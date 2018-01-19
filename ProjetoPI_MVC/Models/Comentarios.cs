namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comentarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Você precisa digitar algo"),StringLength(245, ErrorMessage = "Limite de 245 caracteres"),DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        public int IdUsuario { get; set; }

        public int IdProjeto { get; set; }

        public virtual Projetos Projetos { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
