using NexaWorks.Models;

namespace NexaWorks.Repository
{
    public interface IRequetes
    {
        Task<List<Ticket>> GetAllTicketsNotResolved();
        Task<List<Ticket>> GetAllTicketsNotResolvedOfThisProductID(int productId);
        Task<List<Ticket>> GetAllTicketsNotResolvedOfThisVersionID(int versionId);
        Task<List<Ticket>> GetAllTicketsOfThisProductIDInThisTimeLap(int productId, DateOnly dateStart, DateOnly dateEnd);
        Task<List<Ticket>> GetAllTicketsOfThisVersionIDInThisTimeLap(int versionId, DateOnly dateStart, DateOnly dateEnd);
        Task<List<Ticket>> GetAllTicketsNotResolvedWithTheseWords(List<string> allWords);
        Task<List<Ticket>> GetAllTicketsNotResolvedOfThisProductIDWithTheseWords(int productId, List<string> allWords);
        Task<List<Ticket>> GetAllTicketsNotResolvedOfThisVersionIDWithTheseWords(int versionId, List<string> allWords);
        Task<List<Ticket>> GetAllTicketsOfThisProductIDWithTheseWordsInThisTimeLap(int productId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd);
        Task<List<Ticket>> GetAllTicketsOfThisVersionIDWithTheseWordsInThisTimeLap(int versionId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd);


        Task<List<Ticket>> GetAllTicketsSolved();
        Task<List<Ticket>> GetAllTicketsSolvedOfThisProductID(int productId);
        Task<List<Ticket>> GetAllTicketsSolvedOfThisVersionID(int versionId);
        Task<List<Ticket>> GetAllTicketsOfThisProductIDSolvedInThisTimeLap(int productId, DateOnly dateStart, DateOnly dateEnd);
        Task<List<Ticket>> GetAllTicketsOfThisVersionIDSolvedInThisTimeLap(int versionId, DateOnly dateStart, DateOnly dateEnd);
        Task<List<Ticket>> GetAllTicketsSolvedWithTheseWords(List<string> allWords);
        Task<List<Ticket>> GetAllTicketsSolvedOfThisProductIDWithTheseWords(int productId, List<string> allWords);
        Task<List<Ticket>> GetAllTicketsSolvedOfThisVersionIDWithTheseWords(int versionId, List<string> allWords);
        Task<List<Ticket>> GetAllTicketsOfThisProductIDWithTheseWordsSolvedInThisTimeLap(int productId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd);
        Task<List<Ticket>> GetAllTicketsOfThisVersionIDWithTheseWordsSolvedInThisTimeLap(int versionId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd);

    }
}
