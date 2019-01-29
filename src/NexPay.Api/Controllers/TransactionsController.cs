using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NexPay.Api.ViewModels;
using NexPay.Domain.Entities;
using NexPay.Domain.Repositories;

namespace NexPay.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsController(ITransactionRepository transactionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All transactions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<TransactionVM>>(transactions));
        }

        /// <summary>
        /// Get transaction by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if(transaction == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<TransactionVM>(transaction));
        }

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionVM transaction)
        {
            if(ModelState.IsValid) {
                var transactionEntity = _mapper.Map<Transaction>(transaction);
                _transactionRepository.Save(transactionEntity);
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(Post), _mapper.Map<TransactionVM>(transactionEntity));
            }
            else {
                return BadRequest(ModelState);
            }
      
        }
    }
}
