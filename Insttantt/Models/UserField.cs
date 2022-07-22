
namespace Insttantt.Models
{
    public class UserField : BaseModel
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public FielsCatalog FielsCatalog { get; set; }
        public Guid FielsCatalogId { get; set; }
        public string Value { get; set; }
    }
}
