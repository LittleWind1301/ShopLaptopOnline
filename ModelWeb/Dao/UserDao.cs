using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelWeb.Dao
{
    public class UserDao
    {
        LaptopDBContext db = null;
        public UserDao()
        {
            db = new LaptopDBContext();
        }
        public long Insert(User user)
        {
            try
            {
                var userName = db.Users.SingleOrDefault(x => x.UserName == user.UserName);
                if (userName != null)
                {
                    return 0;
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return user.ID;
                }
            }catch
            {
                return 0;
            }
        }

        public long InsertForFB(User user)
        {
           
            try
            {
                var userName = db.Users.SingleOrDefault(x => x.UserName == user.UserName);
                if (userName != null)
                {
                    return 0;
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return user.ID;
                }
            }
            catch
            {
                return 0;
            }
        }
        public bool Update(User user)
        {
            try
            {
                var model = db.Users.Find(user.ID);
                model.Name = user.Name;
                model.Adress = user.Adress;
                model.Email = user.Email;
                model.ModifiedBy = user.ModifiedBy;
                model.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
          
        }
        public IEnumerable<User> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)) ;
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public bool Login(string userName, string password)
        {
            var res = db.Users.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (res == null)
            {
                return false;
            }
            else if(res.Status == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;

            db.SaveChanges();
            return (bool)user.Status ;
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
           
        }
    }
}
