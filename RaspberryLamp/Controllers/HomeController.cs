using Microsoft.AspNetCore.Mvc;
using RaspberryRobotGpio;

namespace RaspberryLamp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GpioController gpioController;

        public HomeController(GpioController gpioController)
        {
            this.gpioController = gpioController;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult TurnLampOn()
        {
            this.gpioController.WritePin(PinValue.High);
            return View("Index");
        }

        public IActionResult TurnLampOff()
        {
            this.gpioController.WritePin(PinValue.Low);
            return View("Index");
            
        }
    }
}
