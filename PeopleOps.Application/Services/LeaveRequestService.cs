using AutoMapper;
using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveRequestService(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        /// <summary>
        /// This method reates a new <c>LeaveRequest</c>.
        /// </summary>
        /// <param name="model">The model of the entity to be created.</param>
        /// <returns>void.</returns>
        public async Task CreateAsync(LeaveRequestModel model)
        {
            var newlyCreated = _mapper.Map<LeaveRequest>(model);
            newlyCreated.RequestingEmployeeId = _userAccessor.GetCurrentUserId();
            newlyCreated.CreatedBy = _userAccessor.GetCurrentUserId();
            newlyCreated.CreatedDate = DateTime.Now;

            await _unitOfWork.LeaveRequests.CreateAsync(newlyCreated);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// This method deletes a target LeaveRequest from the database if it exists.
        /// </summary>
        /// <param name="id"><c>id</c> is the integer id of the target <c>LeaveRequest</c> to be deleted.</param>
        /// <exception cref="Exception">
        /// When <paramref name="a"/> or <paramref name="b"/> is negative.
        /// </exception>
        public async Task DeleteAsync(int id)
        {
            var existingLeaveRequest = await _unitOfWork.LeaveRequests.FindOneAsync(l => l.Id == id);
            if(existingLeaveRequest == null)
            {
                throw new Exception("Leave request does not exist");
            }

            _unitOfWork.LeaveRequests.Delete(existingLeaveRequest);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// This method updates a target LeaveRequest if it exists.
        /// </summary>
        /// <param name="model"><c>model</c> is the target <c>LeaveRequest</c> to be updated.</param>
        /// <exception cref="Exception">
        /// When <paramref name="a"/> or <paramref name="b"/> is negative.
        /// </exception>
        public async Task UpdateAsync(LeaveRequestModel model)
        {
            // var updated = _mapper.Map<LeaveRequest>(model);
            var existingLeaveRequest = await _unitOfWork.LeaveRequests.FindOneAsync(l => l.Id == model.Id);
            if (existingLeaveRequest == null)
            {
                throw new Exception("Leave request does not exist");
            }

            existingLeaveRequest.LastModifiedBy = _userAccessor.GetCurrentUserId();
            existingLeaveRequest.LastModifiedDate = DateTime.Now;
            _unitOfWork.LeaveRequests.Update(existingLeaveRequest);
            await _unitOfWork.SaveAsync();
        }


        /// <summary>
        /// This method fetches data and returns a readonly list of type <c>LeaveRequestVM</c>.
        /// </summary>
        /// <returns>a readonly list of <c>LeaveRequestVM</c></returns>
        public async Task<IReadOnlyList<LeaveRequestVM>> FindAllAsync(
            Expression<Func<LeaveRequest, bool>> predicate = null, 
            Func<IQueryable<LeaveRequest>, IOrderedQueryable<LeaveRequest>> orderBy = null, 
            List<string> includes = null)
        {
            var leavetypes = await _unitOfWork.LeaveRequests.FindAllAsync(predicate, orderBy, includes);
            return _mapper.Map<IReadOnlyList<LeaveRequestVM>>(leavetypes);
        }

        public async Task<Tuple<LeaveRequestVM, LeaveRequestModel>> FindOneAsync(int id)
        {
            var leavetype = await _unitOfWork.LeaveRequests.FindOneAsync(l => l.Id == id);
            if (leavetype == null)
            {
                throw new Exception("Leave request does not exist");
            }

            var leaveTypeVM =  _mapper.Map<LeaveRequestVM>(leavetype);
            var leaveTypeModel = _mapper.Map<LeaveRequestModel>(leavetype);
            return Tuple.Create(leaveTypeVM, leaveTypeModel);
        }
    }
}
