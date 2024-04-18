using System;
using Microsoft.EntityFrameworkCore;
namespace Lib
{
    public class Lib
    {

    }
    public class Student
    {
        public Student(int a, string b, string c, string d, Group e)
        {
            id = a;
            fullname = b;
            username = c;
            password = d;
            group = e;
        }
        public Student(int a, string c, string d)
        {
            id = a;
            fullname = null;
            username = c;
            password = d;
            group = null;
        }
        public int id;
        public string fullname;
        public string username;
        public string password;
        public virtual Group group { get; set; } = new Group();
    }
    public class Group 
    {
        public Group()
        {
            name = null;
            currentTest = null;
        }
        public Group(int a, string b, Tests c)
        {
            id = a;
            name = b;
            currentTest = c;
        }
        public int id;
        public string name;
        public virtual Tests currentTest { get; set; } = new Tests();
    }
    public class Teacher
    {
        public Teacher(int a, string b, string c, string d)
        {
            id = a;
            fullname = b;
            username = c;
            password = d;
        }
        public Teacher(int a, string c, string d)
        {
            id = a;
            fullname = null;
            username = c;
            password = d;
        }
        public int id;
        public string fullname;
        public string username;
        public string password;
    }
    public class Tests
    {
        public Tests()
        {
            name = null;
        }
        public Tests(int a, string b, Teacher e, DateTime c, int d)
        {
            id = a;
            name = b;
            teacher = e;
            time = c;
            maxMark = d;
        }

        public int id;
        public string name;
        public virtual Teacher teacher { get; set; }
        public DateTime time;
        public int maxMark;
    }
    public class Questions
    {
        public Questions(int a, string b, Tests c)
        {
            id = a;
            quest = b;
            test = c;
        }

        public int id;
        public string quest;
        public string questionType;
        public virtual Tests test { get; set; } = new Tests();
        public string image;
    }
    public class Answers
    {
        public Answers(int a, string b, Questions c)
        {
            id = a;
            name = b;
            question = c;
        }
        public int id;
        public string name;
        public virtual Questions question { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Countries { get; set; }
        public DbSet<Teacher> Companies { get; set; }
        public DbSet<Tests> Users { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=project_group3;Trusted_Connection=True;");
        }
    }
}

