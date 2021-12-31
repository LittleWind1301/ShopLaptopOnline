using ModelWeb.EF1;
using ModelWeb.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.Dao
{
    public class OrderDao
    {
        private LaptopDBContext db = null;
        public OrderDao()
        {
            db = new LaptopDBContext();
        }

        public long Insert(Order order)
        {
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order.ID;
            }
            catch
            {
                return 0;
            }
            
        }
        public IEnumerable<Order> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenNguoiNhan.Contains(searchString) || x.PhoneNumber.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public List<OrderDetail> ListById(long id)
        {
            return db.OrderDetails.Where(x => x.OrderID == id).ToList();
        }
        public List<ViewCartDeltail> ListViewCart(long OrderId)
        {
            var model = from a in db.tProducts
                        join b in db.OrderDetails on a.ID equals b.ProductID
                        where b.OrderID == OrderId
                        select new ViewCartDeltail()
                        {
                            Id = a.ID,
                            Images = a.Image,
                            Name = a.Name,
                            Price = a.Price,
                            Quantity = b.Quantity
                        };
            return model.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var order = db.Orders.Find(id);
                var orderDetail = db.OrderDetails.SingleOrDefault(x => x.OrderID == id);

                db.Orders.Remove(order);
                db.OrderDetails.Remove(orderDetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
