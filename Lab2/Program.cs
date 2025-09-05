class StudentGroup
{
    private string groupName;
    private string[] members;
    private int numberOfMembers;

    public StudentGroup();
    public StudentGroup(string groupName, int size);
    public addMember(string name);
    public getMember(int position);
    public displayGroup();
}