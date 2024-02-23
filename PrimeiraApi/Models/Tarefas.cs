namespace PrimeiraApi.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public bool Status { get; set; }


        public Tarefas(int id, string nome, bool status)
        {
            Id = id;
            Nome = nome;
            Status = status;

        }

    }

}
