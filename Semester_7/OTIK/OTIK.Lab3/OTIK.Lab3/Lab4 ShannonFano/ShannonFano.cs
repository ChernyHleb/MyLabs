using System;
using System.Collections.Generic;

namespace OTIK.Lab3.Lab4_ShannonFano
{
    class ShannonFano
    {
        public List<double> P = new List<double>(); 
        public List<byte> Alpha = new List<byte>();
        
        public List<string> Res = new List<string>();
        
        public ShannonFano(List<byte> data)
        {
            foreach(byte b in data)
            {
                if (Alpha.Contains(b))
                {
                    P[Alpha.IndexOf(b)]++;
                }
                else
                {
                    Alpha.Add(b);
                    Res.Add("");
                    P.Add(1);
                }
                    
            }
            double final = 0;
            for(int i = 0; i < P.Count; i++)
            {
                P[i] /= data.Count;
                final += P[i];
            }
        }

        public Dictionary<byte, string> GetTable()
        {
            Dictionary<byte, string> symCode = new Dictionary<byte, string>();

            Sort();
            Fano(0, Alpha.Count - 1);
            for (int i = 0; i < Alpha.Count; i++)
            {
                symCode.Add(Alpha[i], Res[i]);
                //Console.WriteLine(Alpha[i] + " " + Res[i]);
            }

            return symCode;
        }

        public void Sort()
        {
            for (int i = 0; i < P.Count; i++)
            {
                for (int j = 0; j < P.Count - i - 1; j++)
                {
                    if (P[j] < P[j + 1])
                    {
                        byte temp2;
                        double temp1 = 0;

                        temp1 = P[j];
                        temp2 = Alpha[j];
                        P[j] = P[j + 1];
                        Alpha[j] = Alpha[j + 1];
                        P[j + 1] = temp1;
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
                a += P[i];
            }

            b = P[R];
            m = R;
            while (a >= b)
            {
                m --;
                a -= P[m];
                b += P[m];
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
                        Res[i] += '0';
                    }
                    else
                    {
                        Res[i] += '1';
                    }
                }

                Fano(L, n);

                Fano(n + 1, R);

            }

        }

    }
}
