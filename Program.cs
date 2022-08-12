using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/dado/{numeroDeFaces}", (

     [FromRoute] int numeroDeFaces

) => {

    if(numeroDeFaces <= 0){

        return Results.BadRequest(new {erro = "Somente dados com pelo menos uma face"});
    }

    int face = RandomNumberGenerator.GetInt32(1, numeroDeFaces);
    return Results.Ok (new {dado = $"{numeroDeFaces}", rolagem = face});

});

app.Run();
