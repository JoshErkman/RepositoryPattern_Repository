using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Repository
{
    public class StreamingContentRepository
    {
        private List<StreamingContent> _ListOfContent = new List<StreamingContent>();

        //Create
        public void AddContentToList(StreamingContent content)
        {
            _ListOfContent.Add(content); 
        }

        //Read
        public List<StreamingContent> GetContentList()
        {
            return _ListOfContent;
        }

        //Update
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            //Find the content
            StreamingContent oldContent = GetContentByTitle(originalTitle);


            //Update the content
            if(oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.IsFamilyFriendly = newContent.IsFamilyFriendly;
                oldContent.StarRating = newContent.StarRating;
                oldContent.TypeOfGenre = newContent.TypeOfGenre;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveContentFromList(string title)
        {
            StreamingContent content = GetContentByTitle(title);
            if( content == null)
            {
                return false;
            }

            int initialCount = _ListOfContent.Count;
            _ListOfContent.Remove(content);

            if(initialCount > _ListOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper method
        private StreamingContent GetContentByTitle(string title)
        {
            foreach(StreamingContent content in -_ListOfContent)
            {
                if(content.Title == title)
                {
                    return content;
                }
            }

            return null;
        }

    }
}
