using Projekt.Domain;

namespace Projekt.Services;

public static class RentalPolicy
{
    public static int GetMaxActiveRentals(User user)
    {
        return user.UserType == UserType.Student ? 2 : 4;
    }

    public static int GetRentalDays(User user)
    {
        return user.UserType == UserType.Student ? 7 : 14;
    }
}
