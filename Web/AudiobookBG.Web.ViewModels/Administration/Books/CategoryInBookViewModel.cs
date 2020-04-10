﻿namespace AudiobookBG.Web.ViewModels.Administration.Books
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class CategoryInBookViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Url => $"/{this.Name}";
    }
}
