using Domain;

namespace Services;

public interface IAnalyticService
{
    int AllItemsCount();
    int AllUsersCount();
    int AllRentalsCount();
    int AllActiveRentalsCount();
    LibraryItem? MostCommonRental();
    User? MostActiveUser();
}