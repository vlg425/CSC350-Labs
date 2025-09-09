//*************************************************
//Authors: Victor Garcia, Tiffany Turner
//CSC350
//StudentGroups Lab 2
//*************************************************

class StudentGroup
{
    private string groupName;
    private string[] studentNames;
    private int maxGroupSize; //number of students in group
    private int currentStudentCount; //current number of students in group


    //Constructors
    public StudentGroup()
    {
        groupName = "Team Alpha";
        maxGroupSize = 3;
        currentStudentCount = 0;
        studentNames = new string[maxGroupSize];
    }


    public StudentGroup(string groupName, int maxGroupSize)
    {
        this.groupName = groupName;
        this.maxGroupSize = maxGroupSize;
        currentStudentCount = 0;
        studentNames = new string[maxGroupSize];
    }

    //Add student function: pass a name and it gets added to student Names array, incremients current student
    public void AddStudent(string name)
    {
        if (currentStudentCount < maxGroupSize)
        {
            studentNames[currentStudentCount] = name;
            currentStudentCount++;
        }
        else
        {
            Console.WriteLine("Cannot add more students; group is full.");
        }
    }

    //Get student function: pass position, retrieves name of student at that location in array, checks that it is between 0 and current student count
    public void GetStudent(int position)
    {
        if (position >= 0 && position < currentStudentCount)
        {
            Console.WriteLine($"{studentNames[position]}");
        }
        else
        {
            Console.WriteLine("Invalid position.");
        }
    }


    //show student function: prints group name then iterates through student names and prints all studetns in group
    public void ShowStudents()
    {
        Console.WriteLine($"Group: {groupName}");
        for (int i = 0; i < currentStudentCount; i++)
        {
            Console.WriteLine($"- {studentNames[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        StudentGroup group1 = new StudentGroup("Team Alpha", 3);
        group1.AddStudent("Alice");
        group1.AddStudent("Bob");
        group1.AddStudent("Charlie");

        group1.ShowStudents();
        Console.WriteLine();

        Console.WriteLine("Student at positon 0: ");
        group1.GetStudent(0);
        Console.WriteLine();

        Console.WriteLine("Student at positon -1: ");
        group1.GetStudent(-1);
        Console.WriteLine();
        
        group1.AddStudent("Denise");
    }
}




