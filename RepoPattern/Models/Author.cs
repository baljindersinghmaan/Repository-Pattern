using System.ComponentModel.DataAnnotations;

namespace Repo_Pattern.RepoPattern;

public class Author : IAggregateRoots{
    public string Name {set; get;}

    [Key]
    public string Email {set; get;}

     protected Author() {}

    public Author (string email, string name){

        if (!email.Contains("@") || !email.Contains(".")) {
            throw new ArgumentNullException("Incorrect email");
        }
        this.Email = email;
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentNullException("Name is must");
        }
        this.Name = name;

        
    }
}