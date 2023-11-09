
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class MatchRepository
{
    private readonly StudentHiveDbContext _context;

    public MatchRepository ( StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Match>> GetAll()
    {
        var match = await _context.Matchs.ToListAsync();

        return match;
    }

    public async Task<Match> GetById (int id)
    {
        var match = await _context.Matchs.FirstOrDefaultAsync(match => match.IdMatch == id);
        return match ?? new Match();
    }
        public async Task Add (Match match)
    {
        await _context.AddAsync(match);
        await _context.SaveChangesAsync();
    }

}