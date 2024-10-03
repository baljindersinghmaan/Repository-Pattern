namespace Repo_Pattern.RepoPattern;

    public class Blog {
        
        public string? Description {get; set;}
        public string Name {get; set;}
        public string URL {get; set;}

        public List<BlogPost>? BlogPosts{get; set;}

        protected Blog() {}

        public Blog(string url, string name){
            this.URL = url;
            this.Name = name;
        }
        public Blog(string url, string name, string description) : this(url, name){
            
            this.Description = description;
        }

    }
