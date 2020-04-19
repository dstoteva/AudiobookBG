namespace AudiobookBG.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<HomeBookViewModel> Books { get; set; }
    }
}
