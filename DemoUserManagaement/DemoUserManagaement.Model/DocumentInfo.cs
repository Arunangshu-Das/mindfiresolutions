using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagaement.Model
{
    public class DocumentInfo
    {
        public int DocumentID { get; set; }
        public int ObjectID { get; set; }
        public int DocumentType { get; set; }

        public string DocumentTypeName {  get; set; }
        public string DocumentOriginalName { get; set; }
        public string DocumentGuidName { get; set; }
        public System.DateTime TimeStamp { get; set; }
    }
}
