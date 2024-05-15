using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public int Status { get; set; }
    }
}
