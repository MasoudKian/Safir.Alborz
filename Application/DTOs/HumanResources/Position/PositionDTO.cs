namespace Application.DTOs.HumanResources.Position
{
    public class PositionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
