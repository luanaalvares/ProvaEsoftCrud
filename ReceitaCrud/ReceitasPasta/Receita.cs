using System;
namespace ReceitaCrud.ReceitasPasta;

public class Receita
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int TempoPreparo { get; private set; }
    public double CustoAproximado { get; private set; }

    public Receita(string nome, int tempoPreparo, double custoAproximado)
    {
        Nome = nome;
        TempoPreparo = tempoPreparo;
        CustoAproximado = CustoAproximado;

    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }

    public void Excluir()
    {
        Nome = "";
    }

    public void AdicionarIngrediente()
    {
        //Item = item;

    }

    public void RemoverIngrediente()
    {
        //Item = "";
    }
}