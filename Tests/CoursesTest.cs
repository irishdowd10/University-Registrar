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
      testCourse.AddStudent(secondStudent);
      testCourse.AddStudent(firstStudent);

      List<Student> result = testCourse.GetStudents();
      List<Student> testList = new List<Student> {firstStudent, secondStudent};
      //Assert
      Assert.Equal(testList, result);

    }


    // [Fact]
    // public void GetStudent_ReturnsAllStudentsWithThisCourse_True()
    // {
    //
    // }


    public void Dispose()
    {
      Course.DeleteAll();
    }

  }
}
