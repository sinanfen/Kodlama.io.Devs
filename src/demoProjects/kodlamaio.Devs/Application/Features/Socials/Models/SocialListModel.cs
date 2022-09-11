using Application.Features.Socials.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Models
{
    public class SocialListModel : BasePageableModel
    {
        public IList<SocialListDto> Items { get; set; }
    }
}
