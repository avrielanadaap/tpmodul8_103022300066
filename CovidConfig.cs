using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300066
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private static string configPath = "covid_config.json";

        public void LoadConfig()
        {
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                var config = JsonSerializer.Deserialize<CovidConfig>(json);
                this.satuan_suhu = config.satuan_suhu;
                this.batas_hari_deman = config.batas_hari_deman;
                this.pesan_ditolak = config.pesan_ditolak;
                this.pesan_diterima = config.pesan_diterima;
            }
            else
            {
                SaveConfig();
            }
        }

        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configPath, json);
        }

        public void UbahSatuan()
        {
            this.satuan_suhu = this.satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
            SaveConfig();
        }
    }

}