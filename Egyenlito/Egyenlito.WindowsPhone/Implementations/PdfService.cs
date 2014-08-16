using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyenlito.Implementations
{
    public class PdfService : IPdfService
    {
        public Task<List<string>> RenderPDF(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> RenderLocalPDF(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
