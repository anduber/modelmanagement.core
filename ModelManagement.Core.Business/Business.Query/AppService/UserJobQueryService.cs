﻿using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.Models;
using System.Linq;
using System.Runtime.InteropServices;

namespace ModelManagement.Core.Business.Business.Query.AppService
{
    public class UserJobQueryService : QueryAppService
    {
        public UserJobQueryService()
        {

        }

        public QueryResult ListJobPost(string userId,string statusId,string isActive, QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .JobPosts.Where(
                        t =>
                            t.UserId == userId && (string.IsNullOrEmpty(statusId) || t.StatusId == statusId) &&
                            (string.IsNullOrEmpty(queryParamArg.SearchText) ||
                             t.JobTitle.Contains(queryParamArg.SearchText) ||
                             t.JobDescription.Contains(queryParamArg.SearchText)) &&
                            (string.IsNullOrEmpty(isActive) || t.IsActive == isActive)
                    )
                    .QueryResultList<JobPostListModel>(queryParamArg);
        }

        public QueryResult ListOpenJobPost(JobPostQueryParamArg jobPostQueryParamArg, QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .JobPosts.Where(
                        t =>
                            t.IsActive == "Y" &&
                            (string.IsNullOrEmpty(jobPostQueryParamArg.Sex) || t.Sex == jobPostQueryParamArg.Sex) &&
                            (string.IsNullOrEmpty(jobPostQueryParamArg.JobLocation) ||
                             t.JobLocation == jobPostQueryParamArg.JobLocation) &&
                            (jobPostQueryParamArg.AgeFrom == null || t.AgeFrom >= jobPostQueryParamArg.AgeFrom) &&
                            (jobPostQueryParamArg.AgeThru == null || t.AgeThru <= jobPostQueryParamArg.AgeThru) &&
                            (jobPostQueryParamArg.HeightFrom == null || t.HeightFrom >= jobPostQueryParamArg.HeightFrom) &&
                            (jobPostQueryParamArg.HeightThru == null || t.HeightThru <= jobPostQueryParamArg.HeightThru) &&
                            (jobPostQueryParamArg.JobLocations.Count == 0 ||
                             jobPostQueryParamArg.JobLocations.Contains(t.JobLocationGeoId)) &&
                            (string.IsNullOrEmpty(jobPostQueryParamArg.StatusId) ||
                             jobPostQueryParamArg.StatusId == t.StatusId) &&
                            (string.IsNullOrEmpty(queryParamArg.SearchText) ||
                             t.JobTitle.Contains(queryParamArg.SearchText) ||
                             t.JobDescription.Contains(queryParamArg.SearchText)))
                    .QueryResultList<JobPostListModel>(queryParamArg);
        }

        public QueryResult ListUserJobApplications(string userId,string jobPostId,QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .JobApplications.Where(
                        t =>
                            (string.IsNullOrEmpty(userId) || t.ApplyingUserId == userId) &&
                            (string.IsNullOrEmpty(jobPostId) || t.JobPostId == jobPostId))
                    .QueryResultList<JobApplicationListModel>(queryParamArg);
        }

        public QueryResult ListJobApplication(string jobPostId,string applyingUserId,string statusId,QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .JobApplications.Where(
                        t =>
                            (string.IsNullOrEmpty(jobPostId) || t.JobPostId == jobPostId) &&
                            (string.IsNullOrEmpty(applyingUserId) || t.ApplyingUserId == applyingUserId) &&
                            string.IsNullOrEmpty(statusId) || t.StatusId == statusId)
                    .QueryResultList<JobApplicationListModel>(queryParamArg);
        }

        public QueryResult EditJobPost(string jobPostId)
        {
            return
                ModelManagementContext()
                    .JobPosts.Where(t => t.JobPostId == jobPostId)
                    .QueryResultGet<JobPostListModel>();
        }
    }
}
