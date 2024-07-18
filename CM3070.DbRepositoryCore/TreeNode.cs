using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbRepositoryCore
{
    public class Node
    {
        public string? id { get; set; }
        public string? text { get; set; }
        public string icon { get; set; } = "";
        public string? href { get; set; }
        public string? onclick { get; set; }

    }
    public class TreeNode
    {
        public string? text { get; set; }
        public string icon { get; set; } = "fa fa-folder";

        public bool expanded { get; set; } = false;

        public List<Node>? nodes { get; set; }

    }
}
