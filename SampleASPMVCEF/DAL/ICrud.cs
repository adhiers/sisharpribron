using System;

namespace SampleASPMVCEF.DAL;

public interface ICrud<T>
{
    T Create(T item);
    T GetById(string id);
    T Update(T item);
    void Delete(string id);
    IEnumerable<T> GetAll();
}
