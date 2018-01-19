namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apoios
    {
        public Apoios()
        {
            Valor = 0;
        }
        public int IdProjeto { get; set; }

        public int IdDoador { get; set; }

        public decimal Valor { get; set; }

        public virtual Doadores Doadores { get; set; }

        public virtual Projetos Projetos { get; set; }
    }
}
