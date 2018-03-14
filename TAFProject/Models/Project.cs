
namespace TAFProject.Models
{
	public class Project
	{
	    public string Name { get; set; }
        public string Description { get; set; }
	    public string Identifier { get; set; }
	    public string Homepage { get; set; }
        public bool Public { get; set; }
	    public bool InheritMembers { get; set; }
    }
}
