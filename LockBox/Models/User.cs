namespace LockBox.ViewModels;

public class User
{
	public string Username { get; set; }
	public object Password { get; set; }
	public object SecurityQuestion { get; set; }
	public string SecurityAnswer { get; set; }
}