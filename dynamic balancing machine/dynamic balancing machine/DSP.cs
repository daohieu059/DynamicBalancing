using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_balancing_machine

{
    public class DSP
    {
        public static complex[] fft(double[] a)
        {
            complex[] dem;
            dem = new complex[a.Length];
            for (int k = 0; k < a.Length; k++)
            {
                complex tam, ll, tong1, tong2;
                tam = new complex(0, 0);
                for (int r = 0; r < a.Length / 2; r++)
                {
                    ll = new complex((float)Math.Cos(-Math.PI * 2 * k / a.Length), (float)Math.Sin(-Math.PI * 2 * k / a.Length));
                    tong1 = new complex((float)(Math.Cos(-Math.PI * 2 * k * r / (a.Length / 2)) * a[2 * r]), (float)(Math.Sin(-Math.PI * 2 * k * r / (a.Length / 2)) * a[2 * r]));
                    tong2 = new complex((float)(Math.Cos(-Math.PI * 2 * k * r / (a.Length / 2)) * a[2 * r + 1]), (float)(Math.Sin(-Math.PI * 2 * k * r / (a.Length / 2)) * a[2 * r + 1]));
                    tam = tam + tong1 + ll * tong2;

                }
                dem[k] = tam;
            };
            return dem;
        }

        public static complex[] ifft(complex[] a)
        {
            complex[] dem;
            dem = new complex[a.Length];
            for (int k = 0; k < a.Length; k++)
            {
                complex tam, ll, tong1, tong2, cc, cc1;
                tam = new complex(0, 0);

                for (int r = 0; r < a.Length / 2; r++)
                {
                    cc = new complex((float)(Math.Cos(Math.PI * 2 * k * r / (a.Length / 2))), (float)(Math.Sin(Math.PI * 2 * k * r / (a.Length / 2))));
                    cc1 = new complex((float)(1.0 / (a.Length)), 0);
                    ll = new complex((float)Math.Cos(Math.PI * 2 * k / (a.Length)), (float)Math.Sin(Math.PI * 2 * k / (a.Length)));
                    tong1 = cc * a[2 * r];
                    tong2 = cc * a[2 * r + 1];
                    tam = tam + cc1 * (tong1 + ll * tong2);

                }
                dem[k] = tam;
            }
            return dem;
        }

        public static double[] deal_lp(double wc, double M)
        {
            double alpha = (M - 1) / 2.0;
            double[] hd;
            hd = new double[(int)M];
            for (int i = 0; i < M; i++)
            {

                double m = i - alpha;
                double fc = wc / Math.PI;
                if (m != 0) hd[i] = fc * Math.Sin(Math.PI * fc * m) / (Math.PI * fc * m);
                else hd[i] = fc;
            }
            return hd;
        }
        public static double[] gausswin(int n)
        {
            double[] a;
            a = new double[n];
            for (int i = -n / 2; i < n / 2; i++) a[i + n / 2] = Math.Pow(Math.E, -0.5 * Math.Pow((2.5 * i / (n / 2)), 2));
            return a;
        }
    }
}
