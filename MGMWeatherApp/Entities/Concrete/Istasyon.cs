using Entities.Abstract;

namespace Entities.Concrete
{
    public class Istasyon : IEntity
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public DateTime AcilisTarihi { get; set; }        

        public int SehirId { get; set; }
    }
}
