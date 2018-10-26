using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace osu_indirect.Main.OsuApi
{
    public static class OsuApi
    {
        public static string ApiKey { get; set; }

        public static BeatmapInfo GetBeatmapInfo(int beatmapId)
        {

            WebClient infoClient = new WebClient();

            using (Stream s = infoClient.OpenRead(new Uri("https://osu.ppy.sh/api/get_beatmaps?k=" + ApiKey + "&b=" + beatmapId)))
            {
                var serializer = new JsonSerializer();

                JArray list = (JArray)serializer.Deserialize(new JsonTextReader(new StreamReader(s)));
                foreach (JObject obj in list)
                {
                    return new BeatmapInfo()
                    {
                        Id = beatmapId,
                        SetId = obj["beatmapset_id"].Value<int>(),

                        Name = obj["title"].Value<string>(),

                        Rank = (BeatmapRank) obj["approved"].Value<int>()
                    };
                }
            }

            return null;
        }

        public static Task<BeatmapInfo> GetBeatmapInfoAsync(int beatmapId)
        {
            return new Task<BeatmapInfo>(() => GetBeatmapInfo(beatmapId));
        }

        public static bool IsKeyValid(string apiKey)
        {
            WebClient client = new WebClient();

            try
            {
                client.OpenRead(new Uri("https://osu.ppy.sh/api/get_beatmaps?k=" + apiKey + "&limit=0"));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static Task<bool> IsKeyValidAsync(string apiKey)
        {
            return new Task<bool>(() => IsKeyValid(apiKey));
        }
    }
}
