namespace BernhoeftApi.Model.InputModels.Usuario
{
    public class AtualizarUsuarioInputModel
    {
        public int TipoUsuarioId { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
