using System;
using System.Collections.Generic;

namespace Tebak_Huruf
{
    class Program
    {
        static void Main(string[] args)
        {
            string kata = "pemrograman";
            int kesempatan = 5;
            List<string> hurufTebakan = new List<string>{};

            Console.WriteLine("Selamat bermain Tebak Kata");
            Console.WriteLine($"Kata ini terdiri dari {kata.Length} huruf");
            Console.WriteLine($"Kamu punya {kesempatan} kali kesempatan");

            while (kesempatan > 0) {
                Console.Write("Input huruf tebakanmu: ");
                string input = Console.ReadLine();
                hurufTebakan.Add(input);

                if (cekKata(kata, hurufTebakan)) {
                    Console.WriteLine($"Selamat anda berhasil menebak kata \"{kata}\"");
                    break;
                } else if (kata.Contains(input)) {
                    Console.WriteLine("Tebakan anda benar...");
                    Console.WriteLine(cekHuruf(kata, hurufTebakan));
                } else {
                    Console.WriteLine("Tebakan anda salah...");
                    kesempatan -= 1;
                    Console.WriteLine($"Kesempatan anda tinggal {kesempatan} kali lagi");
                }

                if (kesempatan == 0) {
                    Console.WriteLine($"Game Over, kata yang benar adalah {kata}");
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
                    status = false;
                }
            }
            return status;
        }

        static string cekHuruf(string kata, List<string> hurufTebakan)
        {
            string hurufBenar ="";
            for (int i = 0; i < kata.Length; i++) {
                string c = Convert.ToString(kata[i]);

                if (hurufTebakan.Contains(c)) {
                    hurufBenar += c;
                } else {
                    hurufBenar += " _ ";
                }
            }
            return hurufBenar;
        }
    }
}
