namespace LockBox.ViewModels;

public class SecurityQuestion
{
	public string Question { get; set; }
	public SecurityQuestion(string question)
	{
		Question = question;
	}
}