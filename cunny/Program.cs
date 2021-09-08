using System;
using System.Net;
using System.Text.RegularExpressions;
namespace cunny
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ENter gogo anime id so c#unny can download it: ");
            string animeid = Console.ReadLine();
            Cunny cunny = new Cunny(animeid);
            cunny.download_all();

        }
    }

    class Cunny
    {
        string based_url { get; set; }
        string anime_id { get; set; }

        public Cunny(string animeid)
        {
            this.anime_id = animeid;
            this.based_url = "https://gogoanime.pe/" + animeid;
        }

        public void download_all()
        {
            WebClient client = new WebClient();
            int your_mom = 99999999; // really big number (just like your mom)

            System.IO.Directory.CreateDirectory(this.anime_id);
            for (int i = 1; i < your_mom; i++)
            {
                string url = this.based_url + "-episode-" + i;
                string response = client.DownloadString(url);
                if (response.Contains(">404</h1>"))
                {
                    Console.WriteLine("Donwload done reatrd.");
                    break;
                }
                do_the_doo(this.anime_id, remove_random_shit(response), client, i);

            }
        }

        private string find_the_dl(string bs)
        {
            Regex re = new Regex("dowloads\"><ahref=\"(.*?)\"target");
            return re.Match(bs).Groups[1].Value;
        }

        private string find_the_oither_dl(string bs)
        {
            Regex re = new Regex("\"dowload\"><ahref=\"(.*?)\"download");
            return re.Match(bs).Groups[1].Value;
        }
        private void do_the_doo(string folder, string s, WebClient cleitn, int ep)
        {
            string dl = find_the_dl(s);
            string new_shjit = this.remove_random_shit(cleitn.DownloadString(dl));
            string new_dl = find_the_oither_dl(new_shjit);
            Console.WriteLine("Downloading: " + folder + "/" + "Episode " + ep + ".mp4");

            cleitn.DownloadFile(new_dl, folder + "/" + "Episode " + ep + ".mp4");
            Console.WriteLine("Downlaoded: " + folder + "/" + "Episode " + ep + ".mp4");
        }

        private string remove_random_shit(string shitted_string)
        {
            return shitted_string.Replace(" ", "").Replace("\n", "").Replace("\t", "");
        }
    }
}
