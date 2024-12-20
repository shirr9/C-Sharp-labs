using Domain.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.User;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;

    public UserLoginScenarioProvider(IUserService userService, IAdminService adminService)
    {
        _userService = userService;
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_userService.IsLoggedIn() || _adminService.IsLoggedIn)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLoginScenario(_userService);
        return true;
    }
}