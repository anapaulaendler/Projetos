using EventPlanner.Context;
using EventPlanner.Models;
using EventPlanner.Repositories;

namespace EventPlanner.Services;

public class OrganizerService : IOrganizerService
{
    private readonly IOrganizerRepository _organizerRepository;
    private readonly IUnitOfWork _uow;

    public OrganizerService(IOrganizerRepository organizerRepository, IUnitOfWork uow)
    {
        _organizerRepository = organizerRepository;
        _uow = uow;
    }

    public async Task CreateOrganizer(Organizer organizer)
    {
        await _uow.BeginTransactionAsync();
        await _organizerRepository.AddAsync(organizer);
        await _uow.CommitTransactionAsync();
    }

    public async Task DeleteOrganizer(Guid id)
    {
        await _uow.BeginTransactionAsync();
        var organizer = await GetOrganizerById(id);
        await _organizerRepository.Delete(organizer);

        await _uow.CommitTransactionAsync();
    }

    public Task<List<Organizer>> GetAllOrganizers()
    {
        var organizers = _organizerRepository.Get();
        return organizers;
    }

    public Task<Organizer> GetOrganizerById(Guid id)
    {
        var organizer = _organizerRepository.GetById(id);
        return organizer;
    }

    public async Task<Organizer> UpdateOrganizer(Guid id, Organizer updatedOrganizer)
    {
        await _uow.BeginTransactionAsync();
        var organizer = await GetOrganizerById(id);

        organizer.Name = updatedOrganizer.Name;
        organizer.Email = updatedOrganizer.Email;
        organizer.PhoneNumber = updatedOrganizer.PhoneNumber;

        await _organizerRepository.Update(organizer);
        await _uow.CommitTransactionAsync();

        return organizer;
    }
}