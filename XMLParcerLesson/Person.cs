using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParcerLesson
{
    public class Person
    {
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public int Age
        {
            get
            {
                if (BirthDay != null)
                {
                    return DateTime.Now.Year - BirthDay.Value.Year;
                }
                return 0;
            }
        }
    }
}
