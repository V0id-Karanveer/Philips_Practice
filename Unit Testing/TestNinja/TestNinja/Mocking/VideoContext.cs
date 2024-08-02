using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoContext
    {
        DbSet<Video> Videos { get; set; }
        List<Video> GetUnprocessed();
    }

    public class VideoContext : DbContext, IVideoContext
    {
        public DbSet<Video> Videos { get; set; }

        public List<Video> GetUnprocessed()
        {
            var vids = (from video in Videos
                where !video.IsProcessed
                select video).ToList();

            return vids;
        }
    }
}
