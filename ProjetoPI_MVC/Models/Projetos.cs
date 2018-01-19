namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Projetos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projetos()
        {
            Arrecadado = 0;
            Finalizado = false;
            Apoios = new HashSet<Apoios>();
            Comentarios = new HashSet<Comentarios>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int Banner { get; set; }

        [Required]
        [StringLength(45)]
        public string Meta { get; set; }

        public int IdUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string Tipo { get; set; }

        [Column(TypeName = "money")]
        public decimal Arrecadado { get; set; }

        public bool Finalizado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apoios> Apoios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentarios> Comentarios { get; set; }

        public virtual Imagens Imagens { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
