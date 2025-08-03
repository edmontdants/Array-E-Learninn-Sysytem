using MediatR;

namespace ArrayELearnApi.Controllers
{
    public class LessonsController
    {
        private readonly IMediator _mediator;
        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
