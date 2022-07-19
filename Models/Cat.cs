using System;

namespace PetShop.Models
{
  public class Cat
  {
    public Cat(string name)
    {
      Id = Guid.NewGuid().ToString(); // generates unique id (TEMPORARY DONT STRESS)
      Name = name;
    }

    public string Id { get; set; }
    public string Name { get; set; }
  }
}