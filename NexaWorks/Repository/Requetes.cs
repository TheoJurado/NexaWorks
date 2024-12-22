using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexaWorks.Data;
using NexaWorks.Models;
using System.Collections;

namespace NexaWorks.Repository
{
    public class Requetes : IRequetes
    {
        private readonly AppDbContext _context;

        public Requetes(AppDbContext context)
        {
            _context = context;
        }

        private IQueryable<Ticket> SelectAllFromAllWhereAllIncludeAll()
        {
            return _context.Tickets
                .Include(t => t.AssociatedVersionOSKey)
                    .ThenInclude(vos => vos.VersionKey)
                        .ThenInclude(v => v.ProductKey)
                .Include(t => t.AssociatedVersionOSKey.OSKey);
        }

        #region first half > pré-solve
        public async Task<List<Ticket>> GetAllTicketsNotResolved()
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == false)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsNotResolvedOfThisProductID(int productId)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == false && t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsNotResolvedOfThisVersionID(int versionId)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == false
                    && t.AssociatedVersionOSKey.VersionKeyId == versionId)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisProductIDInThisTimeLap(int productId, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId
                    && t.DateCreat >= dateStart
                    && t.DateCreat <= dateEnd)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisVersionIDInThisTimeLap(int versionId, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.AssociatedVersionOSKey.VersionKeyId == versionId
                    && t.DateCreat >= dateStart
                    && t.DateCreat <= dateEnd)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsNotResolvedWithTheseWords(List<string> allWords)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == false
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word)))
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsNotResolvedOfThisProductIDWithTheseWords(int productId, List<string> allWords)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == false
                    && t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word)))
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsNotResolvedOfThisVersionIDWithTheseWords(int versionId, List<string> allWords)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == false
                    && t.AssociatedVersionOSKey.VersionKeyId == versionId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word)))
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisProductIDWithTheseWordsInThisTimeLap(int productId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word))
                    && t.DateCreat >= dateStart
                    && t.DateCreat <= dateEnd)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisVersionIDWithTheseWordsInThisTimeLap(int versionId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.AssociatedVersionOSKey.VersionKeyId == versionId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word))
                    && t.DateCreat >= dateStart
                    && t.DateCreat <= dateEnd)
                .ToListAsync();
        }
        #endregion

        #region solved
        public async Task<List<Ticket>> GetAllTicketsSolved()
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsSolvedOfThisProductID(int productId)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true && t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsSolvedOfThisVersionID(int versionId)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.AssociatedVersionOSKey.VersionKeyId == versionId)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisProductIDSolvedInThisTimeLap(int productId, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId
                    && t.DateResolve >= dateStart
                    && t.DateResolve <= dateEnd)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisVersionIDSolvedInThisTimeLap(int versionId, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.AssociatedVersionOSKey.VersionKeyId == versionId
                    && t.DateResolve >= dateStart
                    && t.DateResolve <= dateEnd)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsSolvedWithTheseWords(List<string> allWords)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word)))
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsSolvedOfThisProductIDWithTheseWords(int productId, List<string> allWords)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word)))
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsSolvedOfThisVersionIDWithTheseWords(int versionId, List<string> allWords)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.AssociatedVersionOSKey.VersionKeyId == versionId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word)))
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisProductIDWithTheseWordsSolvedInThisTimeLap(int productId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.AssociatedVersionOSKey.VersionKey.ProductKeyId == productId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word))
                    && t.DateResolve >= dateStart
                    && t.DateResolve <= dateEnd)
                .ToListAsync();
        }
        public async Task<List<Ticket>> GetAllTicketsOfThisVersionIDWithTheseWordsSolvedInThisTimeLap(int versionId, List<string> allWords, DateOnly dateStart, DateOnly dateEnd)
        {
            return await SelectAllFromAllWhereAllIncludeAll()
                .Where(t => t.IsResolved == true
                    && t.AssociatedVersionOSKey.VersionKeyId == versionId
                    && t.Description != null
                    && allWords.All(word => t.Description.Contains(word))
                    && t.DateCreat >= dateStart
                    && t.DateCreat <= dateEnd)
                .ToListAsync();
        }
        #endregion
    }
}
