using System;

namespace Ucu.Poo.Library
{
    public class IsLoanedRule : ILoanRule
    {
        public IsLoanedRule(MediaLibrary mediaLibrary, IMedia media)
        {
            this.MediaLibrary = mediaLibrary;
            this.Media = media;
        }
        
        public MediaLibrary MediaLibrary { get; private set; }
        public IMedia Media { get; private set; }
        
        public void ApplyRule()
        {
            if (this.MediaLibrary.IsLoaned(this.Media))
            {
                throw new InvalidOperationException(
                    $"El libro {this.Media.Title} ya está prestado a otro usuario.");
            }
        }
    }
}