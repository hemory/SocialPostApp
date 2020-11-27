using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Post
{
    class PostActions
    {
        public static Post UpdateEntirePost(string propertyToUpdate, Post postToUpdate, string updatedValue)
        {
            switch (propertyToUpdate)
            {
                case "1":
                    postToUpdate.UpdateTitle(updatedValue);
                    break;
                case "2":
                    postToUpdate.UpdateMessage(updatedValue);
                    break;
                case "3":
                    postToUpdate.UpdateAuthor(updatedValue);
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }


            postToUpdate.Date = DateTime.Now;

            return postToUpdate;
        }

        public static Post GetSpecificPostToUpdate(List<Post> collectionOfPosts, string titleOfPostToUpdate)
        {
            Post postToUpdate = null;

            foreach (var userPosts in collectionOfPosts)
            {
                if (String.Equals(titleOfPostToUpdate, userPosts.Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    postToUpdate = userPosts;
                }
            }

            return postToUpdate;
        }

        public static void PrintAllPosts(List<Post> collectionOfPosts)
        {
            foreach (var userPost in collectionOfPosts)
            {
                Console.WriteLine($"Title: {userPost.Title}");
                Console.WriteLine($"Message: {userPost.Message}");
                Console.WriteLine($"Author: {userPost.Author}");
                Console.WriteLine($"Created On: {userPost.Date.ToShortDateString()}");
                Console.WriteLine();
            }
        }

        public static bool PostExistsInCollection(List<Post> posts, string postTitle)
        {
            foreach (var post in posts)
            {
                if (String.Equals(postTitle, post.Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CollectionOfPostsIsPopulated(List<Post> posts, out string message)
        {
            if (posts.Count > 0)
            {
                message = "";
                return true;
            }

            message = " There are currently no posts in the collection";
            return false;
        }
    }
}
