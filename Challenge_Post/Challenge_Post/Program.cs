using System;
using System.Collections.Generic;

namespace Challenge_Post
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Post> collectionOfPosts = new List<Post>();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Choose one of the following options: (1)Create a new post (2)Update Post (3)View Posts (4)Delete Post ");

                string userChoice = Console.ReadLine();

                Console.Clear();

                string message;
                switch (userChoice)
                {
                    case "1":
                        Console.Write("Post Title: ");
                        string postTitle = Console.ReadLine();

                        Console.Write("Post Message: ");
                        string postMessage = Console.ReadLine();

                        Console.Write("Post Author: ");
                        string postAuthor = Console.ReadLine();

                        Post post = new Post(postTitle, postMessage, postAuthor);

                        collectionOfPosts.Add(post);

                        Console.Clear();

                        Console.WriteLine("Here is what your new post looks like:");
                        Console.WriteLine(post.GetCompletePostString());

                        Console.WriteLine();
                        break;
                    case "2":
                        if (PostActions.CollectionOfPostsIsPopulated(collectionOfPosts, out message))
                        {
                            Console.WriteLine("Please choose the title of the post you would like to update.");

                            PostActions.PrintAllPosts(collectionOfPosts);

                            Console.Write("Title: ");

                            string titleOfPostToUpdate = Console.ReadLine();


                            Console.Clear();

                            if (PostActions.PostExistsInCollection(collectionOfPosts, titleOfPostToUpdate))
                            {
                                Post postToUpdate =
                                    PostActions.GetSpecificPostToUpdate(collectionOfPosts, titleOfPostToUpdate);

                                Console.WriteLine("Which property would you like to update?");
                                Console.WriteLine("(1)Title (2)Message (3)Author");
                                string propertyToUpdate = Console.ReadLine();

                                Console.WriteLine("What is the updated value?");
                                string updatedValue = Console.ReadLine();
                                postToUpdate =
                                    PostActions.UpdateEntirePost(propertyToUpdate, postToUpdate, updatedValue);

                                Console.Clear();

                                Console.WriteLine("Here is your updated Post");
                                Console.WriteLine(postToUpdate.GetCompletePostString());
                            }
                            else
                            {
                                Console.WriteLine("A post by that title cannot be found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(message);
                        }

                        break;
                    case "3":
                        
                        if (PostActions.CollectionOfPostsIsPopulated(collectionOfPosts, out message))
                        {
                            PostActions.PrintAllPosts(collectionOfPosts); 
                        }
                        else
                        {
                            Console.WriteLine(message);
                        }
                        break;

                    case "4":
                        if (PostActions.CollectionOfPostsIsPopulated(collectionOfPosts, out message))
                        {
                            Console.WriteLine("Please choose the title of the post you would like to delete.");

                            PostActions.PrintAllPosts(collectionOfPosts);

                            Console.Write("Title: ");

                            string titleOfPostToDelete = Console.ReadLine();

                            Console.Clear();

                            if (PostActions.PostExistsInCollection(collectionOfPosts, titleOfPostToDelete))
                            {
                                Post postToDelete = PostActions.GetSpecificPostToUpdate(collectionOfPosts, titleOfPostToDelete);

                                collectionOfPosts.Remove(postToDelete);

                                Console.WriteLine($"Post titled {postToDelete.Title} has been deleted");
                            }
                            else
                            {
                                Console.WriteLine("A post by that title cannot be found.");
                            } 
                        }
                        else
                        {
                            Console.WriteLine(message);
                        }
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;
                }

                Console.WriteLine("Return to main menu? (Y)es or (N)o");
                string choiceToReturnToMain = Console.ReadLine().ToLower().Trim();

                if (choiceToReturnToMain != "y")
                {
                    keepGoing = false;
                }

                Console.Clear();
            }

            Console.WriteLine("Press ENTER to exit application.");
            Console.ReadLine();

        }
    }
}
