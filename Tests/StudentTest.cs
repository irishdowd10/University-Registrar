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

    public void Dispose()
    {
      Student.DeleteAll();
    }

    [Fact]
    public void Equals_ChecksObjectEquality_True()
    {
      //Arrange, application
      Student firstStudent = new Student("John", new DateTime(2017, 06, 13));
      Student secondStudent = new Student("John", new DateTime(2017, 06, 13));
      //Assert
      Assert.Equal(firstStudent, secondStudent);
    }

  }
}
