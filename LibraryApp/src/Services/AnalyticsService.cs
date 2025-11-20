using Domain;

namespace Services;

public class AnalyticsService : IAnalyticService
{
    private ILibraryService _library;

    public AnalyticsService(ILibraryService library)
    {
        _library = library;
    }

    public int AllItemsCount()
    {
        return _library.GetItems().Count();
    }

    public int AllUsersCount()
    {
        return _library.GetUsers().Count();
    }

    public int AllRentalsCount()
    {
        return _library.GetRentals().Count();
    }

    public int AllActiveRentalsCount()
    {
        var res = 0;
        var rentals = _library.GetRentals();
        foreach (var rental in rentals)
        {
            if (!rental.Returned) res++;
        }
        
        return res;
    }

    public LibraryItem? MostCommonRental()
    {
        if (!_library.GetRentals().Any()) return null;
        
        var r = _library.GetRentals()
            .GroupBy(r => r.Item)
            .OrderByDescending(g => g.Count())
            .First().Key;
        
        return r;
    }

    public User? MostActiveUser()
    {
        if (!_library.GetUsers().Any()) return null;
        
        var u = _library.GetRentals()
            .GroupBy(r => r.User)
            .OrderByDescending(g => g.Count())
            .First().Key;
        
        return u;
    }
}