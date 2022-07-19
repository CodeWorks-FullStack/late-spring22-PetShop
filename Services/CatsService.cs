using System;
using System.Collections.Generic;
using PetShop.db;
using PetShop.Models;

namespace PetShop.Services
{
  public class CatsService
  {

    internal List<Cat> Get()
    {
      return FakeDb.Cats;
    }
    internal Cat Get(string id)
    {
      Cat found = FakeDb.Cats.Find(c => c.Id == id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;

    }
    internal Cat Create(Cat catData)
    {
      FakeDb.Cats.Add(catData);
      return catData;
    }
    internal Cat Update(Cat catData)
    {
      Cat original = Get(catData.Id);
      // Null coalescence
      original.Name = catData.Name ?? original.Name;
      // ... save

      return original;
    }
    internal Cat Delete(string id)
    {
      Cat found = Get(id);
      FakeDb.Cats.Remove(found);
      return found;
    }
  }
}