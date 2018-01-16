using System;

namespace KuroGUI.osuAPI
{
    public class osuPlayerRecent
    {
        public string beatmap_id { get; set; }
        public string score { get; set; }
        public string maxcombo { get; set; }
        public string count50 { get; set; }
        public string count100 { get; set; }
        public string count300 { get; set; }
        public string countmiss { get; set; }
        public string countkatu { get; set; }
        public string countgeki { get; set; }
        public string perfect { get; set; }
        public string enabled_mods { get; set; }
        public string user_id { get; set; }
        public string date { get; set; }
        public string rank { get; set; }
        public double GetAccuracy()
        {
            int count300 = int.Parse(this.count300);
            int count100 = int.Parse(this.count100);
            int count50 = int.Parse(this.count50);
            int countmiss = int.Parse(this.countmiss);

            int score3 = count300 * 300;
            int score1 = count100 * 100;
            int score5 = count50 * 50;
            int divider = (count300 + count100 + count50 + countmiss) * 300;
            return (((score3 + score1 + score5) * 1.0 / divider) * 100);
        }
        public string GetModNames()
        {
            int ModValue = int.Parse(this.enabled_mods);
            if (ModValue == 0) return "NM";
            int[] ModsValues = (int[])Enum.GetValues(typeof(Mods));
            string ModsName = string.Empty;
            for (int i = 30; i > 0; i--)
            {
                if(ModValue - ModsValues[i] > 0)
                {
                    ModsName += Enum.GetName(typeof(Mods), ModsValues[i]);
                    ModValue -= ModsValues[i];
                }
                else if(ModValue - ModsValues[i] == 0)
                {
                    ModsName += Enum.GetName(typeof(Mods), ModsValues[i]);
                    ModValue -= ModsValues[i];
                }
            }
            if (ModsName.IndexOf("NC") > -1)
            {
                ModsName = ModsName.Replace("DT", string.Empty);
            }
            return ModsName;
        }
    }
}
