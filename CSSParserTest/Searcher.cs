using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Forms;

namespace CSSParser
{
    public class Searcher
    {
        public List<int> FindInTreeView(string query, TreeView tv)
        {
            List<int> resultIndexes = new List<int>();
            for(int i = 0 ; i < tv.Nodes.Count ; i++)
            {
                if(tv.Nodes[i].Text.IndexOf(query) != -1)
                {
                    resultIndexes.Add(i);
                }
            }
            return resultIndexes;
        }
    }
}
