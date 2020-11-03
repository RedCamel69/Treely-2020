using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treely_2020
{
    public class BlogSettings
    {
        public string Owner { get; set; } = "The Owner";
        public int PostsPerPage { get; set; } = 2;
        public int CommentsCloseAfterDays { get; set; } = 10;
    }
}
