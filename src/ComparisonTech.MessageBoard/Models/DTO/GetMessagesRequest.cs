namespace ComparisonTech.MessageBoard.Models.DTO
{
    public class GetMessagesRequest
    {
        public int DaysInPast { get; set; } = 30;
        public int PageSize { get; set; } = 5;
        public int PageNumber { get; set; } = 1;
    }
}