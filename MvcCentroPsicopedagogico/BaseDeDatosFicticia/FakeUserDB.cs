using MvcCentroPsicopedagogico.Models;

namespace MvcCentroPsicopedagogico.BaseDeDatosFicticia
{
    public class FakeUserDB
    {
        public static List<LoginModel> Users = new List<LoginModel>
        {
            new LoginModel
            {
                Id=1,
                User ="admin",
                Password ="1234"
            }
      
        };
    }
}
