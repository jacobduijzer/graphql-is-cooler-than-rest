namespace SnackFlix.Snacks;

public class SnackRecommendationService
{
    private const int NumberOfRecommendations = 3;
    
    public List<string> Get(List<string> genres)
    {
        foreach (var combo in ComboSnacks.Keys.Where(combo => combo.IsSubsetOf(genres)))
            return ComboSnacks[combo];

        var recommendedSnacks = genres
            .Where(genre => GenreSnacks.ContainsKey(genre))
            .SelectMany(genre => GenreSnacks[genre])
            .Distinct()
            .Take(NumberOfRecommendations) 
            .ToList();

        return recommendedSnacks.Count != 0
            ? recommendedSnacks
            : ["Popcorn", "Cookies", "Water"];
    }

    private static Dictionary<string, List<String>> GenreSnacks => new Dictionary<string, List<string>>
    {
        { "Crime", ["Dark Chocolate", "Espresso", "Cheese Platter"] },
        { "Drama", ["Herbal Tea", "Macarons", "Biscotti"] },
        { "Action", ["Nachos", "Energy Drinks", "Popcorn"] },
        { "Adventure", ["Trail Mix", "Granola Bars", "Bubble Tea"] },
        { "Sci-Fi", ["Futuristic Gummies", "Space Ice Cream", "Energy Bars"] },
        { "Romance", ["Strawberries", "Champagne", "Macarons"] },
        { "Biography", ["Assorted Nuts", "Coffee", "Mini Sandwiches"] },
        { "History", ["Pretzels", "Tea", "Cookies"] },
        { "Fantasy", ["Themed Cupcakes", "Fizzy Drinks", "Popcorn"] },
        { "Animation", ["Milkshakes", "Candy", "Popcorn"] },
        { "Thriller", ["Spicy Nachos", "Root Beer", "Jalapeño Chips"] },
        { "Family", ["Pizza Slices", "Cookies", "Hot Chocolate"] },
        { "Comedy", ["Pretzels", "Candy", "Soda"] }
    };
    
    private static Dictionary<HashSet<string>, List<string>> ComboSnacks => new Dictionary<HashSet<string>, List<string>>(HashSetComparer<string>.Default)
    {
        { ["Action", "Sci-Fi"], ["Energy Bars", "Space Ice Cream", "Futuristic Gummies"] },
        { ["Drama", "Romance"], ["Strawberries and Champagne", "Macarons", "Cheesecake"] },
        { ["Adventure", "Fantasy"], ["Themed Cupcakes", "Trail Mix", "Fizzy Drinks"] },
        { ["Crime", "Thriller"], ["Espresso", "Dark Chocolate", "Spicy Nachos"] },
        { ["Family", "Animation"], ["Popcorn", "Milkshakes", "Mini Pizzas"] },
        { ["Comedy", "History"], ["Pretzels", "Root Beer", "Classic Butter Cookies"] }
    };
}