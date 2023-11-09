
using StudentHive.Infrastructure.Repositories;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Features.Matchs;

public class MatchService
{
    private readonly MatchRepository _matchRepository;

    public MatchService ( MatchRepository matchRepository)
    {
        this._matchRepository = matchRepository;
    }

    public async Task<IEnumerable<Match>> GetAll()
    {
        return await _matchRepository.GetAll();
    }

    public async Task<Match> GetById (int id )
    {
        return await _matchRepository.GetById(id);
    }
        public async Task Add(Match match)
    {
        await  _matchRepository.Add(match);
    }

}