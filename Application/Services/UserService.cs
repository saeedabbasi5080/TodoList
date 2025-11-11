using Application.DTOs.ToDoDTOs;
using Application.DTOs.UserDTOs;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Name = u.Name,
                LastName = u.LastName,
                todoDtos = u.ToDos.Select(u => new TodoDto
                {
                    Id = u.Id,
                    Title = u.Title,
                    IsCompleted = u.IsCompleted
                }).ToList()
            }
            ).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetById(id);
            if (user is null)
            {
                throw new ArgumentNullException("User not found");
            }

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                todoDtos = user.ToDos.Select(u => new TodoDto
                {
                    Id = u.Id,
                    Title = u.Title,
                    IsCompleted = u.IsCompleted
                }).ToList(),
            };
        }

        public async Task<UserDto> CreateAsync(CreateUserDto user)
        {
            var newuser = new User
            {
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email
            };
            await _repository.AddAsync(newuser);
            //user.Id = newuser.Id;
            //return user;

            return new UserDto
            {
                Id = newuser.Id,
                Name = newuser.Name,
                LastName = newuser.LastName,
                UserName = newuser.UserName,
                Email = newuser.Email
            };
        }

        public async Task UpdateAsync(int id, CreateUserDto userdto)
        {
            var user = await _repository.GetById(id);

            if(user is null)
            {
                throw new ArgumentNullException("User not found");
            }

            user.UserName = userdto.UserName;
            user.Name = userdto.Name;
            user.LastName = userdto.LastName;
            user.Email = userdto.LastName;
            await _repository.UpdateAsync(user);

  
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
