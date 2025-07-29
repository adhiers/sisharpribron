using System;

namespace SampleASPMVC.Services;

public interface ICrud<T>
{
    T Create(T item);
    T Read(string id);
    T Update(T item);
    void Delete(string id);
    IEnumerable<T> GetAll();
}
