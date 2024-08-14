using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbRepositoryCore
{
    public class PhysicianSearchParams
    {
        public string Id {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }

    public class Row
    {
        public string? Id { get; set; }
    }
    public class RowId
    {
        public int Id { get; set; }
    }

    public class RowDate
    {
        public DateTime datetime { get; set; }
    }
}
