using System.ComponentModel.DataAnnotations;

namespace Repo_Pattern.RepoPattern;

    public class Blog {
        
        public string? Description {get; set;}
        public string Name {get; set;}
        [Key]
        public string URL {get; set;}
        private IList<BlogPost> _blogPosts = new List<BlogPost>();

        public IReadOnlyCollection<BlogPost>? BlogPosts => _blogPosts.AsReadOnly();

        protected Blog() {}

        public Blog(string url, string name){
            
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri)) {
                throw new UriFormatException("Invalid URL format");
            }
            this.URL = url;
            if(string.IsNullOrEmpty(name)){
                throw new ArgumentNullException("Name cannot be null or empty");
            }
            this.Name = name;
        }
        public Blog(string url, string name, string description) : this(url, name){
            
            this.Description = description;
        }
        public void AddBlogPost(string url, string name){
                _blogPosts.Add(new BlogPost() {URL = url, Name = name});
        }

    }
