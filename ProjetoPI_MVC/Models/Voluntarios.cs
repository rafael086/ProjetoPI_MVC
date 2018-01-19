namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Voluntarios
    {
        public Voluntarios()
        {
            Situacao = "Em aguardo";
        }
        
        public int IdOng { get; set; }

        public int IdDoador { get; set; }

        [Required]
        [StringLength(15)]
        public string Situacao { get; set; }

        public virtual Doadores Doadores { get; set; }

        public virtual Ongs Ongs { get; set; }
    }
}
