using API.To.MongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.To.MongoDB.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;

        IMongoCollection<Infected> _infectedsColletions;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedsColletions = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SaveInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.BirthDate, dto.Gender, dto.Latitude, dto.Longitude);
            
            _infectedsColletions.InsertOne(infected);

            return StatusCode(201, "Infected successfully registered ");
        }

        [HttpGet]
        public  ActionResult GetInfecteds()
        {
            var infecteds = _infectedsColletions.Find(Builders<Infected>.Filter.Empty).ToList();
            return Ok(infecteds);
        }

        [HttpPut]
        public ActionResult UpdateInfected([FromBody] InfectedDto dto)
        {
            _infectedsColletions.UpdateOne(Builders<Infected>.Filter.Where(_ => _.BirthDate == dto.BirthDate), Builders<Infected>.Update.Set("gender", dto.Gender));
            var infecteds = _infectedsColletions.Find(Builders<Infected>.Filter.Empty).ToList();
            return Ok("Sucessful updated.");
        }

        [HttpDelete("{birthDate}")]
        public ActionResult DeleteInfected(DateTime birthDate)
        {
            _infectedsColletions.DeleteOne(Builders<Infected>.Filter.Where(_ => _.BirthDate == birthDate));

            return Ok("Sucessful deleted.");
        }
    }
}
