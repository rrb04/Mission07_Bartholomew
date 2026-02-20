using Microsoft.EntityFrameworkCore;

namespace Mission07_Bartholomew.Models
{
	public class MovieCollectionContext : DbContext
	{
		public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }
		// Adding the new Categories table to the context
		public DbSet<Category> Categories { get; set; }
	}
}