namespace AudiobookBG.Web.ViewModels.Administration.AudioFiles
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class AudioFileInBookViewModel : IMapFrom<AudioFile>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Views { get; set; }

        public string Url => $"audioFiles/{this.Id}";
    }
}
