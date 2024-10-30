namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
{
    void Add(T entity);

    T? FindById(Guid id);
}