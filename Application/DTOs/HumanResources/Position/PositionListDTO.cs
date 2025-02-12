using Application.Utils;

namespace Application.DTOs.HumanResources.Position
{
    public class PositionListDTO
    {
        public int PositionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedDateShamsi => CreatedDate.ToShamsi(true);
    }
}
