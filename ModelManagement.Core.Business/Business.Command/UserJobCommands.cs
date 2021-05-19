using ModelManagement.Core.Business.Business.Command.AppService;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using System.Collections.Generic;

namespace ModelManagement.Core.Business.Business.Command
{
    public class CreateJobPostCommand : CommandBase, ICommand
    {
        public string UserId { get; set; }
        public List<JobPostDetailCommandArg> JobPostDetails { get; set; }
        public JobPostCommandArg JobPostCommandArg { get; set; }
        
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                var result =  new UserJobService(transaction.Context).CreateJobPost(UserId, JobPostCommandArg,JobPostDetails, UserLoginId);
                transaction.CompleteTransaction();
                return result;
            }
        }
    }


    public class RemoveJobPostCommand : CommandBase, ICommand
    {
        public string JobPostId { get; set; }
        public CommandResult Execute()
        {
            return new UserJobService().RemoveJobPost(JobPostId);
        }
    }

    public class UpdateJobPostCommand : CommandBase, ICommand
    {
        public string JobPostId { get; set; }
        public JobPostCommandArg JobPostCommandArg { get; set; }

        public CommandResult Execute()
        {
            return new UserJobService().UpdateJobPost(JobPostId, JobPostCommandArg);
        }
    }

    public class CloseJobPostCommand : CommandBase, ICommand
    {
        public string JobPostId { get; set; }
        public CommandResult Execute()
        {
            return new UserJobService().CloseJobPost(JobPostId);
        }
    }

    public class CreateJobOffersCommand : CommandBase, ICommand
    {
        public string JobPostId { get; set; }
        public List<string> OfferedUserIds { get; set; }
        public CreateJobOffersCommand()
        {
            OfferedUserIds = new List<string>();
        }
        public CommandResult Execute()
        {
            using (var transaction = new TransactionScope())
            {
                new UserJobService(transaction.Context).CreateJobOfferes(JobPostId, OfferedUserIds, UserLoginId);
                transaction.CompleteTransaction();
                return Utility.CommandSuccess();
            }

        }
    }

    public class CreateJobApplicationCommand : CommandBase, ICommand
    {
        public string JobPostId { get; set; }
        public string ApplyingUserId { get; set; }
        public CommandResult Execute()
        {
            return new UserJobService().CreateJobApplication(JobPostId, ApplyingUserId, UserLoginId);
        }
    }



}
