
namespace FM_Rozetka_Api.Core.DTOs.Specifications.Specification
{
    public class SpecificationUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategorySpecificationId { get; set; }
        public int ProductId { get; set; }
    }
}
