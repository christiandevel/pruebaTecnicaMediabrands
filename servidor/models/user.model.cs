namespace servidor.models;

public class User
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
	public int Age { get; set; }
	public int Phone { get; set; }
	public string Email { get; set; }
}