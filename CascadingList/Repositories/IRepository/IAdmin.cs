using CascadingList.Models;

namespace CascadingList.Repositories.IRepository
{
    public interface IAdmin
    {
        public bool IsAuthenticated(Login login);
        public List<Country> GetCountries();
        public List<State> GetStates(int countryId);
        public List<City> GetCities(int stateId);
        public bool AddRegister(Register register);
        public void AddLogin(Login login);
        public Register GetUsers(string userName);
        public List<Register> GetUsers();
        public void UpdateUser(Register register);
        public void DeleteUser(int id);
        bool Authenticate(Login login);
    }
}
