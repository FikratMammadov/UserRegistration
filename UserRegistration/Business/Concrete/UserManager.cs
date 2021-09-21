using AutoMapper;
using Business.Abstract;
using Business.ValidationRoles.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        public UserManager(IUserDal userDal,IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<UserDto>> GetAllDetails()
        {
            var result = _userDal.GetAll();
            var mappedResult = new List<UserDto>();
            foreach (var item in result)
            {
                var mapResult = _mapper.Map<UserDto>(item);
                mappedResult.Add(mapResult);
            }
            return new SuccessDataResult<List<UserDto>>(mappedResult);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(id));
        }

        public IDataResult<UserDto> GetDetailById(int id)
        {
            var result = _userDal.GetById(id);
            var mappedResult = _mapper.Map<UserDto>(result);
            return new SuccessDataResult<UserDto>(mappedResult);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
