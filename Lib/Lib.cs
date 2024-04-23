using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Lib
{
    public class Marks
    {
        //public Marks(Student b, Tests c, int d, DateTime e)
        //{
        //    student = b;
        //    test = c;
        //    mark = d;
        //    date = e;
        //}
        public int id { get; set; }
        public int studentId { get; set; }
        public virtual Student student { get; set; }
        
        public virtual Tests test { get; set; }
        public int mark { get; set; }
        public DateTime date { get; set; }
    }
    public class Student
    {
        //public Student(string c, string d, Group e)
        //{
        //    username = c;
        //    password = d;
        //    group = e;
        //}
        //public Student(string c, string d)
        //{
        //    username = c;
        //    password = d;
        //    group = null;
        //}
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int groupId { get; set; }
        public virtual Group group { get; set; } = new Group();
        public ICollection<Marks> mark { get; set; }
    }
    public class Group 
    {
        //public Group()
        //{
        //    name = null;
        //    currentTest = null;
        //}
        //public Group(string b, Tests c)
        //{
        //    name = b;
        //    currentTest = c;
        //}
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int currentTestId { get; set; }
        public virtual Tests currentTest { get; set; } = new Tests();
        public ICollection<Student> student { get; set; }
    }
    public class Teacher
    {
        //public Teacher(string b, string c, string d)
        //{
        //    username = c;
        //    password = d;
        //}
        //public Teacher(string c, string d)
        //{
        //    username = c;
        //    password = d;
        //}
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public ICollection<Tests> test { get; set; }
    }
    public class Tests
    {
        //public Tests()
        //{
        //    name = null;
        //}
        //public Tests(string b, Teacher e, DateTime c)
        //{
        //    name = b;
        //    teacher = e;
        //    time = c;
        //}

        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int teacherId { get; set; }
        public virtual Teacher teacher { get; set; }
        public DateTime time { get; set; }
    }
    public class Questions
    {
        //public Questions(string b, Tests c, int d, int e)
        //{
        //    quest = b;
        //    questionType = "Test";
        //    test = c;
        //    whatIsRight = d;
        //    score = e;
        //}

        public int id { get; set; }
        [Required]
        public string quest { get; set; }
        public string questionType { get; set; }
        public int testId { get; set; }
        public virtual Tests test { get; set; } = new Tests();
        public int whatIsRight { get; set; }
        public int score { get; set; }
        public byte[] image { get; set; }
        public ICollection<Answers> answer { get; set; }
    }
    public class Answers
    {
        //public Answers(string b, Questions c)
        //{
        //    name = b;
        //    question = c;
        //}
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int questionId { get; set; }
        public virtual Questions question { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=project_group3;Trusted_Connection=True;");
        }
    }
}

