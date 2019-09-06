using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Controllers.Resources;
using ProjectManagementApp.Core;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Controllers
{
    public class ColumnsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IColumnRepository _columnRepository;
        private readonly IMapper _mapper;
        public ColumnsController(IUnitOfWork unitOfWork, IColumnRepository columnRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _columnRepository = columnRepository;
            _mapper = mapper;

        }

        [HttpGet("api/boards/{boardId}/columns")]
        public async Task<IActionResult> GetColumns(int boardId)
        {
            var columns = await _columnRepository.GetByBoardId(boardId);
            var resources = _mapper.Map<IEnumerable<Column>, IEnumerable<ColumnResource>>(columns);

            return Ok(resources);
        }

        [HttpPost("api/boards/{boardId}/columns"), ValidateModelState]
        public async Task<IActionResult> CreateColumn([FromBody] CreateColumnResource column, int boardId)
        {
            var newColumn = _mapper.Map<Column>(column);
            newColumn.BoardId = boardId;

            _columnRepository.Add(newColumn);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<ColumnResource>(newColumn);

            return Ok(resource);
        }

    }
}