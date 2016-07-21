// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionController.cs" company="">
//   
// </copyright>
// <summary>
//   The session controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Host.Controllers
{
    using System;
    using System.Web.Http;

    using Dto.Entities;

    using Entities;

    using Host.Communicator;
    using Host.Mappers;

    using Services.Session;

    using ServicesContracts.Session;

    using Shared.Links;
    using Shared.Mappers;

    /// <summary>
    /// The session controller.
    /// </summary>
    public class SessionController : ApiController
    {
        private readonly ISessionService sessionService;

        private readonly IMapper<Session, SessionDto> sessionMapper;
        
        private readonly LinkFactory linkFactory;

        public SessionController()
            : this(new SessionService(), new SessionToDtoMapper(), new LinkFactory())
        {
        }

        public SessionController(ISessionService sessionService, IMapper<Session, SessionDto> sessionMapper, LinkFactory linkFactory)
        {
            this.sessionService = sessionService;
            this.sessionMapper = sessionMapper;
            this.linkFactory = linkFactory;
        }

        [HttpPost]
        [Route("Session", Name = "SessionCreate")]
        public SessionDto CreateSession(Player player)
        {
            var session = this.sessionService.Create();

            var broadcaster = WebSocketBroadcasterRepository.Create(session);

            broadcaster.StartListeningToIncomingRequests();

            var result = this.sessionMapper.Map(session);
            result.Link = this.linkFactory.Create(
                this.ControllerContext.ControllerDescriptor.ControllerName,
                session.Guid);

            return result;
        }

        [HttpPut]
        [Route("Session/{sessionGuid}", Name = "SessionJoin")]
        public void JoinSession(Guid sessionGuid, Player player)
        {
            var session = this.sessionService.Get(sessionGuid);

            var broadcaster = WebSocketBroadcasterRepository.GetFromSession(sessionGuid);

            broadcaster.StartListeningToIncomingRequests();

            var result = this.sessionMapper.Map(session);
            result.Link = this.linkFactory.Create(
                this.ControllerContext.ControllerDescriptor.ControllerName,
                session.Guid);
        }
    }
}