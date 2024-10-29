using Itmo.ObjectOrientedProgramming.Lab2.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
{
    void Add(T entity);

    SearchResult GetById(Guid id);
}