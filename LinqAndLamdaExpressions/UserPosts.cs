using LinqAndLamdaExpressions.Models;
using System.Collections.Generic;

namespace LinqAndLamdaExpressions
{
    public class UserPosts
    {
         public User User { get; set; } 
         public List<Post> Posts { get; set; } 
    }
}