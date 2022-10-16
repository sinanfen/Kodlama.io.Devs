using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Dtos
{
    public class LoggedDto:RefreshedTokenDto
    {
        public AuthenticatorType? AuthenticatorType { get; set; }
    }
}
