using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
    public class UserTypeManager : IUserTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserTypeManager(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserTypeDto>> AddAsync(UserTypeAddDto userTypeAddDto, int createdByUserId)
        {
            try
            {
                var userType = _mapper.Map<UserType>(userTypeAddDto);
                userType.CreatedByUserId = createdByUserId;
                userType.ModifiedByUserId = createdByUserId;

                var addedUserType = await _unitOfWork.UserTypes.AddAsync(userType);
                await _unitOfWork.SaveAsync();

                return new DataResult<UserTypeDto>(ResultStatus.Success, Messages.CommonMessage.Add(addedUserType.UserTypeName, "Kullanıcı Tipi"), _mapper.Map<UserTypeDto>(addedUserType));
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Add("Kullanıcı Tipi"), null, exMessage);
            }
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            try
            {
                var userTypeCount = await _unitOfWork.UserTypes.CountAsync();

                if (userTypeCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, userTypeCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.CommonMessage.Count("Kullanıcı Tipi"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Danger, Messages.ExceptionMessage.Count("Kullanıcı Tipi"), -1, exMessage);
            }
        }

        public async Task<IResult> DeleteAsync(int userTypeId, int modifiedByUserId)
        {
            try
            {
                var userType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeId);

                if (userType != null)
                {
                    if (userType.IsDeleted)
                        return new Result(ResultStatus.Info, Messages.CommonMessage.AlreadyDeleted(userType.UserTypeName, "Kullanıcı Tipi"));

                    userType.IsDeleted = true;
                    userType.ModifiedByUserId = modifiedByUserId;
                    userType.ModifiedDate = DateTime.Now;
                    await _unitOfWork.UserTypes.UpdateAsync(userType);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(userType.UserTypeName, false, "Kullanıcı Tipi"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.Delete("Kullanıcı Tipi"), exMessage);
            }
        }

        public async Task<IDataResult<UserTypeListDto>> GetAllAsync()
        {
            try
            {
                var userTypes = await _unitOfWork.UserTypes.GetAllAsync();

                if (userTypes.Count > -1)
                {
                    return new DataResult<UserTypeListDto>(ResultStatus.Success, new UserTypeListDto
                    {
                        UserTypes = _mapper.Map<IList<UserTypeDto>>(userTypes)
                    });
                }

                return new DataResult<UserTypeListDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(true, "Kullanıcı Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeListDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı Tipi"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserTypeDto>> GetAsync(int userTypeId)
        {
            try
            {
                var userType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeId);

                if (userType != null)
                    return new DataResult<UserTypeDto>(ResultStatus.Success, _mapper.Map<UserTypeDto>(userType));

                return new DataResult<UserTypeDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı Tipi"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserTypeUpdateDto>> GetUpdateDtoAsync(int userTypeId)
        {
            try
            {
                var userType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeId);

                if (userType != null)
                    return new DataResult<UserTypeUpdateDto>(ResultStatus.Success, _mapper.Map<UserTypeUpdateDto>(userType));
                return new DataResult<UserTypeUpdateDto>(ResultStatus.Success, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeUpdateDto>(ResultStatus.Danger, Messages.ExceptionMessage.Update("Kullanıcı Tipi"), null,
                    exMessage);
            }
        }

        public async Task<IResult> HardDeleteAsync(int userTypeId)
        {
            try
            {
                var userType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeId);

                if (userType != null)
                {
                    await _unitOfWork.UserTypes.DeleteAsync(userType);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(userType.UserTypeName, true, "Kullanıcı Tipi"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.HardDelete("Kullanıcı Tipi"), exMessage);
            }
        }

        public async Task<IDataResult<UserTypeDto>> UpdateAsync(UserTypeUpdateDto userTypeUpdateDto, int modifiedByUserId)
        {
            try
            {
                var oldUserType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeUpdateDto.Id);

                if (oldUserType != null)
                {
                    var userType = _mapper.Map<UserTypeUpdateDto, UserType>(userTypeUpdateDto, oldUserType);
                    userType.ModifiedByUserId = modifiedByUserId;
                    var updatedUserType = await _unitOfWork.UserTypes.UpdateAsync(userType);
                    await _unitOfWork.SaveAsync();
                    return new DataResult<UserTypeDto>(ResultStatus.Success, Messages.CommonMessage.Update(updatedUserType.UserTypeName, "Kullanıcı Tipi"), _mapper.Map<UserTypeDto>(updatedUserType));
                }

                return new DataResult<UserTypeDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı Tipi"), null, exMessage);
            }
        }
    }
}
