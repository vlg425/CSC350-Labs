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

    //Add student function: pass a name and it gets added to student Names array, incremients current student count
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


    public void GetStudent(int position)
    {
        
    }


    public void ShowStudents()
    {
       
    }
}



