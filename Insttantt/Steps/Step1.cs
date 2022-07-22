using Insttantt.Models;

namespace Insttantt.Steps
{
    public class Step1 : IRunStep
    {
        public async Task<string> RunStep(List<UserField> userFields)
        {
            Console.WriteLine("Run Step1");
            return "Response Step1";
        }
    }
}
