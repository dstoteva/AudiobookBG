namespace AudiobookBG.Web.ViewModels.Administration.AudioFiles
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class EditAudioFileViewModel : IMapFrom<AudioFile>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int BookId { get; set; }
    }
}
