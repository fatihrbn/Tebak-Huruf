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
            List<string> hurufTebakan = new List<string> {};

            Console.WriteLine("Selamat datang di game tebak kata");
            Console.WriteLine($"kata ini terdiri dari {kata.Length} huruf");
            Console.WriteLine($"Anda punya {kesempatan} kesempatan");
            Console.WriteLine(cekHuruf(kata, hurufTebakan));

            while (kesempatan > 0) {
                Console.Write("Masukan huruf tebakan anda: ");
                string input = Console.ReadLine();
                input = input.ToUpper();
                hurufTebakan.Add(input);
                Console.WriteLine("=============================");

                if (cekKata(kata, hurufTebakan)) {
                    Console.WriteLine(cekHuruf(kata, hurufTebakan));
                    Console.WriteLine("Selamat anda telah menamatkan game ini");
                    Console.WriteLine($"Kata yang berhasil anda tebak adalah \"{kata}\"");
                    break;
                } else if (kata.Contains(input)) {
                    Console.WriteLine("Selamat tebakan anda benar");
                    Console.WriteLine(cekHuruf(kata, hurufTebakan));
                } else {
                    kesempatan--;
                    Console.WriteLine("Sayang sekali tebakan anda salah");
                    Console.WriteLine($"Kesempatan anda tinggal {kesempatan} kali lagi");
                    Console.WriteLine(cekHuruf(kata, hurufTebakan));
                }

                if (kesempatan == 0) {
                    Console.WriteLine("Kesempatan anda sudah habis");
                    Console.WriteLine($"Kata yang benar adalah \"{kata}\"");
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
                    hurufBenar += " _";
                }
            }
            return hurufBenar;
        }
    }
}
