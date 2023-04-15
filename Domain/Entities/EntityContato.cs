namespace Domain.Entities
{
    public class EntityContato
    {
        public int Id { get; set; }
        public string ?Telefone { get; set; }
        public string? Email { get; set; }
        public string? whatsApp { get; set; }
        public int PessoaId { get; set; }
        public virtual EntityCadastrosPessoa Pessoa { get;set; }

    }
}
