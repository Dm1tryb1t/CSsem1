﻿using Books.Models;

namespace BooksAPI.Services
{
    public class SampleChapters
    {
        private readonly IBookChapterService _bookChapterService;
        public SampleChapters(IBookChapterService bookChapterService) => _bookChapterService = bookChapterService;

        private string[] _sampleTitles = new[]
        {
            ".NET Application Architectures",
            "Core C#",
            "Classes, Structs, Tuples, and Records",
            "Object-Oriented Programming with C#",
            "Operators and Casts",
            "Arrays",
            "Delegates, Lambdas, and Events",
            "Collections",
            "ADO.NET and Transactions"
        };

        private int[] _chapterNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 25 };

        private int[] _pageCounts = { 35, 42, 33, 20, 24, 38, 20, 32, 44 };

        public void CreateSampleChapters()
        {
            List<BookChapter> chapters= new();
            for (int i = 0; i < 9; i++)
            {
                chapters.Add(new BookChapter(Guid.NewGuid(), _chapterNumbers[i], _sampleTitles[i], _pageCounts[i]));
            }
            if(!_bookChapterService.GetAllAsync().Result.Any())
            {
                _bookChapterService.AddRangeAsync(chapters);

            }
        } 

    }
}
