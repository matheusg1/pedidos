using Microsoft.EntityFrameworkCore;
using pedidos.Data;
using pedidos.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos.Services
{
    public class UsuariosService
    {
        private readonly AppDbContext _context;

        public UsuariosService(AppDbContext context)
        {
            _context = context;
        }

        public List<Usuario> BuscarUsuarios()
        {
            List<Usuario> usuarios = _context.Usuarios.AsNoTracking().ToList();
            return usuarios;
        }

        public Usuario CriarUsuario(string nome)
        {
            Usuario usuario = new Usuario
            {
                Nome = nome
            };
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }
    }
}
