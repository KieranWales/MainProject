using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// source: https://twiki.cern.ch/twiki/pub/Sandbox/DaqSchoolExercise14/Picoboard_protocol.pdf

namespace PBC
{
    class PicoBoard
    {
        public enum Sensor
        {
            RESISTANCE_D = 0,
            RESISTANCE_C = 1,
            RESISTANCE_B = 2,
            BUTTON = 3,
            RESISTANCE_A = 4,
            LIGHT = 5,
            SOUND = 6,
            SLIDER = 7
        }

        private int[] sensorValues = new int[8] { 1023, 1023, 1023, 1023, 1023, 1023, 1023, 511 };
        public bool connected = false;
        SerialPort p = new SerialPort();

        public void Connect(string PortName)
        {
            if (!(connected))
            {
                /*foreach (string portName in SerialPort.GetPortNames())
                {
                    Console.WriteLine(portName);
                }*/

                p.PortName = PortName;
                p.BaudRate = 38400;
                p.ReadTimeout = 20;
                p.Open();
                
                
                connected = true;
            }
        }

        public void Disconnect()
        {
            if (connected)
            {
                p.Close();
            }
        }

        public int ReadSensor(Sensor SensorNumber)
        {
            if (connected)
            {
                byte[] b = new byte[18];
                b[0] = 1;
                p.Write(b, 0, b.Length);
                int returned = 0;
                try
                {
                    returned = p.Read(b, 0, 18);
                }
                catch{}
                

                if (returned == 18)
                {
                    for (int i = 0; i < 18; i += 2)
                    {
                        byte high = b[i];
                        byte low = b[i + 1];

                        if ((((high >> 7) & 1) == 1) && ((low >> 7) & 1) == 0)
                        {
                            int channel = ((high >> 3) & 0xf);
                            int firstValues = (high & 0x7);
                            int secondValues = (low & 0xff);
                            int finalValue = (firstValues * (int)Math.Pow(2, 7)) + secondValues;

                            if (channel < 8)
                            {
                                sensorValues[channel] = finalValue;
                                Console.WriteLine($"Setting channel {channel} to {finalValue}");
                            }
                        }
                    }
                }
                // Console.WriteLine(returned);
            }
            return sensorValues[(int)SensorNumber];
        }
    }
}
