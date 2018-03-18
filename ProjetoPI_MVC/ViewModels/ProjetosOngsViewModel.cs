using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoPI_MVC.Models;
namespace ProjetoPI_MVC.ViewModels
{
    public class ProjetosOngsViewModel
    {
        public List<Projetos> Projetos { get; set; }
        public List<Ongs> Ongs { get; set;}
        public ProjetosOngsViewModel()
        {
            ProjetoPI_MVCContext bd = new ProjetoPI_MVCContext();
            Projetos = bd.Projetos.OrderByDescending(p => p.Id).Take(3).ToList();
            Ongs = bd.Usuarios.OfType<Ongs>().OrderByDescending(o => o.Id).Take(3).ToList();
        }

        /// <summary>
        /// retorna os objetos(Projetos ou Ongs) que contenham a string busca em alguma de suas propriedades
        /// </summary>
        /// <param name="busca"></param>
        public ProjetosOngsViewModel(string busca)
        {
            busca = busca.ToLower();
            Projetos = new ProjetoPI_MVCContext().Projetos.Where(p => p.Nome.ToLower().Contains(busca) || p.Descricao.ToLower().Contains(busca) || p.Tipo.ToLower().Contains(busca) || p.Meta.ToLower().Contains(busca) || p.Usuarios.Nome.ToLower().Contains(busca)).OrderByDescending(p => p.Id).ToList();
            Ongs = new ProjetoPI_MVCContext().Usuarios.OfType<Ongs>().Where(o => o.Frase.ToLower().Contains(busca) || o.Enderecos.Bairro.ToLower().Contains(busca) || o.Enderecos.Cidade.ToLower().Contains(busca) || o.Enderecos.Estado.ToLower().Contains(busca) || o.Nome.ToLower().Contains(busca) || o.Sobre.Any(s => s.Texto.ToLower().Contains(busca) || s.Titulo.ToLower().Contains(busca))).OrderByDescending(o => o.Id).ToList();
        }
    }
}