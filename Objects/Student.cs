using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Registrar
{
  public class Student
  {
    private int _id;
    private string _name;
    private DateTime _enrollment;

  public Student(string Name, DateTime Enrollment, int Id = 0)
  {
    _id = Id;
    _name = Name;
    _enrollment = Enrollment;
  }

  public override bool Equals(System.Object otherStudent)
  {
    if(!(otherStudent is Student))
    {
      return false;
    }
    else
    {
      Student newStudent = (Student) otherStudent;
      bool idEquality = (this.GetId() == newStudent.GetId());
      bool nameEquality = (this.GetName() == newStudent.GetName());
      bool enrollmentEquality = (this.GetEnrollmentDate() == newStudent.GetEnrollmentDate());
      return (idEquality && nameEquality && enrollmentEquality);
    }
  }

  //GETTERS
  public int GetId()
  {
    return _id;
  }

  public string GetName()
  {
    return _name;
  }

  public DateTime GetEnrollmentDate()
  {
    return _enrollment;
  }

  //SETTERS
  public void SetName(string Name)
  {
    _name = Name;
  }

  public void SetEnrollment(DateTime Enrollment)
  {
    _enrollment = Enrollment;
  }


//CLASS METHODS

//GetAll
  public static List<Student> GetAll()
  {
    List<Student> allStudents = new List<Student>{};

    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM students", conn);
    SqlDataReader rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      int studentId = rdr.GetInt32(0);
      string studentName = rdr.GetString(1);
      DateTime studentEnrollment = rdr.GetDateTime(2);

      Student newStudent = new Student(studentName, studentEnrollment, studentId);
      allStudents.Add(newStudent);
    }

    if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }
        return allStudents;
    }



    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO students (name, enrollment_date) OUTPUT INSERTED.id VALUES (@StudentName, @EnrollmentDate);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StudentName";
      nameParameter.Value = this.GetName();

      SqlParameter enrollmentParameter = new SqlParameter();
      enrollmentParameter.ParameterName = "@EnrollmentDate";
      enrollmentParameter.Value = this.GetEnrollmentDate();

      cmd.Parameters.Add(enrollmentParameter);
      cmd.Parameters.Add(nameParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {

        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }





//DeleteAll
  public static void DeleteAll()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();
    SqlCommand cmd = new SqlCommand("Delete FROM students;", conn);
    cmd.ExecuteNonQuery();
    conn.Close();
  }











  }
}
