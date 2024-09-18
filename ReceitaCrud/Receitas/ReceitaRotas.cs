using System;
using ReceitaCrud.Receitas.Dtos;
using Microsoft.EntityFrameworkCore;
using ReceitaCrud.Data;

namespace ReceitaCrud.Receitas;

public static class ReceitaRotas
{
    public static void AdicionarRotasdeReceita(this WebApplication app)
    {
        var rotasReceita = app.MapGroup("api/receitas");

        rotasReceita.MapPost("", async (CriarReceitaRequest request, ApplicationDbContext context) =>
        {
            var receitaExiste = await context.Receitas.AnyAsync(receita => receita.Nome.Equals(request.Nome));

            

            if (receitaExiste) return Results.Conflict("Já existe uma receita com este nome!!");

            var novaReceita = new Receita(request.Nome);

            context.Receitas.Add(novaReceita);

            //await context.Receitas.AnyAsync(novaReceita);
            await context.SaveChangesAsync();

            return Results.Ok(novaReceita);
        });

        rotasReceita.MapGet("", async (ApplicationDbContext context) =>
        {
            var receitas = await context.Receitas.ToListAsync();

            return Results.Ok(receitas);
        });

        rotasReceita.MapPut("{id:int}", async (int id, AlterarReceitaRequest request, ApplicationDbContext context) =>
        {
            var receita = await context.Receitas.SingleOrDefaultAsync(receita => receita.Id.Equals(id));

            if (receita == null) return Results.NotFound();

            receita.AtualizarNome(request.Nome);

            return Results.Ok(receita);
        });

        rotasReceita.MapDelete("{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var receita = await context.Receitas.SingleOrDefaultAsync(receita => receita.Id.Equals(id));

            if (receita == null) return Results.NotFound();

            receita.Excluir();

            await context.SaveChangesAsync();

            return Results.Ok();
        });


    }

}
