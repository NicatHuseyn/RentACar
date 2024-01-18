using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        
        private readonly GetLast5CarWithBrandQueryHandler _getLast5CarWithBrandQueryHandler;

		public CarsController(CreateCarCommandHandler createCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler)
		{
			_createCommandHandler = createCommandHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
			_getLast5CarWithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
		}

		[HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommnad command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("Added Car info");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Removed Car info");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Updated Car info");
        }

        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var value =  _getCarWithBrandQueryHandler.Handle();
            return Ok(value);
        }

		[HttpGet("GetLast5CarsWithBrandQueryHandler")]
		public IActionResult GetLast5CarsWithBrandQueryHandler()
		{
			var values = _getLast5CarWithBrandQueryHandler.Handle();
			return Ok(values);
		}


	}
}
