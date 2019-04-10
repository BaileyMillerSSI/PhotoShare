using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareApi.Models
{
    public class PhotoData
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

        public long Likes { get; set; }

        public byte[] Photo { get; set; }

    }
}
