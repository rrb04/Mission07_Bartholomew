using Microsoft.EntityFrameworkCore;

namespace Mission06_Bartholomew.Models
{
	// The class name here matches the filename in your screenshot
	public class MovieCollectionContext : DbContext
	{
		public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().HasData(
				new Movie { MovieId = 1, Category = "Action", Title = "The Dark Knight", Year = 2008, Director = "Christopher Nolan", Rating = "PG-13", Edited = false, LentTo = "", Notes = "Best movie ever" },
				new Movie { MovieId = 2, Category = "Sci-Fi", Title = "Inception", Year = 2010, Director = "Christopher Nolan", Rating = "PG-13", Edited = false, LentTo = "", Notes = "Mind bending" },
				new Movie { MovieId = 3, Category = "Comedy", Title = "Nacho Libre", Year = 2006, Director = "Jared Hess", Rating = "PG", Edited = true, LentTo = "Brother", Notes = "Classic" }
			);
		}
	}
}