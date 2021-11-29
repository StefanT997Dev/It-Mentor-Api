﻿using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Mentors
{
	public class Details
    {
        public class Query : IRequest<Result<MentorDisplayDto>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<MentorDisplayDto>>
        {
			private readonly IMentorsRepository _repository;
		
            public Handler(IMentorsRepository repository)
            {
                _repository = repository;
			}

            public async Task<Result<MentorDisplayDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _repository.GetMentorAsync(request.Id);

                if (user == null)
                {
                    return Result<MentorDisplayDto>.Failure("Nismo uspeli da pronađemo željenog korisnika");
                }

                var result = Common.GetTotalStarRatingAndAverageStarReview(user.Reviews);

                user.TotalStarRating = result.Item1;

                user.AverageStarReview = result.Item2;

                return Result<MentorDisplayDto>.Success(user);
            }
        }
    }
}