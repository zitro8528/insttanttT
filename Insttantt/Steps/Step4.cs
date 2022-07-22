using Insttantt.Models;

namespace Insttantt.Steps
{
    public class Step4 : IRunStep
    {
        public async Task<string> RunStep(List<UserField> userFields)
        {
            Console.WriteLine("Run Step4");
            return "Response Step4";
        }
    }
}
