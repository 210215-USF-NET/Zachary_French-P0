using OSBL;

namespace OSUI
{
    public class ManagerMenu : IMenu
    {
        IStoreBL repo;
        public ManagerMenu(IStoreBL _repo)
        {
            repo = _repo;
        }

        public void Start()
        {

        }
    }
}