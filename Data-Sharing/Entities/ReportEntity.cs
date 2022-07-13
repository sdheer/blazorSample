using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Sharing.Entities
{
    public class ReportEntity
    {
        public List<Item> Items { get; set; }
        public string StoreName { get; set; }
        public string UserName {  get; set; }
    }
}
