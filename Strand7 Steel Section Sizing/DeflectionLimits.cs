using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strand7_Steel_Section_Sizing
{
    class DeflectionLimit
    {
        public DeflectionLimit()
        {
            LoadCasesOutput = new List<int>();
            X = true;
            Y = true;
            Z = true;
            LoadCasesInput = "all";
            DeflectionNodesInput = "all";
        }
        public double Deflection { get; set; }
        public string LoadCasesInput { get; set; }
        public List<int> LoadCasesOutput { get; set; }
        public int ReferenceNode { get; set; }
        public bool X { get; set; }
        public bool Y { get; set; }
        public bool Z { get; set; }
        public string DeflectionNodesInput { get; set; }
        public List<int> DeflectionNodesOutput { get; set; }
    }
}
