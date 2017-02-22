using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MVVMDemo.Model;

namespace MVVMDemo.ViewModel
{
 public class StudentViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }
       public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Model.Student>();
            // lisataan esimerkin vuoksi muutama opiskelija. oikeassa sovelluksessa haettaisiin tietokannasta
            students.Add(new Student { FirstName = "Kalle", LastName = "Jalkanen" , Asioid="K2392"});
            students.Add(new Student { FirstName = "Teppo", LastName = "Testaaja", Asioid="H2652"});
            students.Add(new Student { FirstName = "Tomi", LastName = "Tottestrom", Asioid = "T3242" });
            students.Add(new Student { FirstName = "Tuomas", LastName = "Tuovaunen", Asioid="I1235" });
            Students = students;
        }
    }
}
