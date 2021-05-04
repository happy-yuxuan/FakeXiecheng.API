using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FakeXiecheng.API.Dtos;
using FakeXiecheng.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FakeXiecheng.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateController(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInmanager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInmanager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            // 1 验证用户名密码
            var loginResult = await _signInManager.PasswordSignInAsync(
                loginDto.Email,
                loginDto.Password,
                false,
                false);
            if (!loginResult.Succeeded)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(loginDto.Email);

            // 2 创建jwt

            // 2-1 header
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;

            // 2-2 payload
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                //new Claim(ClaimTypes.Role, "Admin")
            };

            // 2-3 获取用户权限
            var roleNames = await _userManager.GetRolesAsync(user);
            foreach(var roleName in roleNames)
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                claims.Add(roleClaim);
            }


            // 2-3 signiture
            var secreByte = Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]);
            var signingKey = new SymmetricSecurityKey(secreByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials);

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            // 3 return 200 ok + jwt
            return Ok(tokenStr);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            // 1 使用用户名创建用户对象
            var user = new ApplicationUser()
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            // 2 hash密码 保存用户
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            // 3 return
            return Ok();
        }
    }
}
