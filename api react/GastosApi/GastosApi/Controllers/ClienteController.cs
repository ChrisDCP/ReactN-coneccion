using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using GastosApi.models;

namespace GastosApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _config;

        public UsuarioController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarioId(int UsuarioId)
        {
            using var conexion = new SqlConnection(_config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", UsuarioId);
            var oUsuario = conexion.Query<Usuario>("SelUsuario", param, commandType: System.Data.CommandType.StoredProcedure)
           .SingleOrDefault();
            return Ok(oUsuario);

        }

        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> InsertUsuario(Usuario user)
        {
            using var conexion = new SqlConnection(_config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@nombre", user.UserName);
            param.Add("@password", user.Password);
            var oUsuario = conexion.Query<Usuario>("InsUsuario", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oUsuario);
        }

        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> ActUsuario(Usuario user, int UserId)
        {
            using var conexion = new SqlConnection(_config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", user.UserID);
            param.Add("@nombre", user.UserName);
            param.Add("@password", user.Password);
            var oUsuario = conexion.Query<Usuario>("UpdUsuario", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oUsuario);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<List<Usuario>>> DelUsuario(int UsuarioID)
        {
            using var conexion = new SqlConnection(_config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", UsuarioID);
            var oUsuario = conexion.Query<Usuario>("DelUsuario", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oUsuario);
        }



    }
}
