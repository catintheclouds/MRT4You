﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SA51ADWebApp1.Models;
using SA51ADWebApp1.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA51ADWebApp1.Controllers
{
    [Route("api/StationOnLines")]
    [ApiController]
    public class StationOnLinesController : ControllerBase
    {
        private const string V = "From API";
        private readonly Database context;

        public StationOnLinesController(Database context)
        {
            this.context = context;
        }

        // GET: api/StationOnLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationOnLine>>> GetTodoItems()
        {
            return await context.StationOnLines.ToListAsync();
        }

        // GET: api/StationOnLines
        [Route("/api/string")]
        [HttpGet]
        public async Task<ActionResult<string>> GetString()
        {
            return V;
        }
    }
}
