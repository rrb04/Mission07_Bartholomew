using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission07_Bartholomew.Models
{
	public class Movie
	{
		[Key]
		public int MovieId { get; set; }

		// Setting up the Foreign Key relationship to the new Category model
		[Required(ErrorMessage = "Category is required")]
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public Category? Category { get; set; }

		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Year is required")]
		[Range(1888, 2050, ErrorMessage = "Year must be 1888 or later.")]
		public int Year { get; set; }

		public string? Director { get; set; }

		public string? Rating { get; set; }

		[Required(ErrorMessage = "Edited status is required")]
		public bool Edited { get; set; }

		public string? LentTo { get; set; }

		// New field required by the updated database schema
		[Required(ErrorMessage = "Copied to Plex status is required")]
		public bool CopiedToPlex { get; set; }

		[MaxLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
		public string? Notes { get; set; }
	}
}