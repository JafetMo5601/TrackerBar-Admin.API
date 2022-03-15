using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackerBar_Admin.API.DataModels;
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
        [Route("people")]
        public async Task<IActionResult> GetTotalSpacesUsedAsync(int restaurantId)
        {
            var qty = await tableRepository.GetPeopleInBarsync(restaurantId);
            return Ok(qty);
        }

        [HttpGet]
        [Route("spaces/availables")]
        public async Task<IActionResult> GetTotalSpacesAvailablesAsync(int restaurantId)
        {
            var qty = await tableRepository.GetSpacesAvailablesAsync(restaurantId);
            return Ok(qty);
        }

        [HttpGet]
        [Route("total/availables")]
        public async Task<IActionResult> GetTotalAvailablesAsync(int restaurantId)
        {
            var qty = await tableRepository.GetTablesAvailablesAsync(restaurantId);
            return Ok(qty);
        }

        [HttpGet]
        [Route("total")]
        public async Task<IActionResult> GetTotalTablesAsync(int restaurantId)
        {
            var qty = await tableRepository.GetTotalTablesCountAsync(restaurantId);
            return Ok(qty);
        }
    }
}
