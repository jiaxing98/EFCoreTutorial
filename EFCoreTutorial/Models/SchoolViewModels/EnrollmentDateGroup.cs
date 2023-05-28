using System.ComponentModel.DataAnnotations;

namespace EFCoreTutorial.Models.SchoolViewModels
{
	public class EnrollmentDateGroup
	{
		[DataType(DataType.Date)]
		public DateTime? EnrollmentDate { get; set; }

		public int StudentCount { get; set; }
	}
}
