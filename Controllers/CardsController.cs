using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Controllers.Resources;
using ProjectManagementApp.Core;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardsController(ICardRepository cardRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("api/boards/columns/{columnId}/cards"), ValidateModelState]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardResource card, int columnId)
        {
            var newCard = _mapper.Map<Card>(card);
            newCard.ColumnId = columnId;

            _cardRepository.Add(newCard);
            await _unitOfWork.CompleteAsync();
            
            var resource = _mapper.Map<CardResource>(newCard);

            return Ok(resource);
        }

        [HttpGet("api/boards/columns/{columnId}/cards")]
        public async Task<IActionResult> GetCards(int columnId) {
            var cards = await _cardRepository.GetCardsByColumnId(columnId);
            var resources = _mapper.Map<IEnumerable<Card>,IEnumerable<CardResource>>(cards);
            
            return Ok(resources);
        }
    }
}