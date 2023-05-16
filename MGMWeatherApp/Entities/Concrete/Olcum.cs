using Entities.Abstract;

namespace Entities.Concrete
{
    public class Olcum : IEntity
    {
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        public int IstasyonId { get; set; }

        public int ParametreId { get; set; }

        public int Deger { get; set; }
    }
}
