using System;
using System.Collections.Generic;
using System.Configuration;
using StudentRegistration.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace StudentRegistration.DAL
{
    public class StudentRepository
    {
        private readonly string _connectionString = "Server=DELL;Database=StudentDB;User Id=sa;Password=kavi;TrustServerCertificate=True;";

        public void InsertStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.Parameters.AddWithValue("@DOB", student.DOB);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@FatherName", student.FatherName);
                cmd.Parameters.AddWithValue("@MotherName", student.MotherName);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentID = Convert.ToInt32(reader["StudentID"]),
                        Name = reader["Name"].ToString(),
                        Mobile = reader["Mobile"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        DOB = Convert.ToDateTime(reader["DOB"]),
                        Class = reader["Class"].ToString(),
                        FatherName = reader["FatherName"].ToString(),
                        MotherName = reader["MotherName"].ToString()
                    });
                }
            }
            return students;
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.Parameters.AddWithValue("@DOB", student.DOB);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@FatherName", student.FatherName);
                cmd.Parameters.AddWithValue("@MotherName", student.MotherName);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int studentID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", studentID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
