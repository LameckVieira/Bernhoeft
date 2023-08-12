namespace BernhoeftApi.Model.InputModels.Produto
{
    public class AtualizarProdutoInputModel
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public double Preco { get; set; }
        public bool Situacao { get; set; }
    }
}
