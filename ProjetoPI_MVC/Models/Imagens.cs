namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Imagens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imagens()
        {
            Projetos = new HashSet<Projetos>();
            Sobre = new HashSet<Sobre>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nome { get; set; }

        /// <summary>
        /// Salva a imagem na pasta de upload e no banco
        /// </summary>
        public Imagens SalvaImagem(string nomeImagem)
        {

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projetos> Projetos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sobre> Sobre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
