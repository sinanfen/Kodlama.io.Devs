using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Dtos
{
    public class GetByUserIdUserOperationClaimDto
    {
        public string Email { get; set; }
        public IEnumerable<string> ClaimsName { get; set; }
    }
}
