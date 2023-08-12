using BernhoeftApi.Contexts;
using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Model.InputModels.Produto;
using BernhoeftApi.Model.InputModels.TipoUsuario;
using BernhoeftApi.Model.InputModels.Usuario;

namespace BernhoeftApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        BernhoeftContext ctx = new BernhoeftContext();

        public void Atualizar(int id, AtualizarTipoUsuarioInputModel UsuarioAtualizado)
        {
            //Busca um Usuariol através do id
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            // Verifica as informações

            if (UsuarioAtualizado.TipoUsusario != null)
            {
                // Atribui os novos valores aos campos existentes
                TipoUsuarioBuscado.TipoUsusario = UsuarioAtualizado.TipoUsusario;
            }

            if (UsuarioAtualizado.TipoUsusario != null)
            {
                // Atribui os novos valores aos campos existentes
                TipoUsuarioBuscado.TipoUsusario = UsuarioAtualizado.TipoUsusario;
            }
            // Atualiza o Usuariol que foi buscado
            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPeloTipo(string tipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(u => u.TipoUsusario == tipoUsuario);
        }

        public TipoUsuario? BuscarPorId(int id)
        {
            // Retorna o primeiro Usuariol encontrado para o ID informado
            return ctx.TipoUsuarios.FirstOrDefault(u => u.TipoUsuarioId == id);
        }

        public void Cadastrar(TipoUsuario novoUsuario)
        {
            // Adiciona este novoUsuariol
            ctx.TipoUsuarios.Add(novoUsuario);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
