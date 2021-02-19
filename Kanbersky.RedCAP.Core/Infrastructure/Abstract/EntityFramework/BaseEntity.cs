using System;

namespace Kanbersky.RedCAP.Core.Infrastructure.Abstract.EntityFramework
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
