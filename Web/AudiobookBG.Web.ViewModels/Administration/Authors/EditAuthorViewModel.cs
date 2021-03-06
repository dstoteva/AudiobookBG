﻿namespace AudiobookBG.Web.ViewModels.Administration.Authors
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class EditAuthorViewModel : IMapFrom<Author>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
