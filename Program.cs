using System;
using tpmodul8_103022300066;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();
        config.LoadConfig();

        config.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuNormal = false;
        if (config.satuan_suhu == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        if (suhuNormal && hari < config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}
