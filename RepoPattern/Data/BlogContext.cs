


namespace Repo_Pattern.RepoPattern;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repo_Pattern.RepoPattern;


public class BlogContext : DbContext{
    public DbSet<Author> Authors  {get; set;} = null;
    public DbSet<BlogPost> BlogPosts{get; set;} = null;

    public DbSet<Blog> Blogs {get; set;} = null;

    public BlogContext (DbContextOptions<BlogContext> options) : base(options){}
}

