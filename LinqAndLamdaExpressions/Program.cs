namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var allUsers = ReadUsers("users.json");
            var allPosts = ReadPosts("posts.json");

            // 1 - find all users having email ending with ".net".
            var users2 = from u in allUsers
                where u.Email.EndsWith(".net")
                select u;

            var users3 = allUsers.Where(x => x.Email.EndsWith(".net"));

            var emails = allUsers.Select(x => x.Email).ToList();

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user4 in allUsers
                                                       where user4.Email.EndsWith(".net")
                                                       select user4.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }


            // 3 - print number of posts for each user.
            Dictionary<int, int> userPosts = new Dictionary<int, int>();
           
            foreach (var post in allPosts)
            {
                var userId = post.UserId;

                if (userPosts.ContainsKey(userId))
                {
                    userPosts[userId]++;
                }
                else
                {
                    userPosts.Add(userId, 1);
                }
            }

            foreach (var value in userPosts)
            {
                Console.WriteLine($"User {value.Key} has {value.Value} posts ");
            }

            var result = allPosts.GroupBy(p => p.UserId).Select(g => new
            {
                UserId = g.Key,
                NumberOfPosts = g.Count()
            });


            // 4 - find all users that have lat and long negative.

            IEnumerable<User> userss = from u in allUsers
                         where u.Address.Geo.Lng <= 0 
                         select u;
            foreach (var i in allUsers)
            {
                if (i.Address.Geo.Lng <= 0)
                {
                    Console.WriteLine(i.Name + " has negative long");
                }
                
                    

            }
            Console.WriteLine();
            IEnumerable<User> users5 = from u in allUsers
                                       where u.Address.Geo.Lat <= 0
                                       select u;
            foreach (var i in allUsers)
            {
                if(i.Address.Geo.Lat <= 0)
                {

                    Console.WriteLine(i.Name + " has negative lat");
                }
                
            }


            // 5 - find the post with longest body.

            var postLongestBody = (allPosts.Select(p => p.Body.Length)).Max();
            IEnumerable<Post> postWithLongestBody = (allPosts.Where(p => p.Body.Length == postLongestBody));


            // 6 - print the name of the employee that have post with longest body.
            var postLongestBody2 = (allPosts.Select(p => p.Body.Length)).Max();
            IEnumerable<Post> userWithLongestBody = allPosts.Where(p => p.Body.Length == postLongestBody2);
            
            



            // 7 - select all addresses in a new List<Address>. print the list.

            List<Address> allAddresses = (allUsers.Select(us => us.Address)).ToList();
            




            // 8 - print the user with min lat
            var usersOrderByLat = from u in allUsers
                                    orderby u.Address.Geo.Lat
                                    select u;

            var user = usersOrderByLat.First();

            var minLat = allUsers.Min(x => x.Address.Geo.Lat);


            // 9 - print the user with max long
            var usersOrderByLong = from u3 in allUsers
                                   orderby u3.Address.Geo.Lng
                                   select u3;
            var userWithMaxLong = usersOrderByLat.First();
            var maxLong = allUsers.Max(u3 => u3.Address.Geo.Lng);


            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only

            var list = new List<UserPosts>();

            foreach (var u in allUsers)
            {
                list.Add(new UserPosts
                {
                    User = u,
                    Posts = allPosts.Where(p => p.UserId == u.Id).ToList()
                });
            }


            // 11 - order users by zip code
            
            var usersOrderByZipCode = allUsers.OrderBy(x => x.Address.Zipcode).ToList();
            
            var usersOrderByZipCode2 = from i in allUsers
                                      orderby i.Address.Zipcode.ToList()
                                      select i;
            

            // 12 - order users by number of posts
            
                   








        }
        public class UserPosts
        {
            public User User { get; set; }

            public List<Post> Posts { get; set; }
        }
        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
        
    }
}
