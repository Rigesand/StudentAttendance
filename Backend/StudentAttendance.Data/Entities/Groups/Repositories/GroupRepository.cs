using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Core.Domains.Groups;
using StudentAttendance.Core.Domains.Groups.Repositories;

namespace StudentAttendance.Data.Entities.Groups.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly StudentAttendanceDbContext _context;
    private readonly IMapper _mapper;

    public GroupRepository(StudentAttendanceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task DeleteGroup(string groupNumber)
    {
        var dbGroup = await _context.Groups.FirstOrDefaultAsync(it => it.GroupNumber == groupNumber);
        _context.Groups.Remove(dbGroup);
    }

    public async Task<Guid> GetIdByGroupNumber(string groupNumber)
    {
        var dbGroup = await _context.Groups.FirstOrDefaultAsync(it => it.GroupNumber == groupNumber);
        return dbGroup!.Id;
    }

    public async Task<Group> GetByGroupNumber(string groupNumber)
    {
        var dbGroup = await _context.Groups.Include(it => it.Students)
            .FirstOrDefaultAsync(it => it.GroupNumber == groupNumber);
        return _mapper.Map<Group>(dbGroup);
    }

    public async Task<IEnumerable<Group>> GetAllGroups()
    {
        return await _mapper.ProjectTo<Group>(_context.Groups).ToListAsync();
    }

    public async Task CreateGroup(string groupNumber)
    {
        var isExist = await _context.Groups.AnyAsync(it => it.GroupNumber == groupNumber);
        if (isExist)
        {
            throw new Exception("Группа с таким номером уже существует");
        }

        await _context.Groups.AddAsync(new GroupDb()
        {
            GroupNumber = groupNumber
        });
    }
    
}