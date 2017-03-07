using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MVVMDemo.Model;
using MySql.Data.MySqlClient;
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
        //metodi StudentViewModeliin jolla haetaan oppilastiedot mysql-palvemilta
        public void LoadStudentsFromMysql()
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT firstname, lastname, asioid FROM student";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MVVMDemo.Model.Student s = new Model.Student();
                            s.FirstName = reader.GetString(0);
                            s.LastName = reader.GetString(1);
                            s.Asioid = reader.GetString(2);
                            students.Add(s);
                        }
                        Students = students;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private string GetMysqlConnectionString()
        {
            string pw = "eitieda";
            pw = MVVMDemo.Properties.Settings.Default.Passu;

            //sql ww osoite, catalog= tietokanta
            return string.Format("Data source=mysql.labranet.jamk.fi;Initial Catalog=K8491_1;user=K8491;password={0}", pw);
        }

    }
}
