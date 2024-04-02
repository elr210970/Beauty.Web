using Beauty.Entity.Entities;
using Beauty.Repository.Contracts;
using Beauty.Shared.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Beauty.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _service;
        private readonly IRoleRepository _roleRepository;

        public UsersController(IUserRepository service, IRoleRepository roleRepository)
        {
            _service = service;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var results = await _service.GetUsersAsync();

                var resultsDto = results.Select(x => new UserDto()
                {

                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Telephone = x.Telephone,
                    Password = x.Password,
                    RoleId = x.RoleId,

                }).ToList();

                return Ok(resultsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{modelId:int}", Name = "GetUserById")]
        public async Task<IActionResult> GetUser(int modelId)
        {
            try
            {
                var result = await _service.GetUserAsync(modelId);

                if (result is not null)
                {
                    var resultDto = new UserDto()
                    {

                        Id = result.Id,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        Email = result.Email,
                        Telephone = result.Telephone,
                        Password = result.Password,
                        RoleId = result.RoleId,

                    };

                    return Ok(resultDto);
                }

                return NotFound("There is no data based on that id.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginDto login)
        {
            try
            {
                var userEntity = new User()
                {
                    Email = login.Email,
                    Password = login.Password,
                };

                var result = await _service.GetUserByCredentialAsync(userEntity);

                if (result is not null)
                {
                    var resultDto = new LogedInUserDto()
                    {

                        Id = result.Id,
                        Email = result.Email,
                        RoleId = result.RoleId,

                    };

                    return Ok(resultDto);
                }

                return NotFound("There is no data based on that id.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDto model)
        {
            try
            {
                if (model is not null)
                {
                    var entity = new User()
                    {
                        FirstName = model.FirstName,
                        LastName= model.LastName,
                        Email = model.Email,
                        Telephone = model.Telephone,
                        Password = model.Password,
                        RoleId = model.RoleId,
                    };

                    await _service.CreateUserAsync(entity);
                    await _service.SaveAsync();

                    var userRole = new UserRole()
                    {
                        UserId = entity.Id,
                        RoleId = entity.RoleId
                    };

                    await _roleRepository.CreateUserRoleAsync(userRole);
                    await _service.SaveAsync();

                    var userDto = new UserDto()
                    {
                        Id = entity.Id,
                        FirstName= entity.FirstName,
                        LastName= entity.LastName,
                        Email = entity.Email,
                        Telephone = entity.Telephone,
                        Password = entity.Password,
                        RoleId = entity.RoleId,
                    };

                    return StatusCode(201, userDto);
                }

                return BadRequest("The sent model is null.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{modelId:int}")]
        public async Task<IActionResult> UpdateUser(int modelId, [FromBody] UserEditionDto model)
        {
            try
            {
                var editingModel = await _service.GetUserAsync(modelId);

                if (editingModel is not null)
                {
                    editingModel.FirstName = model.FirstName;
                    editingModel.LastName = model.LastName;
                    editingModel.Email = model.Email;
                    editingModel.Telephone = model.Telephone;
                    editingModel.Password = model.Password;

                    await _service.SaveAsync();

                    return Ok("Edition done.");
                }

                return BadRequest("The sent model is null.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{modelId:int}")]
        public async Task<IActionResult> DeleteUser(int modelId)
        {
            try
            {
                var deletingModel = await _service.GetUserAsync(modelId);

                if (deletingModel is not null)
                {
                    _service.DeleteUser(deletingModel);
                    await _service.SaveAsync();

                    return Ok("Deletion done.");
                }

                return BadRequest("The sent model is null.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
