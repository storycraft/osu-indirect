using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_indirect.Main.OsuApi
{
    public class BeatmapInfo
    {
        public string Name { get; set; }

        public int Id { get; set; }
        public int SetId { get; set; }

        public BeatmapRank Rank { get; set; }
    }

    public enum BeatmapRank : int
    {
        LOVED = 4,
        QUALIFIED = 3,
        APPROVED = 2,
        RANKED = 1,
        PENDING = 0,
        WIP = -1,
        GRAVEYARD = -2
    }
}