using Entities.DTOs;

namespace WEB.ViewModels
{
    public class StadiumViewModel
    {
        public StadiumViewModel()
        {
            StadiumList = new List<StadiumDetailDTO>();
        }

        public List<StadiumDetailDTO> StadiumList; 
    }
}
