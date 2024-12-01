using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories
{
    public partial class Courses
    {
        public override string ToString()
        {
            return Name + " " + Date + " " + Professor + " " + Aud + " ";
        }
    }

    public partial class Students
    {
        public override string ToString()
        {
            return Name + " " + Surname + " " + NumberGroup + " " + Id_courses;
        }
    }

    public partial class Records
    {
        public override string ToString()
        {
            return Id_students.ToString() + Id_courses.ToString() ;
        }
    }
}
