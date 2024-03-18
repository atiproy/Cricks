namespace Model.Dto
{
    public class ScoringDto
    {
        public int StrikerBatsmanId { get; set; }
        public int NonStrikerBatsmanId { get; set; }
        public int Runs { get; set; }
        public bool IsBye { get; set; }
        public bool IsLegBye { get; set; }
        public bool IsWide { get; set; }
        public bool IsNoBall { get; set; }
        public int BowlerId { get; set; }
        public int InningsId { get; set; }
        public int? FielderId { get; set; }
        public int? SecondFielderId { get; set; }
        public int? ExtraTypeId { get; set; }
        public bool IsWicket { get; set; }
        public bool IsRetiredHurt { get; set; }
    }
}
