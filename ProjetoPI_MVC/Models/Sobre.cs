namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sobre")]
    public partial class Sobre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Titulo { get; set; }

        [Required]
        public string Texto { get; set; }

        public int IdUsuario { get; set; }

        public int? IdImagem { get; set; }

        public virtual Imagens Imagens { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
