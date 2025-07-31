using System;
using System.Collections.Generic;
using sisharpriborn.BO;

namespace sisharpriborn.DAL;

public class DealerDAL : IDealer
{
    private readonly FinalProjectContext _context;

    public DealerDAL(FinalProjectContext context)
    {
        _context = context;
    }

    
    public Dealer Create(Dealer entity)
    {
        _context.Dealers.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    // Other CRUD methods would go here...

    public Dealer GetById(string id)
    {
        var result = _context.Dealers.Find(id);
        if (result == null)
        {
            throw new Exception("Dealer not found");
        }
        return result;
    }

    public Dealer Update(Dealer entity)
    {
        _context.Dealers.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public void Delete(string id)
    {
        var entity = _context.Dealers.Find(id);
        if (entity != null)
        {
            _context.Dealers.Remove(entity);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Dealer> GetAll()
    {
        var results = _context.Dealers.OrderBy(d => d.DealerId).ToList();
        return results;
    }

}
