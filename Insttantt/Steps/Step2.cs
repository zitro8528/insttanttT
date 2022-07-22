using Insttantt.Models;

namespace Insttantt.Steps
{
    public class Step2 : IRunStep
    {
        public async Task<string> RunStep(List<UserField> userFields)
        {
            Console.WriteLine("Run Step2");
            return "Response Step2";
        }
    }
}
