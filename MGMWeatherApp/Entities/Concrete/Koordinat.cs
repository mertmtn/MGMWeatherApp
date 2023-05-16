using Entities.Abstract;

namespace Entities.Concrete
{
    public class Koordinat : IEntity
    {
        public int Id { get; set; }

        public int SehirIlceId { get; set; }

        public int Enlem { get; set; }

        public int Boylam { get; set; }
    }
}
