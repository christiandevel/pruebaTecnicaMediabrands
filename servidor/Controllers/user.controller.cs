using Microsoft.AspNetCore.Mvc;
using servidor.models;
using servidor.services;

namespace servidor.controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

	IUserServices _services;

	public UserController(IUserServices services)
	{
		_services = services;
	}

	[HttpGet]
	public IActionResult Get()
	{
		return Ok(_services.Get());
	}
	
	[HttpGet("{id}")]
	public IActionResult Get(Guid id)
	{
		var user = _services.Get().FirstOrDefault(x => x.Id == id);
		if (user == null)
		{
			return NotFound();
		}
		return Ok(user);
	}

	[HttpPost]
	public async Task<IActionResult> Save([FromBody] User user)
	{
		await _services.Save(user);
		return Ok(user);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] User user)
	{
		await _services.Update(id, user);
		return Ok(user);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _services.Delete(id);
		// RESPONSE JSON MESSAGE
		return Ok(new { message = "User deleted" });
	}
}