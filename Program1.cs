using System;

class Student
{
    public int studentnummer;
    public string naam;
    public int leeftijd;

    public Student(int studentnummer, string naam, int leeftijd)
    {
        this.studentnummer = studentnummer;
        this.naam = naam;
        this.leeftijd = leeftijd;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, Student> studentoverzicht = new Dictionary<int, Student>();

        PopulateStudentsDictionary(studentoverzicht);

        FindStudentByNumber(studentoverzicht, 3);

        FindStudentByNumber(studentoverzicht, 20);

        PrintStudentNumbers(studentoverzicht);

        PrintStudentNames(studentoverzicht);

        SortedDictionary<int, string> sortedstudent = ConvertToSortedDictionary(studentoverzicht);
        PrintSortedStudentList(sortedstudent);

        FindOldestStudent(studentoverzicht);
        PrintStudentsSortedByAge(studentoverzicht);
    }

    private static void PrintStudentNames(Dictionary<int, Student> studentoverzicht)
    {
        Console.WriteLine("Student namen:");
        foreach (var student in studentoverzicht.Values)
        {
            Console.WriteLine(student.naam);
        }
    }

    static void PopulateStudentsDictionary(Dictionary<int, Student> studentoverzicht)
    {
        studentoverzicht.Add(1, new Student(1, "a", 20));
        studentoverzicht.Add(2, new Student(2, "b", 22));
        studentoverzicht.Add(3, new Student(3, "c", 21));
        studentoverzicht.Add(4, new Student(4, "e", 19));
        studentoverzicht.Add(5, new Student(5, "f", 23));
        studentoverzicht.Add(6, new Student(6, "g", 20));
        studentoverzicht.Add(7, new Student(7, "h", 24));
        studentoverzicht.Add(8, new Student(8, "i", 22));
    }

    static void FindStudentByNumber(Dictionary<int, Student> studentoverzicht, int studentnummer)
    {
        if (studentoverzicht.ContainsKey(studentnummer))
        {
            Console.WriteLine($"Student met nummer {studentnummer} gevonden: {studentoverzicht[studentnummer].naam}");
        }
        else
        {
            Console.WriteLine($"Student met nummer {studentnummer} niet gevonden");
        }
    }

    static void PrintStudentNumbers(Dictionary<int, Student> studentoverzicht)
    {
        Console.WriteLine("Studentennummers:");
        foreach (var studentnummer in studentoverzicht.Keys)
        {
            Console.WriteLine(studentnummer);
        }
    }

    static SortedDictionary<int, string> ConvertToSortedDictionary(Dictionary<int, Student> studentoverzicht)
    {
        SortedDictionary<int, string> sortedoverzicht = new SortedDictionary<int, string>();
        foreach (var student in studentoverzicht)
        {
            sortedoverzicht.Add(student.Key, student.Value.naam);
        }
        return sortedoverzicht;
    }

    static void PrintSortedStudentList(SortedDictionary<int, string> sortedstudent)
    {
        Console.WriteLine("Sorted student:");
        foreach (var student in sortedstudent)
        {
            Console.WriteLine($"Student nummer: {student.Key}, naam: {student.Value}");
        }
    }

    static void FindOldestStudent(Dictionary<int, Student> studentoverzicht)
    {
        Student oudstestudent = null;
        foreach (var student in studentoverzicht.Values)
        {
            if (oudstestudent == null || student.leeftijd > oudstestudent.leeftijd)
            {
                oudstestudent = student;
            }
        }
        Console.WriteLine($"Oudste student: {oudstestudent.naam}, Leeftijd: {oudstestudent.leeftijd}");
    }

    static void PrintStudentsSortedByAge(Dictionary<int, Student> studentoverzicht)
    {
        List<Student> sortedstudent = new List<Student>(studentoverzicht.Values);
        sortedstudent.Sort((s1, s2) => s1.leeftijd.CompareTo(s2.leeftijd));

        Console.WriteLine("Studenten gesorteerd op leeftijd:");
        foreach (var student in sortedstudent)
        {
            Console.WriteLine($"Naam: {student.naam}, Leeftijd: {student.leeftijd}");
        }
    }
}

