namespace Domain.Entities.Site
{
    public class AboutUs : BaseEntity
    {
        public string TitleImage { get; set; } = string.Empty;
        public string SectionImage { get; set; } = string.Empty;
        public string SectionTitle { get; set; } = string.Empty;
        public string SectionDescription { get; set; } = string.Empty;
        public string SectionDeatil { get; set; } = string.Empty;
        public string? SectionVideo { get; set; }


        public string AboutUsDescription { get; set; } = string.Empty;

    }
}
