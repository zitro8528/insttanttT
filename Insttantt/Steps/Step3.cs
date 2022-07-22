using Insttantt.Models;

namespace Insttantt.Steps
{
    public class Step3 : IRunStep
    {
        public async Task<string> RunStep(List<UserField> userFields)
        {
            Console.WriteLine("Run Step3");
            return "Response Step3";
        }
    }
}
