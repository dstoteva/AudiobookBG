namespace AudiobookBG.Web.ViewModels.AudioFiles
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class AudioFileViewModel : IMapFrom<AudioFile>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Views { get; set; }

        public string Url { get; set; }
    }
}
