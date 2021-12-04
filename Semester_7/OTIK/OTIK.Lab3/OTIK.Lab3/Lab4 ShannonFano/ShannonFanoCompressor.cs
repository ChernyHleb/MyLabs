using System;

namespace OTIK.Lab3.Lab4_ShannonFano
{
    class ShannonFanoCompressor
    {
        public double[] P1 = { 0.062, 0.014, 0.038, 0.013, 0.025, 0.072, 0.072, 0.007, 0.016, 0.062, 0.010, 0.028, 0.035, 0.026, 0.053, 0.090, 0.023, 0.040, 0.045, 0.053, 0.021, 0.002, 0.009, 0.004, 0.012, 0.006, 0.003, 0.014, 0.003, 0.014, 0.003, 0.006, 0.018 };
        public char[] Alpha = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        
        public string[] Res = new string[33];
        
        public ShannonFanoCompressor(InnerFile file)
        {

        }

        public void Sort()
        {
            for (int i = 0; i < P1.Length; i++)
            {
                for (int j = 0; j < P1.Length - i - 1; j++)
                {
                    if (P1[j] < P1[j + 1])
                    {
                        char temp2;
                        double temp1 = 0;

                        temp1 = P1[j];
                        temp2 = Alpha[j];
                        P1[j] = P1[j + 1];
                        Alpha[j] = Alpha[j + 1];
                        P1[j + 1] = temp1;
                        Alpha[j + 1] = temp2;
                    }
                }
            }

        }
        
        public int Split(int L, int R)
        {
            int m;
            double a = 0;
            double b = 0;

            for (int i = L; i <= R - 1; i++)
            {
                a += P1[i];
            }

            b = P1[R];
            m = R;
            while (a >= b)
            {
                m --;
                a -= P1[m];
                b += P1[m];
            }
            return m;

        }

        public void Fano(int L, int R)
        {
            int n;

            if (L < R)
            {

                n = Split(L, R);
                //Console.WriteLine(n);
                for (int i = L; i <= R; i++)
                {
                    if (i <= n)
                    {
                        Res[i] += Convert.ToByte(0);
                    }
                    else
                    {
                        Res[i] += Convert.ToByte(1);
                    }
                }

                Fano(L, n);

                Fano(n + 1, R);

            }

        }

    }
}
