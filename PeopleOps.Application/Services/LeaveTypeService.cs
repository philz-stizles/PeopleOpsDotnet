using AutoMapper;
using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveTypeService(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        /// <summary>
        /// This method reates a new <c>LeaveType</c>.
        /// </summary>
        /// <param name="model">The model of the entity to be created.</param>
        /// <returns>void.</returns>
        public async Task CreateAsync(LeaveTypeModel model)
        {
            var newlyCreated = _mapper.Map<LeaveType>(model);
            newlyCreated.CreatedBy = _userAccessor.GetCurrentUserId();
            newlyCreated.CreatedDate = DateTime.Now;

            await _unitOfWork.LeaveTypes.CreateAsync(newlyCreated);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// This method deletes a target LeaveType from the database if it exists.
        /// </summary>
        /// <param name="id"><c>id</c> is the integer id of the target <c>LeaveType</c> to be deleted.</param>
        /// <exception cref="Exception">
        /// When <paramref name="a"/> or <paramref name="b"/> is negative.
        /// </exception>
        public async Task DeleteAsync(int id)
        {
            var existingLeaveType = await _unitOfWork.LeaveTypes.FindOneAsync(l => l.Id == id);
            if(existingLeaveType == null)
            {
                throw new Exception("Leave type does not exist");
            }

            _unitOfWork.LeaveTypes.Delete(existingLeaveType);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// This method updates a target LeaveType if it exists.
        /// </summary>
        /// <param name="model"><c>model</c> is the target <c>LeaveType</c> to be updated.</param>
        /// <exception cref="Exception">
        /// When <paramref name="a"/> or <paramref name="b"/> is negative.
        /// </exception>
        public async Task UpdateAsync(LeaveTypeModel model)
        {
            // var updated = _mapper.Map<LeaveType>(model);
            var existingLeaveType = await _unitOfWork.LeaveTypes.FindOneAsync(l => l.Id == model.Id);
            if (existingLeaveType == null)
            {
                throw new Exception("Leave type does not exist");
            }


            existingLeaveType.Name = model.Name;
            existingLeaveType.Description = model.Description;
            existingLeaveType.DefaultDays = model.DefaultDays;
            existingLeaveType.LastModifiedBy = _userAccessor.GetCurrentUserId();
            existingLeaveType.LastModifiedDate = DateTime.Now;
            _unitOfWork.LeaveTypes.Update(existingLeaveType);
            await _unitOfWork.SaveAsync();
        }


        /// <summary>
        /// This method fetches data and returns a readonly list of type <c>LeaveTypeVM</c>.
        /// </summary>
        /// <returns>a readonly list of <c>LeaveTypeVM</c></returns>
        public async Task<IReadOnlyList<LeaveTypeVM>> GetAllAsync()
        {
            var leavetypes = await _unitOfWork.LeaveTypes.FindAllAsync();
            return _mapper.Map<IReadOnlyList<LeaveTypeVM>>(leavetypes);
        }

        public async Task<Tuple<LeaveTypeVM, LeaveTypeModel>> FindOneAsync(int id)
        {
            var leavetype = await _unitOfWork.LeaveTypes.FindOneAsync(l => l.Id == id);
            if (leavetype == null)
            {
                throw new Exception("Leave type does not exist");
            }

            var leaveTypeVM =  _mapper.Map<LeaveTypeVM>(leavetype);
            var leaveTypeModel = _mapper.Map<LeaveTypeModel>(leavetype);
            return Tuple.Create(leaveTypeVM, leaveTypeModel);
        }
    }
}
