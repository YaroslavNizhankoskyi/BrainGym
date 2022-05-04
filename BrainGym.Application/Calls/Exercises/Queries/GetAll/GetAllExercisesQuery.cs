using BrainGym.Application.Calls.Exercises.Queries.Get;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.Exercises.Queries.GetAll
{
    public class GetAllExercisesQuery : IRequest<IQueryable<Exercise>>
    {

    }

    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IQueryable<Exercise>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllExercisesQueryHandler(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<IQueryable<Exercise>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            return _uow.Exercises.GetAll();            
        }
    }
}
