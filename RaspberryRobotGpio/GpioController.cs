using System.IO;

namespace RaspberryRobotGpio
{
    public class GpioController
    {
        private readonly string gpioPath = "/sys/class/gpio/";
        private int pinNumber = 18;

        public GpioController()
        {
            this.Init();
        }

        public void Init()
        {
            //Check if port is already open
            if (Directory.Exists($"{gpioPath}gpio{pinNumber.ToString()}"))
            {
                return;
            }

            File.WriteAllText($"{gpioPath}export", pinNumber.ToString());
            File.WriteAllText($"{gpioPath}gpio{pinNumber.ToString()}/direction", "out");
        }

        public void WritePin(PinValue value)
        {
            var valueStr = ((byte)value).ToString();
            File.WriteAllText($"{gpioPath}gpio{pinNumber.ToString()}/value", valueStr);
        }

        public void Dispose()
        {
            File.WriteAllText($"{gpioPath}unexport", pinNumber.ToString());
        }
    }
}
