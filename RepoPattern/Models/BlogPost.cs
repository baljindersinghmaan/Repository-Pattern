using System.ComponentModel.DataAnnotations;

namespace Repo_Pattern.RepoPattern;

public class BlogPost{
    public string Name {get; set;}

    public string Description {get; set;}
    public DateTime PublishDate {get; set;}

    public Author Author {get; set;}

    [Key]
    public string URL {set; get;}

    public Blog Blog {set; get;}
}