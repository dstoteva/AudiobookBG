namespace AudiobookBG.Web.ViewModels.Administration.AudioFiles
{
    using System.Collections.Generic;

    public class AllViewModel
    {
        public IEnumerable<AudioFileInBookViewModel> AudioFiles { get; set; }
    }
}
