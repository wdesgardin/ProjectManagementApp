using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Controllers.Resources;
using ProjectManagementApp.Core;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardsController(IUnitOfWork unitOfWork, IBoardRepository boardRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost, ValidateModelState]
        public async Task<IActionResult> CreateBoard([FromBody] CreateBoardResource createBoard)
        {
            var board = _mapper.Map<Board>(createBoard);
            _boardRepository.Add(board);
            await _unitOfWork.CompleteAsync();
            var resource = _mapper.Map<BoardResource>(board);

            return Ok(resource);
        }

        public async Task<IActionResult> GetBoards()
        {
            var boards = await _boardRepository.GetBoards();
            var resources = _mapper.Map<IEnumerable<Board>, IEnumerable<BoardResource>>(boards);

            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(int id)
        {
            var board = await _boardRepository.GetById(id);

            if (board == null)
            {
                return NotFound();
            }

            var resource = _mapper.Map<BoardResource>(board);
            return Ok(resource);
        }
    }
}