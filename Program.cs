using System;
using System.Collections.Generic;

namespace Tebak_Huruf
{
    class Program
    {
        static void Main(string[] args)
        {
            string kata = "PEMROGRAMAN";
            int kesempatan = 5;
            List<string> hurufTebakan = new List<string>{};

            Console.WriteLine("Selamat bermain Tebak Kata");
            Console.WriteLine($"Kata ini terdiri dari {kata.Length} huruf");
            Console.WriteLine($"Kamu punya {kesempatan} kali kesempatan");
            Console.WriteLine("");
            Console.WriteLine(cekHuruf(kata, hurufTebakan));

            while (kesempatan > 0) {
                Console.Write("Input huruf tebakanmu: ");
                string input = Console.ReadLine();
                input = input.ToUpper();
                hurufTebakan.Add(input);
                Console.WriteLine("");

                if (cekKata(kata, hurufTebakan)) {
                    Console.WriteLine(cekHuruf(kata, hurufTebakan));
                    Console.WriteLine($"Selamat anda berhasil menebak kata \"{kata}\"");
                    break;
                } else if (kata.Contains(input)) {
                    Console.WriteLine("Tebakan anda benar...");
                    Console.WriteLine(cekHuruf(kata, hurufTebakan));
                } else {
                    kesempatan--;
                    Console.WriteLine("Sayang sekali tebakan anda tidak tepat...");
                    Console.WriteLine($"Kesempatan anda tinggal {kesempatan} kali lagi");
                    Console.WriteLine(cekHuruf(kata, hurufTebakan));
                }

                if (kesempatan == 0) {
                    Console.WriteLine($"Game Over, kata yang benar adalah \"{kata}\"");
                    Console.WriteLine("bye, bye,...");
                    break;
                }
            }
        }

        static bool cekKata(string kata, List<string> hurufTebakan)
        {
            bool status = false;

            for (int i = 0; i < kata.Length; i++) {
                string c = Convert.ToString(kata[i]);

                if (hurufTebakan.Contains(c)) {
                    status = true;
                } else {
                    return status = false;
                }
            }
            return status;
        }

        static string cekHuruf(string kata, List<string> hurufTebakan)
        {
            string hurufBenar = "";
            for (int i = 0; i < kata.Length; i++) {
                string c = Convert.ToString(kata[i]);

                if (hurufTebakan.Contains(c)) {
                    hurufBenar += " " + c;
                } else {
                    hurufBenar += " _ ";
                }
            }
            return hurufBenar;
        }
    }
}
