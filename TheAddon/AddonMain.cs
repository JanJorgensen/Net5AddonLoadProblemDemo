using System;

namespace TheAddon
{
    public class AddonMain : TheCore.IAddon
    {
        int BaudRate { get; set; } = 115200;
        public object Action()
        {
            System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort();
            port.BaudRate = this.BaudRate;
            return null;
        }
        public System.Type GetSomeType()
        {
            return null;
        }
    }

    public class SomeClass
    {
        int Prop { get; set; } = 0;
    }
}
