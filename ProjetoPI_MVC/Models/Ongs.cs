namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ongs:Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ongs()
        {
            Voluntarios = new HashSet<Voluntarios>();
        }

        /*[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }*/

        [Required]
        [StringLength(45)]
        public string RazaoSocial { get; set; }

        [Required]
        [StringLength(14)]
        public string CNPJ { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(45)]
        public string Representante { get; set; }

        [Required]
        [StringLength(45)]
        public string Cargo { get; set; }

        //public virtual Usuarios Usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voluntarios> Voluntarios { get; set; }
    }
}
