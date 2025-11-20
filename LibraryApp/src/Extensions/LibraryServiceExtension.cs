using Domain;
using Services;

namespace Extensions;

public static class LibraryServiceExtensions
{
    public static IEnumerable<LibraryItem> GetAvailableItems(this ILibraryService libraryService)
    {
        return libraryService.GetItems()
            .Where(item => !libraryService.GetRentals()
                .Any(rental => rental.Item.Id == item.Id && rental.Returned));
    }

    public static int CountAvailableItems(this ILibraryService libraryService)
    {
        return libraryService.GetAvailableItems().Count();
    }
}