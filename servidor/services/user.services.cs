using servidor.models;
using servidorContext;

namespace servidor.services;

public class UserServices : IUserServices
{

	UserContext _context;

	public UserServices(UserContext context)
	{
		_context = context;
	}

	public IEnumerable<User> Get()
	{
		return _context.users;
	}
	
	public async Task<User> Get(Guid id)
	{
		return await _context.users.FindAsync(id);
	}

	public async Task Save(User user)
	{
		user.Id = Guid.NewGuid();
		await _context.AddAsync(user);
		await _context.SaveChangesAsync();		
	}

	public async Task Update(Guid id, User user)
	{
		var userToUpdate = await _context.users.FindAsync(id);
		if (userToUpdate != null)
		{
			userToUpdate.Name = user.Name;
			userToUpdate.LastName = user.LastName;
			userToUpdate.Username = user.Username;
			userToUpdate.Age = user.Age;
			userToUpdate.Phone = user.Phone;
			userToUpdate.Email = user.Email;
			await _context.SaveChangesAsync();
		}
	}

	public async Task Delete(Guid id)
	{
		var userToDelete = await _context.users.FindAsync(id);
		if (userToDelete != null)
		{
			_context.users.Remove(userToDelete);
			await _context.SaveChangesAsync();
		}
	}
}

public interface IUserServices
{
	IEnumerable<User> Get();
	Task Save(User user);
	Task Update(Guid id, User user);
	Task Delete(Guid id);
}