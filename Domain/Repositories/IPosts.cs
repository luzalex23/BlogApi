using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPosts
    {
        List<PostDTO> GetPagination(int pageNumber, int pageQuantity);

    }
}
