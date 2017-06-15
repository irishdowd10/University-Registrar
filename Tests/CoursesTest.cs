using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Registrar
{
  [Collection("Registrar")]
  public class CourseTest : IDisposable
  {
    public CourseTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=registrar_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_GetsCountOfCourses_DatabaseEmpty()
    {
      //Arrange, Act
      int result = Course.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }


    [Fact]
    public void Equals_ChecksObjectEquality_True()
    {
      //Arrange, Act
      Course firstCourse = new Course("Standard Math", "Mat101");
      Course secondCourse = new Course("Standard Math", "Mat101");
      //Assert
      Assert.Equal(firstCourse, secondCourse);
    }

    [Fact]
    public void Save_DoesSaveToDatabase_True()
    {
      //Arrange
      Course testCourse = new Course("Standard Math", "Mat101");
      testCourse.Save();
      //Act
      List<Course> result = Course.GetAll();
      List<Course> testList = new List<Course>{testCourse};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Find_FindsCourseInDatabase_True()
    {
      Course testCourse = new Course("Standard Math", "Mat101");
      testCourse.Save();

      Course foundCourse = Course.Find(testCourse.GetId());

      Assert.Equal(testCourse, foundCourse);
    }

    [Fact]
    public void AddStudent_AddStudentToCourse_True()
    {
      //Arrange
      Course testCourse = new Course("Standard Math", "Mat101");
      testCourse.Save();

      Student firstStudent = new Student("John", new DateTime(2017, 06, 13));
      Student secondStudent = new Student("Jordan", new DateTime(2017, 06, 13));
      firstStudent.Save();
      secondStudent.Save();
      //Add
      testCourse.AddStudent(firstStudent);
      testCourse.AddStudent(secondStudent);

      List<Student> result = testCourse.GetStudents();
      List<Student> testList = new List<Student> {firstStudent, secondStudent};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void GetStudents_ReturnAllCoursesStudents_True()
    {
      //Arrange
      Course testCourse = new Course("Standard Math", "Math101");
      testCourse.Save();

      Student testStudent1 = new Student("John", new DateTime(2017, 06, 13));
      Student testStudent2 = new Student("Jordan", new DateTime(2017, 06, 13));
      testStudent1.Save();
      testStudent2.Save();
      //Act
      testCourse.AddStudent(testStudent1);
      List<Student> savedStudents = testCourse.GetStudents();
      List<Student> testList = new List<Student>{testStudent1};
      //Assert
      Assert.Equal(testList, savedStudents);
    }

    [Fact]
    public void Delete_DeletesCourseAssociationsFromDatabase_CourseList()
    {
      //Arrange
      Student testStudent = new Student("John", new DateTime (2017, 06, 13));
      testStudent.Save();

      Course testCourse = new Course("American History","HST201");
      testCourse.Delete();


      //Act
      testCourse.AddStudent(testStudent);
      testCourse.Delete();

      List<Course> result = testStudent.GetCourses();
      List<Course> test = new List<Course> {};

      //Assert
      Assert.Equal(test, result);
    }

    [Fact]
    public void Edit_EditsesCourseInDatabase()
    {
      //Arrange
      Course newCourse = new Course("History", "HST201");
      newCourse.Save();
      newCourse.Edit("American", "HST301");

     //Act
     Course newerCourse = new Course("American", "HST201");



     Assert.Equal(newCourse,newerCourse);
    }

    public void Dispose()
    {
      Course.DeleteAll();
      Student.DeleteAll();
    }

  }
}
