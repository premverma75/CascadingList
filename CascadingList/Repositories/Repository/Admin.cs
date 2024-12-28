using CascadingList.Models;
using CascadingList.Repositories.IRepository;

namespace CascadingList.Repositories.Repository
{
    public class Admin : IAdmin
    {
        AppDbContext _db;
        public Admin(AppDbContext db)
        {
            _db = db;
        }
        public List<Country> GetCountries()
        {
            return _db.Countries.ToList();
        }
        public List<State> GetStates(int countryId)
        {
            return _db.States.Where(s => s.CountryId == countryId).ToList();
        }
        public List<City> GetCities(int stateId)
        {
            return _db.Cities.Where(c => c.StateId == stateId).ToList();
        }
        public bool AddRegister(Register register)
        {
            _db.Registers.Add(register);
            return _db.SaveChanges() > 0;
        }
        public void AddLogin(Login login)
        {
            _db.Logins.Add(login);
            _db.SaveChanges();
        }

        public bool IsAuthenticated(Login login)
        {
            var user = _db.Registers.Where(l => l.UserName == login.UserName && l.Password == login.Password).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public Register GetUsers(string userName)
        {
            return _db.Registers.Where(r => r.UserName == userName).FirstOrDefault();

        }

        public List<Register> GetUsers()
        {
            List<Register> list = _db.Registers.ToList();
            return list;
        }

        public void UpdateUser(Register register)
        {
            _db.Registers.Update(register);
            _db.SaveChanges();

        }

        public void DeleteUser(int id)
        {
            var user = _db.Registers.Where(r => r.Id == id).FirstOrDefault();
            _db.Registers.Remove(user);
            _db.SaveChanges();

        }

        public bool Authenticate(Login login)
        {
           bool IsLoggedIn=false;

            _db.Logins.Add(login);
           if(_db.SaveChanges()>0)
            {
                IsLoggedIn = true;
            }
            
            return IsLoggedIn; // Ensure a boolean value is returned
        }
    }
}
