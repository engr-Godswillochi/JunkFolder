using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public class ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync();
    }
}