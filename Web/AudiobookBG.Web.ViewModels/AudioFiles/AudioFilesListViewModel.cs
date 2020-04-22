namespace AudiobookBG.Web.ViewModels.AudioFiles
{
    using System.Collections.Generic;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class AudioFilesListViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<AudioFileViewModel> AudioFiles { get; set; }
    }
}
