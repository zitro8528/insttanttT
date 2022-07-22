using Insttantt.Models;

namespace Insttantt.Steps
{
    public interface IRunStep
    {
        Task<string> RunStep(List<UserField> userFields);
    }
}
