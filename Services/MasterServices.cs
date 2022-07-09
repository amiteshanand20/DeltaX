using DeltaX.Entities;
using Deltax.Models;

namespace Deltax.Services;


public interface IMasterServices
{
    IEnumerable<IGrouping<string, MasterDTO>> GetMasterAsync();
}
public class MasterServices : IMasterServices
{
    private readonly DeltaXDBContext _context;
    public MasterServices(DeltaXDBContext context)
    {
        _context = context;
    }

    public IEnumerable<IGrouping<string, MasterDTO>> GetMasterAsync()
    {
        var masterData = _context.TblMasters.Select(x => new MasterDTO()
        {
            mId = x.MasterId,
            mName = x.MasterName,
            mType = x.MasterType
        }).ToList();

        return masterData.GroupBy(group => group.mType);
    }

}