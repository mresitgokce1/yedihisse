using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities;
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

        public UserTypeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<UserTypeDto>> GetAsync(int userTypeId)
        {
            try
            {
                var userType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeId);

                if (userType != null)
                    return new DataResult<UserTypeDto>(ResultStatus.Success, _mapper.Map<UserTypeDto>(userType));

                return new DataResult<UserTypeDto>(ResultStatus.Error, Messages.UserType.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("UserType"), null, exMessage);
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

                return new DataResult<UserTypeListDto>(ResultStatus.Error, Messages.UserType.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeListDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("UserType"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserTypeListDto>> GetAllByNonDeletedAsync()
        {
            try
            {
                var userTypes = await _unitOfWork.UserTypes.GetAllAsync(u => u.IsDeleted == false);

                if (userTypes.Count > -1)
                {
                    return new DataResult<UserTypeListDto>(ResultStatus.Success, new UserTypeListDto
                    {
                        UserTypes = _mapper.Map<IList<UserTypeDto>>(userTypes)
                    });
                }

                return new DataResult<UserTypeListDto>(ResultStatus.Error, Messages.UserType.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeListDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("UserType"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserTypeListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            try
            {
                var userTypes = await _unitOfWork.UserTypes.GetAllAsync(u => u.IsDeleted == false && u.IsActive == true);

                if (userTypes.Count > -1)
                {
                    return new DataResult<UserTypeListDto>(ResultStatus.Success, new UserTypeListDto
                    {
                        UserTypes = _mapper.Map<IList<UserTypeDto>>(userTypes)
                    });
                }

                return new DataResult<UserTypeListDto>(ResultStatus.Error, Messages.UserType.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeListDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("UserType"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserTypeDto>> AddAsync(UserTypeAddDto userTypeAddDto, int createdByUserId)
        {
            try
            {
                var userType = _mapper.Map<UserType>(userTypeAddDto);
                userType.CreatedByUserId = createdByUserId;
                userType.ModifiedByUserId = createdByUserId;

                var addedTypeUser = await _unitOfWork.UserTypes.AddAsync(userType);
                await _unitOfWork.SaveAsync();

                return new DataResult<UserTypeDto>(ResultStatus.Success, Messages.UserType.Add(addedTypeUser.UserTypeName), _mapper.Map<UserTypeDto>(addedTypeUser));
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeDto>(ResultStatus.Error, Messages.ExceptionMessage.Add("UserType"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserTypeUpdateDto>> GetUserTypeUpdateDtoAsync(int userTypeId)
        {
            try
            {
                var userType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeId);

                if (userType != null)
                    return new DataResult<UserTypeUpdateDto>(ResultStatus.Success, _mapper.Map<UserTypeUpdateDto>(userType));
                return new DataResult<UserTypeUpdateDto>(ResultStatus.Success, Messages.UserType.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeUpdateDto>(ResultStatus.Error, Messages.ExceptionMessage.Update("UserType"), null,
                    exMessage);
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
                    return new DataResult<UserTypeDto>(ResultStatus.Success, Messages.UserType.Update(updatedUserType.UserTypeName), _mapper.Map<UserTypeDto>(updatedUserType));
                }

                return new DataResult<UserTypeDto>(ResultStatus.Error, Messages.UserType.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserTypeDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("UserType"), null, exMessage);
            }
        }

        public async Task<IResult> DeleteAsync(int userTypeId, int modifiedByUserId)
        {
            try
            {
                var userType = await _unitOfWork.UserTypes.GetAsync(u => u.Id == userTypeId);

                if (userType != null)
                {
                    userType.IsDeleted = true;
                    userType.ModifiedByUserId = modifiedByUserId;
                    userType.ModifiedDate = DateTime.Now;
                    await _unitOfWork.UserTypes.UpdateAsync(userType);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.UserType.Delete(userType.UserTypeName, false));
                }

                return new Result(ResultStatus.Error, Messages.UserType.NotFound(false));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Error, Messages.ExceptionMessage.Delete("UserType"), exMessage);
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

                    return new Result(ResultStatus.Success, Messages.UserType.Delete(userType.UserTypeName, true));
                }

                return new Result(ResultStatus.Error, Messages.UserType.NotFound(false));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Error, Messages.ExceptionMessage.HardDelete("UserType"), exMessage);
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

                return new DataResult<int>(ResultStatus.Error, Messages.UserType.Count("UserType"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Error, Messages.ExceptionMessage.Count("UserType"), -1, exMessage);
            }
        }

        public async Task<IDataResult<int>> CountByIsNonDeletedAsync()
        {
            try
            {
                var userTypeCount = await _unitOfWork.UserTypes.CountAsync(a => !a.IsDeleted);

                if (userTypeCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, userTypeCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.UserType.Count("UserType"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Error, Messages.ExceptionMessage.Count("UserType"), -1, exMessage);
            }
        }
    }
}
