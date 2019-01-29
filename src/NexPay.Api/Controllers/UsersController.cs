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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserVM>>(users));
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<UserVM>(user));
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserVM user)
        {
            if(ModelState.IsValid) {
                var userEntity = _mapper.Map<User>(user);
                _userRepository.Save(userEntity);
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(Post), _mapper.Map<UserVM>(userEntity));
            }
            else {
                return BadRequest(ModelState);
            }
      
        }

        /// <summary>
        /// Edit user
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserVM user)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userRepository.GetByIdAsync(id);

                if (currentUser == null)
                {
                    return NotFound();
                }

                _mapper.Map(user, currentUser);
                await _unitOfWork.CommitAsync();
                return Ok(_mapper.Map<UserVM>(currentUser));
            }
            else {
                return BadRequest(ModelState);
            }
        }

    }
}
