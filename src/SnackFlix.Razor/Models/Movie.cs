namespace SnackFlix.Razor.Models;

public record Movie(int Id, string Title, string Description, int Year, string[] Genres);