namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Enderecos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enderecos()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(10)]
        public string Numero { get; set; }

        [Required]
        [StringLength(45)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(45)]
        public string Rua { get; set; }

        [Required]
        [StringLength(45)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(45)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
