using Microsoft.EntityFrameworkCore;
using servidor.models;

namespace servidorContext;

public class UserContext : DbContext
{
	public DbSet<User> users { get; set; }
	public UserContext(DbContextOptions<UserContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		List<User> users = new List<User>();
		users.Add(new User { Id = Guid.NewGuid(), Name = "Christian", LastName = "Moreno", Username = "chrismore", Age = 20, Phone = 123456789, Email = "cris@gmail.com" });

		modelBuilder.Entity<User>(user =>
		{

			user.ToTable("Users");
			user.HasKey(u => u.Id);
			user.Property(u => u.Name).IsRequired().HasMaxLength(50);
			user.Property(u => u.LastName).IsRequired().HasMaxLength(50);
			user.Property(u => u.Username).IsRequired().HasMaxLength(50);
			user.Property(u => u.Age).IsRequired();
			user.Property(u => u.Phone).IsRequired();
			user.Property(u => u.Email).IsRequired().HasMaxLength(50);
			user.HasData(users);
		});
	}
}