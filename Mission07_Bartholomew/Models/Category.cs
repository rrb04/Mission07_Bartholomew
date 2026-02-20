using System.ComponentModel.DataAnnotations;

namespace Mission07_Bartholomew.Models
{
	// New model for the Categories table in the database
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}