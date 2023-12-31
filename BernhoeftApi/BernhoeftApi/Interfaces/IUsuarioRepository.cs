﻿using BernhoeftApi.Domains;
using BernhoeftApi.Model.InputModels.Usuario;

namespace BernhoeftApi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        Usuario BuscarPorId(int id);


        /// <summary>
        /// Busca um usuario pelo nome
        /// </summary>
        /// <param name="nome">Nome do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        Usuario BuscarPeloNome(string nome);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novousuario">Objeto novousuario que será cadastrado</param>
        void Cadastrar(Usuario novousuario);

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int id, AtualizarUsuarioInputModel usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo usuario que foi buscado</returns>
        Usuario Login(string email, string senha);
    }
}
