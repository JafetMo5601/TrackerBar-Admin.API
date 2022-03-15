using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackerBar_Admin.API.Repositories;

namespace TrackerBar_Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository tableRepository;

        public TableController(ITableRepository tableRepository)
        { 
            this.tableRepository = tableRepository;
        }

        [HttpGet]
        [Route("total")]
        public async Task<IActionResult> GetTotalTables()
        {
            var qty = await tableRepository.GetTotalTablesAsync();
            return Ok(qty);
        }
    }
}
