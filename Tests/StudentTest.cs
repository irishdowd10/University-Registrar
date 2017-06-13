using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Registrar
{
  [Collection("Registrar")]
  public class StudentTest : IDisposable
  {
    public StudentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=registrar_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_GetsCountOfStudents_DatabaseEmpty()
    {
      //Arrange, Act
      int result = Student.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }


    [Fact]
    public void Equals_ChecksObjectEquality_True()
    {
      //Arrange, Act
      Student firstStudent = new Student("John", new DateTime(2017, 06, 13));
      Student secondStudent = new Student("John", new DateTime(2017, 06, 13));
      //Assert
      Assert.Equal(firstStudent, secondStudent);
    }

    [Fact]
    public void Save_DoesSaveToDatabase_True()
    {
      //Arrange
      Student testStudent = new Student("John", new DateTime(2017, 06, 13));
      testStudent.Save();
      //Act
      List<Student> result = Student.GetAll();
      List<Student> testList = new List<Student>{testStudent};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Find_FindsStudentInDatabase_True()
    {
      Student testStudent = new Student("John", new DateTime(2017, 06, 13));
      testStudent.Save();

      Student foundStudent = Student.Find(testStudent.GetId());

      Assert.Equal(testStudent, foundStudent);
    }

    [Fact]
    public void TestCourse_AddCourseToStudent_True()
    {
      //Arrange
      Student testStudent = new Student("John", new DateTime(2017, 06, 13));
      testStudent.Save();

      Course firstCourse = new Course("Standard Math", "Math101");
      Course secondCourse = new Course("Standard History", "HST101");
      firstCourse.Save();
      secondCourse.Save();
      //Add
      testStudent.AddCourse(firstCourse);
      testStudent.AddCourse(secondCourse);


      List<Course> result = testStudent.GetCourses();
      List<Course> testList = new List<Course> {firstCourse, secondCourse};
      //Assert
      Assert.Equal(testList, result);
    }


    [Fact]
    public void GetCourses_ReturnAllStudentsCourses_True()
    {
      //Arrange
      Student testStudent = new Student("John", new DateTime(2017, 06, 13));
      testStudent.Save();

      Course firstCourse = new Course("Standard Math", "Math101");
      Course secondCourse = new Course("Standard History", "HST101");
      firstCourse.Save();
      secondCourse.Save();
      //Act
      testStudent.AddCourse(firstCourse);
      List<Course> savedCourses = testStudent.GetCourses();
      List<Course> testList = new List<Course>{firstCourse};
      //Assert
      Assert.Equal(testList, savedCourses);
    }



    public void Dispose()
    {

      Student.DeleteAll();
      Course.DeleteAll();
    }

  }
}
