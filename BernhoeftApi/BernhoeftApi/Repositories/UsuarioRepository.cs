﻿using BernhoeftApi.Contexts;
using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Model.InputModels.Usuario;

namespace BernhoeftApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        BernhoeftContext ctx = new BernhoeftContext();

        public void Atualizar(int id, AtualizarUsuarioInputModel UsuarioAtualizado)
        {
            //Busca um Usuariol através do id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica as informações

            if (UsuarioAtualizado.TipoUsuarioId != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.TipoUsuarioId = UsuarioAtualizado.TipoUsuarioId;
            }

            if (UsuarioAtualizado.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.Nome = UsuarioAtualizado.Nome;
            }

            if (UsuarioAtualizado.Email != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
            }

            if (UsuarioAtualizado.Senha != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }
            // Atualiza o Usuariol que foi buscado
            ctx.Usuarios.Update(UsuarioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario? BuscarPeloNome(string nome)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Nome == nome);
        }

        public Usuario? BuscarPorId(int id)
        {
            // Retorna o primeiro Usuariol encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoUsuariol
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.Usuarios.Remove(UsuarioBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            // Retorna o Usuariol encontrado através do e-mail e da senha
            return ctx.Usuarios.FirstOrDefault(l => l.Email == email && l.Senha == senha);
        }
    }
}
