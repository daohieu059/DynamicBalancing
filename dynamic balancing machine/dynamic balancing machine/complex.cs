using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_balancing_machine
{
    public class complex
    {
        public float real = (float)0.0;
        public float imag = (float)0.0;


        public complex(float real, float imag)
        {
            this.real = real;
            this.imag = imag;
        }
        public complex()
        {
        }

        public string ToString()
        {
            string data = real.ToString() + " " + imag.ToString() + "i";
            return data;
        }
        //Convert from polar to rectangular
        public static complex from_polar(float r, float radians)
        {
            complex data = new complex((float)(r * Math.Cos(radians)), (float)(r * Math.Sin(radians)));
            return data;
        }
        //Override addition operator
        public static complex operator +(complex a, complex b)
        {

            complex data = new complex(a.real + b.real, a.imag + b.imag);
            return data;
        }
        //Override subtraction operator
        public static complex operator -(complex a, complex b)
        {

            complex data = new complex(a.real - b.real, a.imag - b.imag);
            return data;
        }
        //Override multiplication operator
        public static complex operator *(complex a, complex b)
        {

            float real = a.real * b.real - a.imag * b.imag, imag = a.real * b.imag + a.imag * b.real;
            complex data = new complex(real, imag);
            return data;
        }
        public static complex operator /(complex a, complex b)
        {

            float real = (b.real * a.real + a.imag * b.imag) / (a.real * a.real + a.imag * a.imag), imag = (b.real * a.imag - b.imag * a.real) / (a.real * a.real + a.imag * a.imag);
            complex data = new complex(real, imag);
            return data;
        }
        //Return magnitude of complex number
        public double magnitude
        {
            get
            {
                return Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2));
            }
        }
        public double phase
        {
            get
            {
                return Math.Atan(imag / real);
            }
        }
    }

}
