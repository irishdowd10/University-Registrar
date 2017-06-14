using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Registrar
{
  public class Course
  {
    private int _id;
    private string _name;
    private string _courseNumber;

  public Course(string Name, string courseNumber, int Id = 0)
  {
    _name = Name;
    _courseNumber = courseNumber;
    _id = Id;
  }

  public override bool Equals(System.Object otherCourse)
  {
    if(!(otherCourse is Course))
    {
      return false;
    }
    else
    {
      Course newCourse = (Course) otherCourse;
      bool idEquality = (this.GetId() == newCourse.GetId());
      bool nameEquality = (this.GetName() == newCourse.GetName());
      bool courseNumberEquality = (this.GetCourseNumber() == newCourse.GetCourseNumber());
      return (idEquality && nameEquality && courseNumberEquality);
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

  public string GetCourseNumber()
  {
    return
    _courseNumber;
  }

  //SETTERS
  public void SetName(string Name)
  {
    _name = Name;
  }

  public void SetCourseNumber(string CourseNumber)
  {
    _courseNumber = CourseNumber;
  }


//CLASS METHODS

//GetAll
  public static List<Course> GetAll()
  {
    List<Course> allCourses = new List<Course>{};

    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM courses", conn);
    SqlDataReader rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      int courseId = rdr.GetInt32(0);
      string courseName = rdr.GetString(1);
      string courseNumber = rdr.GetString(2);

      Course newCourse = new Course(courseName, courseNumber, courseId);
      allCourses.Add(newCourse);
    }

    if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }
        return allCourses;
    }



    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO courses (name, course_number) OUTPUT INSERTED.id VALUES (@CourseName, @CourseNumber);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@CourseName";
      nameParameter.Value = this.GetName();

      SqlParameter courseNumberParameter = new SqlParameter();
      courseNumberParameter.ParameterName = "@CourseNumber";
      courseNumberParameter.Value = this.GetCourseNumber();

      cmd.Parameters.Add(courseNumberParameter);
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

//Find
    public static Course Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses WHERE id = @CourseId;", conn);
      SqlParameter CourseIdParameter = new SqlParameter();
      CourseIdParameter.ParameterName = "@CourseId";
      CourseIdParameter.Value = id.ToString();
      cmd.Parameters.Add(CourseIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundCourseId = 0;
      string foundCourseName = null;
      string foundCourseNumber = null;

      while(rdr.Read())
      {
        foundCourseId = rdr.GetInt32(0);
        foundCourseName = rdr.GetString(1);
        foundCourseNumber = rdr.GetString(2);
      }
      Course foundCourse = new Course(foundCourseName, foundCourseNumber, foundCourseId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundCourse;
      }

// AddStudent
    public void AddStudent(Student newStudent)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO courses_students (course_id, student_id) VALUES (@CourseId, @StudentId);", conn);

      SqlParameter CourseIdParameter = new SqlParameter();
      CourseIdParameter.ParameterName = "@CourseId";
      CourseIdParameter.Value = this.GetId();
      cmd.Parameters.Add(CourseIdParameter);

      SqlParameter StudentIdParameter = new SqlParameter();
      StudentIdParameter.ParameterName = "@StudentId";
      StudentIdParameter.Value = newStudent.GetId();
      cmd.Parameters.Add(StudentIdParameter);

      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }


    public List<Student> GetStudents()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT students.* FROM courses JOIN courses_students ON (courses.id = courses_students.course_id) JOIN students ON (courses_students.student_id = students.id) WHERE courses.id = @CourseId;", conn);

      SqlParameter CourseIdParameter = new SqlParameter();
      CourseIdParameter.ParameterName = "@CourseId";
      CourseIdParameter.Value = this.GetId();

      cmd.Parameters.Add(CourseIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Student> students = new List<Student>{};

      while(rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string studentName = rdr.GetString(1);
        DateTime studentEnrollment = rdr.GetDateTime(2);

        Student newStudent = new Student(studentName, studentEnrollment, studentId);
        students.Add(newStudent);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return students;
    }

  //Delete Course
      public void Delete()
      {
        SqlConnection conn = DB.Connection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM courses WHERE id = @CourseId; DELETE FROM courses_students WHERE course_id = @CourseId;", conn);
        SqlParameter courseIdParameter = new SqlParameter();
        courseIdParameter.ParameterName = "@CourseId";
        courseIdParameter.Value = this.GetId();

        cmd.Parameters.Add(courseIdParameter);
        cmd.ExecuteNonQuery();

        if (conn != null)
        {
          conn.Close();
        }
      }


//DeleteAll
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("Delete FROM courses;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }







  }
}
