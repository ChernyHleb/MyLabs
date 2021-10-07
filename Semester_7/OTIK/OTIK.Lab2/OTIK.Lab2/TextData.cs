using System;
using System.Collections.Generic;

namespace OTIK.Lab2
{
    class TextData
    {
        List<char> sym = new List<char>();
        List<int> symCount = new List<int>();
        List<double> symCountFreq = new List<double>();
        int symCountTotal = 0;

        List<byte> bytes = new List<byte>();
        List<int> byteCount = new List<int>();
        List<double> byteCountFreq = new List<double>();
        int byteCountTotal = 0;

        public TextData(string inputText, byte[] inputBytes)
        {
            foreach (char c in inputText.ToCharArray())
            {
                if (sym.Contains(c))
                {
                    for (int i = 0; i < sym.Count; i++)
                    {
                        if (sym[i] == c)
                        {
                            symCount[i]++;
                            symCountTotal++;
                            break;
                        }
                    }
                }
                else
                {
                    sym.Add(c);
                    symCount.Add(1);
                    symCountTotal++;
                }
            }

            foreach (byte b in inputBytes)
            {
                if (bytes.Contains(b))
                {
                    for (int i = 0; i < bytes.Count; i++)
                    {
                        if (bytes[i] == b)
                        {
                            byteCount[i]++;
                            byteCountTotal++;
                            break;
                        }
                    }
                }
                else
                {
                    bytes.Add(b);
                    byteCount.Add(1);
                    byteCountTotal++;
                }
            }

        }
        public TextData() { }
        public string GetPiecesResult(string inputText)
        {
            List<char> rusSym = new List<char>();
            List<int> rusSymCount = new List<int>();
            List<double> rusSymCountFreq = new List<double>();
            int rusSymCountTotal = 0;

            foreach (char c in inputText.ToCharArray())
            {
                char lc = Char.ToLower(c);
                if (!(lc >= 'а' && lc <= 'я'))
                    continue;
                if (rusSym.Contains(lc))
                {
                    for (int i = 0; i < rusSym.Count; i++)
                    {
                        if (rusSym[i] == lc)
                        {
                            rusSymCount[i]++;
                            rusSymCountTotal++;
                            break;
                        }
                    }
                }
                else
                {
                    rusSym.Add(lc);
                    rusSymCount.Add(1);
                    rusSymCountTotal++;
                }
            }


            string result = "СИМВОЛ\tЧАСТОТА\n";
            foreach (int i in rusSymCount)
                rusSymCountFreq.Add((double)i / (double)rusSymCountTotal);

            for (int i = 0; i < rusSymCountFreq.Count; i++)
            {
                for (int j = i; j < rusSymCountFreq.Count; j++)
                {
                    if (rusSymCountFreq[i] < rusSymCountFreq[j])
                    {
                        var a = rusSymCountFreq[i];
                        rusSymCountFreq[i] = rusSymCountFreq[j];
                        rusSymCountFreq[j] = a;

                        var b = rusSymCount[i];
                        rusSymCount[i] = rusSymCount[j];
                        rusSymCount[j] = b;
                        var c = rusSym[i];
                        rusSym[i] = rusSym[j];
                        rusSym[j] = c;
                    }
                }
            }

            for (int i = 0; i < rusSym.Count; i++)
            {
                result += rusSym[i] + "\t" 
                   + rusSymCountFreq[i] + "\t" 
                   + Environment.NewLine;
            }
            
            return result;
        }

        public string GetTextResult()
        {
            string result = "СИМВОЛ\tКОЛ-ВО\tЧАСТОТА\t\t\tКОЛ-ВО ИНФ\t\tСРЕДНЕЕ КОЛ-ВО ИНФ\n";
            foreach (int i in symCount)
                symCountFreq.Add((double)i / (double)symCountTotal);

            for (int i = 0; i < symCountFreq.Count; i++)
            {
                for (int j = i; j < symCountFreq.Count; j++)
                {
                    if (symCountFreq[i] < symCountFreq[j])
                    {
                        var a = symCountFreq[i];
                        symCountFreq[i] = symCountFreq[j];
                        symCountFreq[j] = a;

                        var b = symCount[i];
                        symCount[i] = symCount[j];
                        symCount[j] = b;
                        var c = sym[i];
                        sym[i] = sym[j];
                        sym[j] = c;
                    }
                }
            }
            double InfoSum = 0;

            for (int i = 0; i < sym.Count; i++)
            {
                // количество информации
                double symInfoAmount = -1 * Math.Log(symCountFreq[i], 2);
                // суммарное кол-во инф
                InfoSum += symInfoAmount;
                // среднее количество инф
                double avgInfoAmount = symInfoAmount * symCountFreq[i];
                result += sym[i] + "\t" + symCount[i] + "\t" + symCountFreq[i] + "\t" + symInfoAmount + "\t" + avgInfoAmount + Environment.NewLine;
            }
            result += string.Format("Info sum:{0}", InfoSum);
            return result;
        }

        public string GetBytesResult()
        {
            string result = "ОКТЕТ\tКОЛ-ВО\tЧАСТОТА\t\t\tКОЛ-ВО ИНФ\t\tСРЕДНЕЕ КОЛ-ВО ИНФ\n";
            foreach (int i in byteCount)
                byteCountFreq.Add((double)i / (double)byteCountTotal);

            for (int i = 0; i < byteCountFreq.Count; i++)
            {
                for (int j = i; j < byteCountFreq.Count; j++)
                {
                    if (byteCountFreq[i] < byteCountFreq[j])
                    {
                        var a = byteCountFreq[i];
                        byteCountFreq[i] = byteCountFreq[j];
                        byteCountFreq[j] = a;

                        var b = byteCount[i];
                        byteCount[i] = byteCount[j];
                        byteCount[j] = b;
                        var c = bytes[i];
                        bytes[i] = bytes[j];
                        bytes[j] = c;
                    }
                }
            }
            double InfoSum = 0;
            string[] hexBytes = BitConverter.ToString(bytes.ToArray()).Split('-');

            for (int i = 0; i < bytes.Count; i++)
            {
                // количество информации
                double byteInfoAmount = -1 * Math.Log(byteCountFreq[i], 2);
                // суммарное кол-во инф
                InfoSum += byteInfoAmount;
                // среднее количество инф
                double avgInfoAmount = byteInfoAmount * byteCountFreq[i];
                result += hexBytes[i] + "\t" + byteCount[i] + "\t" + byteCountFreq[i] + "\t" + byteInfoAmount + "\t" + avgInfoAmount + Environment.NewLine;
            }
            result += string.Format("Info sum:{0}", InfoSum);
            return result;
        }
    }
}
