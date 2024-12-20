using Domain.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.User;

public class UserOperationsScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;

    public UserOperationsScenarioProvider(IUserService userService)
    {
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (!_userService.IsLoggedIn())
        {
            scenario = null;
            return false;
        }

        var scenarios = new List<IScenario>
        {
            new GetBalanceScenario(_userService),
            new WithdrawMoneyScenario(_userService),
            new ReplenishAccountScenario(_userService),
            new ViewTransactionHistoryScenario(_userService),
        };

        scenario = new CompositeScenario(scenarios);
        return true;
    }
}