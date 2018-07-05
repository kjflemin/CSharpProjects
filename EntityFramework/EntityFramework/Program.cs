using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework {
	class Program {
		static void Main(string[] args)
		{
			AddStudent("Keith Fleming");
			UpdateStudent("Keith Fleming", "Zack Fleming");
			DeleteStudent("Zack Fleming");

			AddStudent("Fleming");
			AddStudent("Keith");
			
			List<Students> s = GetStudentList();
			
		}

		public static List<Students> GetStudentList()
		{
			List<Students> ListOfStudents = new List<Students>();
			KeithEntityModelContainer K = new KeithEntityModelContainer();
			foreach (EntityFramework.Students item in K.Students.Select(row => row)) {
				ListOfStudents.Add(item);
			}

			return ListOfStudents;
		}

		public static void DeleteStudent(string Name)
		{
			Students studentToDelete;
			//1. Get student from DB
			using (var ctx = new KeithEntityModelContainer()) {
				studentToDelete = ctx.Students.Where(s => s.Name == Name).FirstOrDefault<Students>();
			}

			//Create new context for disconnected scenario
			using (var newContext = new KeithEntityModelContainer()) {
				newContext.Entry(studentToDelete).State = System.Data.Entity.EntityState.Deleted;
				newContext.SaveChanges();
			}
		}

		public static void UpdateStudent(string OldName, string NewName)
		{
			Students student;
			//1.Get student from DB
			using (var entityModel = new KeithEntityModelContainer()) {
				student = entityModel.Students.Where(s => s.Name == OldName).FirstOrDefault<Students>();
			}

			//2.change student name
			if (student != null) {
				student.Name = NewName;
			}

			//3.save entity
			using (var entityModel = new KeithEntityModelContainer()) {
				//a. Mark as modified
				entityModel.Entry(student).State = System.Data.Entity.EntityState.Modified;
				//b. save changes
				entityModel.SaveChanges();
			}

		}

		public static void AddStudent(string Name)
		{
			Students student = new Students();

			student.Name = Name;

			//add a student
			using (var newStudent = new KeithEntityModelContainer()) {
				newStudent.Students.Add(student);
				newStudent.SaveChanges();
			}

		}
	}
}
