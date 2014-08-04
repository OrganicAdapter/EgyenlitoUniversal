using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.GroupedItems;

namespace EgyenlitoLIB.Models.Datas
{
    public class Article : IGroupItem
    {
        public int ArticleId { get; set; }
        public string Author { get; set; }
        public string Key { get { return Author; } }
        public string Title { get; set; }
        public string PdfUri { get; set; }
        public int NewspaperId { get; set; }
    }
}
