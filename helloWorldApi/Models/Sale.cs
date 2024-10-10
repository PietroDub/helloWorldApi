namespace helloWorldApi.Models
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string Order { get; set; }
        public double? SalePrice { get; set; }

        public Guid? AppUserId { get; set; }
        public Appuser? AppUser { get; set; }

        public Guid? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
