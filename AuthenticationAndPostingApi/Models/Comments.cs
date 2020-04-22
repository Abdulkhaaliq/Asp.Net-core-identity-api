using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAndPostingApi.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string UsersComment { get; set; }
        public DateTime DateOfComment { get; set; }
        public int CommentVotes { get; set; }
        public string UserId { get; set; }
    }
}
