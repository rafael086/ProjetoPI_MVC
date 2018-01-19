namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public abstract partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            IdImagem = 1;
            Comentarios = new HashSet<Comentarios>();
            Projetos = new HashSet<Projetos>();
            Sobre = new HashSet<Sobre>();

        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(45),DataType(DataType.Password)]
        public string Senha { get; set; }

        [NotMapped,Compare("Senha",ErrorMessage = "Senhas invalidas"),DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }

        public int IdEndereco { get; set; }

        public int IdImagem { get; set; }

        [StringLength(100)]
        public string Frase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentarios> Comentarios { get; set; }

        //public virtual Doadores Doadores { get; set; }

        public virtual Enderecos Enderecos { get; set; }

        public virtual Imagens Imagens { get; set; }

        //public virtual Ongs Ongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projetos> Projetos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sobre> Sobre { get; set; }
    }
}
