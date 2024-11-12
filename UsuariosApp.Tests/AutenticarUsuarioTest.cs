using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;
using Xunit;

namespace UsuariosApp.Tests
{
    public class AutenticarUsuarioTest
    {
        [Fact]
        public async Task Autenticar_Usuario_Com_Sucesso_Test()
        {
            var faker = new Faker("pt_BR");
            var requestCriarUsuario = new CriarUsuarioRequestDto
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste2024"
            };
            var jsonCriarUsuario = new StringContent
            (JsonConvert.SerializeObject
            (requestCriarUsuario), Encoding.UTF8, "application/json");
          
            var client = new WebApplicationFactory
            <Program>().CreateClient();
            await client.PostAsync("/api/usuarios/criar", jsonCriarUsuario);
            var requestAutenticarUsuario = new AutenticarUsuarioRequestDto
            {
                Email = requestCriarUsuario.Email,
                Senha = requestCriarUsuario.Senha
            };
            var jsonAutenticarUsuario = new StringContent
            (JsonConvert.SerializeObject
            (requestAutenticarUsuario),
            Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync
            ("/api/usuarios/autenticar", jsonAutenticarUsuario);
           
            response.StatusCode
            .Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Acesso_Negado_Test()
        {
            var faker = new Faker("pt_BR");
            var request = new AutenticarUsuarioRequestDto
            {
                Email = faker.Internet.Email(),
                Senha = "@Teste2024"
            };
            var json = new StringContent
            (JsonConvert.SerializeObject(request),
            Encoding.UTF8, "application/json");
            var client = new WebApplicationFactory
            <Program>().CreateClient();
            var response = await client.PostAsync
            ("/api/usuarios/autenticar", json);
            response.StatusCode
            .Should().Be(HttpStatusCode.Unauthorized);
            var mensagem = await response.Content.ReadAsStringAsync();
            mensagem
            .Should().Contain("usuario/email invalido");
        }
    }
}
