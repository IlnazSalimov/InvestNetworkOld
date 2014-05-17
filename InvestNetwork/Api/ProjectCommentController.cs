using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvestNetwork.Models;

namespace InvestNetwork.Api
{
    public class ProjectCommentController : ApiController
    {
        private readonly IProjectCommentRepository _projectCommentRepository;
        private readonly IInvestContext _investContext;

        public ProjectCommentController(IInvestContext investContext, IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
            _investContext = investContext;
        }

        [Authorize]
        [HttpPost]
        public bool Send(ProjectCommentSending model)
        {
            try
            {
                User user = _investContext.CurrentUser;

                ProjectComment comment = new ProjectComment()
                    {
                        FromUserID = user.Id,
                        CommentText = model.Comment,
                        CommentDate = DateTime.Now,
                        ProjectID = model.ProjectID
                    };

                _projectCommentRepository.Insert(comment);
                _projectCommentRepository.SaveChanges();

                return true;
            }
            catch
            { return false; }
        }
    }
}
