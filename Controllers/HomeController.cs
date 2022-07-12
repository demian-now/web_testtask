using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskWeb.Models;
using System.Text;

namespace TestTaskWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        OrderContext db = new OrderContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewOrder()
        {
            return View();
        }

        public async Task OrdersList()
        {
            Response.ContentType = "text/html;charset=utf-8";
            StringBuilder stringBuilder = new StringBuilder(@"
                    <h2>Список заказов</h2>
                    <form method='get'>
                        <input type='submit' value='Обновить' />
                    </form>
                    </br>
                    </br>
                    <a href='/Home/NewOrder/' class='button'> Вернуться к форме оформления заказа </a>
                    </br>
                    </br>"
                );
            var orders = db.Orders;
            foreach (var i in orders) 
                stringBuilder.Append(i.ToString());
            await Response.WriteAsync(stringBuilder.ToString());
        }

        [HttpPost]
        public IActionResult NewOrder(string DepartCity, string DepartAdd, string RecCity, string RecAdd, int Weigth, string Date)
        {
            var newOrder = new Order { 
                DepartureCity = DepartCity, 
                DepartureAddress = DepartAdd, 
                ReceivingCity = RecCity, 
                ReceivingAddress = RecAdd, 
                Weight = Weigth, 
                DepartureDate = Date };
            db.Orders.Add(newOrder);
            db.SaveChanges();
            return NewOrder();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}