using Grpc.Net.Client;
using GrpcCustomersService;
using Pop_Andreea_Georgiana_Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pop_Andreea_Georgiana_Lab2.Controllers
{

    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;
        public CustomersGrpcController()
        {
            channel = GrpcChannel.ForAddress("https://localhost:7021");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            CustomerList cust = client.GetAll(new Empty());
            return View(cust);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GrpcCustomersService.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new
               CustomerService.CustomerServiceClient(channel);
                var createdCustomer = client.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new CustomerService.CustomerServiceClient(channel);
            GrpcCustomersService.Customer customer = client.Get(new GrpcCustomersService.CustomerId() { Id = (int)id });

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            Empty response = client.Delete(new CustomerId()
            {
                Id = id
            });
            return RedirectToAction(nameof(Index));
        }

      /*  public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new CustomerService.CustomerServiceClient(channel);
            GrpcCustomersService.Customer = client.Get(new CustomerId() { Id = (int)id });
            if (GrpcCustomersService.Customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }*/
        [HttpPost]
        public IActionResult Edit(int id, GrpcCustomersService.Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);
                GrpcCustomersService.Customer response = client.Update(customer);
                return RedirectToAction(nameof(Index));

                /* var client = new CustomerService.CustomerServiceClient(channel);
                 Customer response = client.Update(customer);
                 return RedirectToAction(nameof(Index));*/
            }
            return View(customer);
        }

    }
}