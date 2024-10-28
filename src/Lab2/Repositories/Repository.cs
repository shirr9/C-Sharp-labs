using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class Repository<T> : IRepository<T> where T : IEntity
{
    private readonly Dictionary<Guid, T> _entities = new Dictionary<Guid, T>();

    public void Add(T entity)
    {
        if (_entities.ContainsKey(entity.Id))
        {
            throw new ArgumentException($"Entity with id {entity.Id} already exists.");
        }

        _entities.Add(entity.Id, entity);
    }

    public T FindById(Guid id)
    {
        if (_entities.TryGetValue(id, out T? entity))
        {
            return entity;
        }

        throw new KeyNotFoundException("Entity with the specified ID not found.");
    }
}