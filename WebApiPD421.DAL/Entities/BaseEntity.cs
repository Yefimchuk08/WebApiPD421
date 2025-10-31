using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.DAL.Entities
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; set;  }
        DateTime CreateAt { get; set; }

    }
    public class BaseEntity<TId>: IBaseEntity<TId>
    {
        public virtual TId Id { get; set; } = default!;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    }
}
