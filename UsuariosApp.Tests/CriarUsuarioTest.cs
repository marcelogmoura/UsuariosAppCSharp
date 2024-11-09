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
    public class CriarUsuarioTest
    {
        [Fact]
        public async Task Criar_Usuario_Com_Sucesso_Test()
        {
            var faker = new Faker("pt_BR");

            var request = new CriarUsuarioRequestDto
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "Admin@123"
            };

            var json = new StringContent(JsonConvert.SerializeObject
                (request), Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();

            var response = await client.PostAsync("/api/usuarios/criar", json);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact(Skip = "nao implementado")]
        public async Task Nao_Permitir_Email_Duplicado_Test()
        {

        }





    }
}
