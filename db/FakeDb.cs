using System.Collections.Generic;
using PetShop.Models;

namespace PetShop.db
{
  public static class FakeDb
  {
    public static List<Cat> Cats { get; set; } = new List<Cat>(){
            new Cat("Oscar"),
            new Cat("Snuffles"),
            new Cat("Mr Snibbley")
        };


  }
}