using Domain.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Admin;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;

    public CreateAccountScenarioProvider(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (!_adminService.IsLoggedIn)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_adminService);
        return true;
    }
}