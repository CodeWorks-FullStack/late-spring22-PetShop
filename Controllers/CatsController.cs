using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
  // NOTE this tells dotnet that this is a controller to register
  [ApiController]
  [Route("api/[controller]")] // node => super('api/cats')
  public class CatsController : ControllerBase
  {
    private readonly CatsService _cs;

    public CatsController(CatsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Cat>> Get()
    {
      try
      {
        List<Cat> cats = _cs.Get();
        return Ok(cats);
      }
      catch (Exception e)
      {
        // NODE: next(e.message)
        return BadRequest(e.Message);
      }
    }

    // GetById
    [HttpGet("{id}")] // NODE => ("/:id", ...)
    public ActionResult<Cat> Get(string id) // method overloading
    {
      try
      {
        Cat cat = _cs.Get(id);
        return Ok(cat);
      }
      catch (Exception e)
      {
        // NODE: next(e.message)
        return BadRequest(e.Message);
      }
    }

    // Create
    [HttpPost]
    public ActionResult<Cat> Create([FromBody] Cat catData) // req.body
    {
      try
      {
        Cat newCat = _cs.Create(catData);
        return Ok(catData);
      }
      catch (Exception e)
      {
        // NODE: next(e.message)
        return BadRequest(e.Message);
      }
    }

    // Edit
    [HttpPut("{id}")]
    public ActionResult<Cat> Edit(string id, [FromBody] Cat catData)
    {
      try
      {
        catData.Id = id;
        Cat update = _cs.Update(catData);
        return Ok(update);
      }
      catch (Exception e)
      {
        // NODE: next(e.message)
        return BadRequest(e.Message);
      }
    }

    // Delete
    [HttpDelete("{id}")]
    public ActionResult<Cat> Delete(string id)
    {
      try
      {
        Cat deletedCat = _cs.Delete(id);
        return Ok(deletedCat);
      }
      catch (Exception e)
      {
        // NODE: next(e.message)
        return BadRequest(e.Message);
      }
    }

  }
}