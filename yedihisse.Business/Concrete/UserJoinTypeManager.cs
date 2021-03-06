using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities;
using yedihisse.Business.Utilities.Security.Token.Abstract;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;
using yedihisse.Shared.Utilities.Results.Complex_Type;
using yedihisse.Shared.Utilities.Results.Concrete;

namespace yedihisse.Business.Concrete
{
    public class UserJoinTypeManager : IUserJoinTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserJoinTypeManager(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<IDataResult<UserJoinTypeDto>> GetAsync(int userJoinTypeId)
        {
            try
            {
                var userJoinType = await _unitOfWork.UserJoinTypes.GetAsync(u => u.Id == userJoinTypeId, u => u
                    .Include(u => u.UserType)
                    .Include(u => u.User));

                if (userJoinType != null)
                    return new DataResult<UserJoinTypeDto>(ResultStatus.Success, _mapper.Map<UserJoinTypeDto>(userJoinType));

                return new DataResult<UserJoinTypeDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi Tanımlama"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserJoinTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı Tipi Tanımlama"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserJoinTypeListDto>> GetAllAsync()
        {
            try
            {
                var userJoinTypes = await _unitOfWork.UserJoinTypes.GetAllAsync(null, u => u
                    .Include(u => u.UserType)
                    .Include(u => u.User));

                if (userJoinTypes.Count > -1)
                {
                    return new DataResult<UserJoinTypeListDto>(ResultStatus.Success, new UserJoinTypeListDto
                    {
                        UserJoinTypes = _mapper.Map<IList<UserJoinTypeDto>>(userJoinTypes)
                    });
                }

                return new DataResult<UserJoinTypeListDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(true, "Kullanıcı Tipi Tanımlama"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserJoinTypeListDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı Tipi Tanımlama"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserJoinTypeDto>> AddAsync(UserJoinTypeAddDto userJoinTypeAddDto, int createdByUserId)
        {
            try
            {
                var checkValue = await _unitOfWork.UserJoinTypes.AnyAsync(u => u.UserId == userJoinTypeAddDto.UserId & u.UserTypeId == userJoinTypeAddDto.UserTypeId);

                if (checkValue)
                    return new DataResult<UserJoinTypeDto>(ResultStatus.Danger, Messages.CommonMessage.AlreadyExists(" Kullanıcı Tipi tanımlama"), null);

                var userJoinType = _mapper.Map<UserJoinType>(userJoinTypeAddDto);
                userJoinType.CreatedByUserId = createdByUserId;
                userJoinType.ModifiedByUserId = createdByUserId;
                var addedUserJoinType = await _unitOfWork.UserJoinTypes.AddAsync(userJoinType);
                await _unitOfWork.SaveAsync();
                var addedUserOfType = await _unitOfWork.Users.GetAsync(u => u.Id == userJoinType.UserId);
                var addedTypeOfUser = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userJoinType.UserTypeId);

                var token = _tokenService.GenerateToken(new UserLoggedinDto
                {
                    Id = addedUserOfType.Id,
                    UserPhoneNumber = addedUserOfType.UserPhoneNumber,
                    EmailAddress = addedUserOfType.EmailAddress,
                    FirstName = addedUserOfType.FirstName,
                    LastName = addedUserOfType.LastName,
                    UserJoinTypes = addedUserOfType.UserJoinTypes
                });

                return new DataResult<UserJoinTypeDto>(ResultStatus.Success, Messages.CommonMessage.Add(addedUserOfType.FirstName + " " + addedUserOfType.LastName + " kullanıcısına " + addedTypeOfUser.UserTypeName + " tipi tanımlanmıştır.", "Kullanıcı Tipi Tanımlama"), _mapper.Map<UserJoinTypeDto>(addedUserJoinType));
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserJoinTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Add("Kullanıcı Tipi Tanımlama"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserJoinTypeUpdateDto>> GetDetailAsync(int userJoinTypeId)
        {
            try
            {
                var userJoinType = await _unitOfWork.UserJoinTypes.GetAsync(u => u.Id == userJoinTypeId);

                if (userJoinType != null)
                    return new DataResult<UserJoinTypeUpdateDto>(ResultStatus.Success, _mapper.Map<UserJoinTypeUpdateDto>(userJoinType));
                return new DataResult<UserJoinTypeUpdateDto>(ResultStatus.Success, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi Belirleme"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserJoinTypeUpdateDto>(ResultStatus.Danger, Messages.ExceptionMessage.Update("Kullanıcı Tipi Belirleme"), null,
                    exMessage);
            }
        }

        public async Task<IDataResult<UserJoinTypeDto>> UpdateAsync(UserJoinTypeUpdateDto userJoinTypeUpdateDto, int modifiedByUserId)
        {
            try
            {
                var oldUserJoinType = await _unitOfWork.UserJoinTypes.GetAsync(u => u.Id == userJoinTypeUpdateDto.Id);

                if (oldUserJoinType != null)
                {
                    var userJoinType = _mapper.Map<UserJoinTypeUpdateDto, UserJoinType>(userJoinTypeUpdateDto, oldUserJoinType);
                    userJoinType.ModifiedByUserId = modifiedByUserId;
                    var updatedUserJoinType = await _unitOfWork.UserJoinTypes.UpdateAsync(userJoinType);
                    await _unitOfWork.SaveAsync();

                    var updatedUserOfType = await _unitOfWork.Users.GetAsync(u => u.Id == updatedUserJoinType.UserId);
                    var updatedTypeOfUser = await _unitOfWork.UserTypes.GetAsync(u => u.Id == updatedUserJoinType.UserTypeId);

                    return new DataResult<UserJoinTypeDto>(ResultStatus.Success, Messages.CommonMessage.Update(updatedUserOfType.FirstName + " " + updatedUserOfType.LastName + " kullanıcısına " + updatedTypeOfUser.UserTypeName + " tipi tanımlanmıştır.", "Kullanıcı Tipi Birleştirme"), _mapper.Map<UserJoinTypeDto>(updatedUserJoinType));
                }

                return new DataResult<UserJoinTypeDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi Birleştirme"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserJoinTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı Tipi Birleştirme"), null, exMessage);
            }
        }

        public async Task<IResult> DeleteAsync(int userJoinTypeId, int modifiedByUserId)
        {
            try
            {
                var userJoinType = await _unitOfWork.UserJoinTypes.GetAsync(u => u.Id == userJoinTypeId);

                if (userJoinType != null)
                {
                    var deletedUserOfType = await _unitOfWork.Users.GetAsync(u => u.Id == userJoinType.UserId);
                    var deletedTypeOfUser = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userJoinType.UserTypeId);

                    if (userJoinType.IsDeleted)
                        return new Result(ResultStatus.Info, Messages.CommonMessage.AlreadyDeleted(deletedUserOfType.FirstName + " " + deletedUserOfType.LastName + " kullanıcısından" + deletedTypeOfUser.UserTypeName + " tipi daha önce silinmiştir.", "Kullanıcı Tipi Belirleme"));

                    userJoinType.IsDeleted = true;
                    userJoinType.ModifiedByUserId = modifiedByUserId;
                    userJoinType.ModifiedDate = DateTime.Now;
                    await _unitOfWork.UserJoinTypes.UpdateAsync(userJoinType);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.UserJoinTypeMessage.Delete(deletedUserOfType.FirstName + " " + deletedUserOfType.LastName, deletedTypeOfUser.UserTypeName));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi Belirleme"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.Delete("Kullanıcı Tipi Belirleme"), exMessage);
            }
        }

        public async Task<IResult> HardDeleteAsync(int userJoinTypeId)
        {
            try
            {
                var userJoinType = await _unitOfWork.UserJoinTypes.GetAsync(u => u.Id == userJoinTypeId);

                if (userJoinType != null)
                {
                    var hardDeletedUserOfType = await _unitOfWork.Users.GetAsync(u => u.Id == userJoinType.UserId);
                    var hardDeletedTypeOfUser = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userJoinType.UserTypeId);

                    await _unitOfWork.UserJoinTypes.DeleteAsync(userJoinType);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.UserJoinTypeMessage.HardDelete(hardDeletedUserOfType.FirstName + " " + hardDeletedUserOfType.LastName, hardDeletedTypeOfUser.UserTypeName));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi Birleştirme"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.HardDelete("Kullanıcı Tipi Birleştirme"), exMessage);
            }
        }
    }
}
