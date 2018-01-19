namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doadores:Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doadores()
        {
            Apoios = new HashSet<Apoios>();
            Voluntarios = new HashSet<Voluntarios>();
        }

        /*[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }*/

        [Required,StringLength(11, ErrorMessage = "Informe um CPF valido")]
        public string CPF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apoios> Apoios { get; set; }

        //public virtual Usuarios Usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voluntarios> Voluntarios { get; set; }
    }
}
