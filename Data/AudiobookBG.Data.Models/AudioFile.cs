namespace AudiobookBG.Data.Models
{
    using AudiobookBG.Data.Common.Models;

    public class AudioFile : BaseDeletableModel<int>
    {
        public AudioFile()
        {
        }

        public string Title { get; set; }

        public int Views { get; set; }

        public byte[] Data { get; set; }

        public string Url { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
