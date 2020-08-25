using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class UserJobService : AppRepository
    {
        private AppRepository _appRepository;
        public UserJobService(ModelManagementContext context = null) : base(context)
        {
            var appContext = context ?? new ModelManagementContext();
            _appRepository = new AppRepository(appContext);
        }


        public CommandResult CreateJobPost(string userId, JobPostCommandArg jobPostCommandArg, string userLoginId)
        {
            var jobPost = SetJobPost(userId, jobPostCommandArg);
            jobPost.JobPostId = Utility.GetId();
            jobPost.UserLoginId = userLoginId;
            jobPost.IsActive = "Y";
            jobPost.StatusId = Utility.Status.JobPostCreated;
            JobPost().Create(jobPost);
            return Utility.CommandSuccess(jobPost.JobPostId);
        }

        private JobPost SetJobPost(string userId, JobPostCommandArg jobPostCommandArg)
        {
            return new JobPost
            {
                UserId = userId,
                JobTitle = jobPostCommandArg.JobTitle,
                JobDescription = jobPostCommandArg.JobDescription,
                JobStartDate = jobPostCommandArg.JobStartDate,
                JobDueDate = jobPostCommandArg.JobDueDate,
                PaymentMethodEnumId = jobPostCommandArg.PaymentMethodEnumId,
                PaymentAmount = jobPostCommandArg.PaymentAmount,
                HeightFrom = jobPostCommandArg.HeightFrom,
                HeightThru = jobPostCommandArg.HeightThru,
                AgeFrom = jobPostCommandArg.AgeFrom,
                AgeThru = jobPostCommandArg.AgeThru,
                JobLocation = jobPostCommandArg.JobLocation,
                Quantity = jobPostCommandArg.Quantity,
                Sex = jobPostCommandArg.Sex,
                Complexion = jobPostCommandArg.Complexion,
                HairColor = jobPostCommandArg.HairColor,
                EyeColor = jobPostCommandArg.EyeColor,
                Bust = jobPostCommandArg.Bust,
                Waist = jobPostCommandArg.Waist,
                Hip = jobPostCommandArg.Hip,
                DressSize = jobPostCommandArg.DressSize,
                ShoeSize = jobPostCommandArg.ShoeSize
            };
        }

        public CommandResult RemoveJobPost(string jobPostId)
        {
            var jobPost = JobPost().Find(jobPostId);
            //JobPost().Delete(jobPost);
            jobPost.IsActive = "N";
            JobPost().Update(jobPost);
            return Utility.CommandSuccess();
        }

        public CommandResult UpdateJobPost(string jobPostId, JobPostCommandArg jobPostCommandArg)
        {
            var jobPost = JobPost().Find(jobPostId);
            jobPost.JobTitle = jobPostCommandArg.JobTitle;
            jobPost.JobDescription = jobPostCommandArg.JobDescription;
            jobPost.JobStartDate = jobPostCommandArg.JobStartDate;
            jobPost.JobDueDate = jobPostCommandArg.JobDueDate;
            jobPost.PaymentMethodEnumId = jobPostCommandArg.PaymentMethodEnumId;
            jobPost.PaymentAmount = jobPostCommandArg.PaymentAmount;
            jobPost.HeightFrom = jobPostCommandArg.HeightFrom;
            jobPost.HeightThru = jobPostCommandArg.HeightThru;
            jobPost.AgeFrom = jobPostCommandArg.AgeFrom;
            jobPost.AgeThru = jobPostCommandArg.AgeThru;
            jobPost.JobLocation = jobPostCommandArg.JobLocation;
            jobPost.Quantity = jobPostCommandArg.Quantity;
            jobPost.Sex = jobPostCommandArg.Sex;
            JobPost().Update(jobPost);
            return Utility.CommandSuccess();
        }

        public CommandResult CloseJobPost(string jobPostId)
        {
            var jobPost = JobPost().Find(jobPostId);
            if (jobPost.IsActive == "N")
                throw new InvalidOperationException(" Job is already closed! ");
            jobPost.IsActive = "N";
            JobPost().Update(jobPost);
            return Utility.CommandSuccess();
        }

        public CommandResult CreateJobOfferes(string jobPostId, List<string> offeredUserIds, string userLoginId)
        {
            foreach (var jobOffer in offeredUserIds.Select(offeredUser => new JobOffer
            {
                JobOfferId = Utility.GetId(),
                JobPostId = jobPostId,
                OfferedUserId = offeredUser,
                StatusId = Utility.Status.JobOfferOffered,
                IsSeen = "N",
                UserLoginId = userLoginId
            }))
            {
                JobOffer().Add(jobOffer);
            }

            return Utility.CommandSuccess();
        }

        public CommandResult CreateJobApplication(string jobPostId, string applyingUserId,string userLoginId)
        {
            var jobApplication = new JobApplication
            {
                JobApplicationId=Utility.GetId(),
                JobPostId=jobPostId,
                ApplyingUserId = applyingUserId,
                StatusId=Utility.Status.JobApplied,
                ApplicationDate=DateTime.Now,
                UserLoginId=userLoginId
            };
            JobApplication().Create(jobApplication);
            return Utility.CommandSuccess(jobApplication.JobApplicationId);
        }
    }
}
