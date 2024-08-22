using AdvanceListAssignment;

public class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 20, Grade = 85.5 },
                new Student { Id = 2, Name = "Bob", Age = 22, Grade = 90.0 },
                new Student { Id = 3, Name = "Charlie", Age = 19, Grade = 78.0 },
                new Student { Id = 4, Name = "David", Age = 21, Grade = 92.5 },
                new Student { Id = 5, Name = "Eva", Age = 23, Grade = 88.0 }
            };

        // Add a new student
        AddStudent(students, new Student { Id = 6, Name = "Frank", Age = 20, Grade = 80.0 });

        // Remove a student by ID
        RemoveStudent(students, 3);

        // Print all students
        PrintAllStudents(students);

        // Sort students by grade
        SortStudentsByGrade(students);
        Console.WriteLine("\nStudents sorted by grade:");
        PrintAllStudents(students);

        // Sort students by name
        SortStudentsByName(students);
        Console.WriteLine("\nStudents sorted by name:");
        PrintAllStudents(students);

        // Filter students by grade
        List<Student> highGrades = FilterStudentsByGrade(students, 85.0);
        Console.WriteLine("\nStudents with grade above 85.0:");
        PrintAllStudents(highGrades);

        // Find student by ID
        Student student = FindStudentById(students, 2);
        if (student != null)
        {
            Console.WriteLine($"\nFound student: ID: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
        }
        else
        {
            Console.WriteLine("\nStudent not found.");
        }

        // Calculate average grade
        double averageGrade = CalculateAverageGrade(students);
        Console.WriteLine($"\nAverage Grade: {averageGrade}");

        // Find student with highest grade
        Student topStudent = FindStudentWithHighestGrade(students);
        if (topStudent != null)
        {
            Console.WriteLine($"Student with Highest Grade: ID: {topStudent.Id}, Name: {topStudent.Name}, Grade: {topStudent.Grade}");
        }
    }

    static void AddStudent(List<Student> students, Student newStudent)
    {
        students.Add(newStudent);
    }

    static void RemoveStudent(List<Student> students, int id)
    {
        Student studentToRemove = students.FirstOrDefault(s => s.Id == id);
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
        }
    }

    static void PrintAllStudents(List<Student> students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
    }

    static void SortStudentsByGrade(List<Student> students)
    {
        students.Sort((s1, s2) => s2.Grade.CompareTo(s1.Grade));
    }

    static void SortStudentsByName(List<Student> students)
    {
        students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
    }

    static List<Student> FilterStudentsByGrade(List<Student> students, double threshold)
    {
        return students.Where(s => s.Grade > threshold).ToList();
    }

    static Student FindStudentById(List<Student> students, int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    static double CalculateAverageGrade(List<Student> students)
    {
        if (students.Count == 0)
            return 0;

        double sum = students.Sum(s => s.Grade);
        return sum / students.Count;
    }

    static Student FindStudentWithHighestGrade(List<Student> students)
    {
        return students.OrderByDescending(s => s.Grade).FirstOrDefault();
    }
}
