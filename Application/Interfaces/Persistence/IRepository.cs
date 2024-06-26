﻿namespace Application.Interfaces.Persistence;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    T Get(Guid id);
    void Add(T entity);
}