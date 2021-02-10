using System;

namespace TheAddon
{
    public class AddonMain : TheCore.IAddon
    {
        public object Action()
        {
            System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort();
            port.BaudRate = 115200;
            return null;
        }
    }
}
