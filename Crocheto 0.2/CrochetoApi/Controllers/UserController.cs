using CrochetoApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;

namespace CrochetoApi.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Registrar usuario
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Models.User user)
        {
            // Validar usuario
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Hashear la contraseña
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            // Agregar usuario a la base de datos
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // Loguear usuario
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.User user)
        {
            // Buscar usuario en la base de datos
            var usersDB = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            // Validar usuario
            if (usersDB == null || !BCrypt.Net.BCrypt.Verify(user.Password, usersDB.Password))
            {
                return Unauthorized();
            }

            // Generar token JWT
            var token = GenerateJwtToken(usersDB);

            return Ok(new { token, Rol = usersDB.Rol, Id = usersDB.Id });
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<Models.User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Password = null;

            return user;
        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Models.User updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Rol = updatedUser.Rol;
            user.HasFingerprintRegistered = updatedUser.HasFingerprintRegistered;
            user.SubscriptionType = updatedUser.SubscriptionType;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new ObjectResult(user);
        }




        private string GenerateJwtToken(Models.User user)
        {
            // Configurar claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Rol)
        };

            // Configurar la clave de seguridad
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_my_secret_key_my_secret_key"));

            // Crear credenciales
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Generar token
            var token = new JwtSecurityToken(
                issuer: "CrochetoApi",
                audience: "CrochetoApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
