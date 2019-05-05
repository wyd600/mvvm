using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_EF.Dal
{
    public class CRUD
    {
        //创建上下文对象
        static Entities context = new Entities();

        //获取数据库中的所有数据
        public static List<Student> GetData()
        {
            List<Student> result = new List<Student>();
            var list = from u in context.Student
                       select u;
            foreach (Student item in list)
            {
                result.Add(item);
            }
            return result;
        }

        //插入一条数据
        public static void InsertAData(Student str)
        {
            Student student = AddData(str);
            context.Entry<Student>(student).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }

        private static Student AddData(Student str)
        {
            Student student = new Student();
            student.StudentId = str.StudentId;
            student.StudentName = str.StudentName;
            student.StudentAge = str.StudentAge;
            student.StudentSex = str.StudentSex;
            student.StudentAddress = str.StudentAddress;
            return student;
        }

        //删除一条数据
        public static void DeletedAData(Student str)
        {
            Student student = new Student();
            if (str.StudentId != 0)
            {

            }
        }

        //修改一条数据
        public static void Modify()
        {
        }

        //查找一条数据
        public static Student SelectAData()
        {

        }
    }
}
