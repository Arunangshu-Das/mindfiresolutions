using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagaement.Model
{
    public class NotesInfo
    {
        public int NoteID { get; set; }
        public int ObjectID { get; set; }
        public string NoteText { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
