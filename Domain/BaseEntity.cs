using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriegspieltech.Domain
{
    public abstract partial class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
