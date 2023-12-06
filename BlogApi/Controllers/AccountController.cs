using BlogApi.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/account")]
public class AccountController : ControllerBase
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;

    public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] InputModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new Usuario
            {
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Registro bem-sucedido, deve fazer login automaticamente após o cadastro
                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok(new { Message = "Registro bem-sucedido! Usuário logado automaticamente." });
            }
            else
            {
                // Ocorreu um erro durante o registro
                return BadRequest(result.Errors);
            }
        }

        // Se o modelo não for válido
        return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
    }



    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.email, model.senha, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            // O login foi bem-sucedido
            return Ok(new { Message = "Login bem-sucedido!" });
        }
        else
        {
            // Ocorreu um erro durante o login
            return Unauthorized(new { Message = "Login falhou. Verifique suas credenciais." });
        }
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();


        return Ok(new { Message = "Logout bem-sucedido!" });
    }
}
