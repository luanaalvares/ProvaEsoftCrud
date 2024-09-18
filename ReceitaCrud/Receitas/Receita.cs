using System;
namespace ReceitaCrud.Receitas;

public class Receita
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int TempoPreparo { get; private set; }
    public float CustoAproximado { get; private set; }

    public Receita(string nome)
    {
        Nome = nome;

    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }

    public void Excluir()
    {
        Nome = "";
    }
}