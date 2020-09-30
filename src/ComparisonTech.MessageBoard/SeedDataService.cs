using ComparisonTech.MessageBoard.Models;

namespace ComparisonTech.MessageBoard
{
    public class SeedDataService
    {
        private readonly MessageBoardContext _context;

        public SeedDataService(MessageBoardContext context)
        {
            _context = context;
        }
        
        
    }
}