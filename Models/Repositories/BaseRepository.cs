using System;
using Microsoft.EntityFrameworkCore;

namespace PhoneManager.Models.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContext context;

        public BaseRepository(AppDBContext context)
        {
            this.context = context;
        }
    }
}
