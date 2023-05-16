using Entities.Abstract;

namespace Entities.Concrete
{
    public class Parametre : IEntity
    {
        public int Id { get; set; }

        public string Adi { get; set; } 

        public string Aciklama { get; set; }
    }
}
