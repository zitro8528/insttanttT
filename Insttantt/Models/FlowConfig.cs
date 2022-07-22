
namespace Insttantt.Models
{
    public class FlowConfig : BaseModel
    {
        public Flow Flow { get; set; }
        public Guid FlowId { get; set; }
        public StepsCatalog StepsCatalog { get; set; }  
        public Guid StepsCatalogId { get; set; }
        public int Level {get; set; }
    }
}
