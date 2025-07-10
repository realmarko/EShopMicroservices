using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.DTO
{
    public record AuthenticationResponseDTO(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success
        )
    {
        //Parameterless constructor for serialization/deserialization
        public AuthenticationResponseDTO() : this(Guid.Empty, null, null, null, null, false) { }
    }


}
