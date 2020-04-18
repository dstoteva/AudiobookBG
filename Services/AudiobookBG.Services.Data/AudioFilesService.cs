namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AudiobookBG.Data.Common.Repositories;
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class AudioFilesService : IAudioFilesService
    {
        private readonly IDeletableEntityRepository<AudioFile> audioFilesRepository;

        public AudioFilesService(IDeletableEntityRepository<AudioFile> audioFilesRepository)
        {
            this.audioFilesRepository = audioFilesRepository;
        }

        public async Task<int> CreateAsync(string title, string audioUrl, int bookId)
        {
            var audioFile = new AudioFile
            {
                Title = title,
                Views = 0,
                Url = audioUrl,
            };

            audioFile.BookId = bookId;

            await this.audioFilesRepository.AddAsync(audioFile);
            await this.audioFilesRepository.SaveChangesAsync();

            return audioFile.Id;
        }

        public IEnumerable<T> GetByBookId<T>(int bookId)
        {
            var audioFiles = this.audioFilesRepository.All().Where(af => af.BookId == bookId)
                .OrderBy(af => af.Title)
                .To<T>()
                .ToList();

            return audioFiles;
        }

        public T GetById<T>(int id)
        {
            var audioFile = this.audioFilesRepository.All().Where(af => af.Id == id)
                .To<T>()
                .FirstOrDefault();

            return audioFile;
        }
    }
}
