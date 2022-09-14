using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Social : Entity
    {
        public int DeveloperId { get; set; }
        public string SocialUrl { get; set; }
        public virtual Developer? Developer { get; set; }

        public Social()
        {

        }

        public Social(int id,int developerId, string socialUrl) : this()
        {
            Id=id;
            DeveloperId = developerId;
            SocialUrl = socialUrl;
        }
    }
}
