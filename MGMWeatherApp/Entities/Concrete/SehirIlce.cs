using Entities.Abstract;

namespace Entities.Concrete
{
    public class SehirIlce : IEntity
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public int SehirId { get; set; }

        public int BolgeId { get; set; }
    }
}
