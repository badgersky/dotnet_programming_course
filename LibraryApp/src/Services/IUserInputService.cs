namespace Services;

public interface IUserInputService
{
    string ReadString(string prompt);
    int ReadInt(string prompt);
    string ReadFormat(string prompt);
    string ReadIsbn(string prompt);
    bool IsValidIsbn13(string isbn);
    bool IsValidIsbn10(string isbn);
    event Action<string>? Notification;
}