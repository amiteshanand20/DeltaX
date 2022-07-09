using AutoMapper;
using DeltaX.Entities;
using Deltax.Models;

namespace Deltax.Services;


public interface IProducerServices
{
    ResponseStatus<IEnumerable<ProducerDTO>> GetProducersListAsync();
    ResponseStatus<ProducerDTO> AddProducer(ProducerDTO producerDTO);
}
public class ProducerServices : IProducerServices
{
    private readonly DeltaXDBContext _context;
    private readonly IMapper _mapper;

    public ProducerServices(DeltaXDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ResponseStatus<IEnumerable<ProducerDTO>> GetProducersListAsync()
    {
        try
        {
            var actorsData = _mapper.Map<IEnumerable<ProducerDTO>>(_context.TblProducers);
            return new ResponseStatus<IEnumerable<ProducerDTO>>()
            {
                Data = actorsData,
                Status = BussinessStatus.Ok,
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<IEnumerable<ProducerDTO>>()
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not fetch the producers data"
            };
        }

    }

    public ResponseStatus<ProducerDTO> AddProducer(ProducerDTO producerDTO)
    {
        try
        {
            var producerData = _mapper.Map<TblProducer>(producerDTO);
            _context.TblProducers.Add(producerData);

            _context.SaveChangesAsync();
            return new ResponseStatus<ProducerDTO>()
            {
                Status = BussinessStatus.Created,
                ResponseMessage = "Producer added succesfully!"
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<ProducerDTO>()
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not add the producer data,Please try again!!"
            };
        }
    }

}