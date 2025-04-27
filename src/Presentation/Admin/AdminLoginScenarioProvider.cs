using Domain.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Admin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly IUserService _userService;

    public AdminLoginScenarioProvider(IAdminService adminService, IUserService userService)
    {
        _adminService = adminService;
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_adminService.IsLoggedIn || _userService.IsLoggedIn())
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_adminService);
        return true;
    }
}