/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
    public class List
    {
        public class Query : IRequest<Result<List<ReviewDto>>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<ReviewDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ReviewDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reviews = await Common.GetUserReviews(_context,_mapper,request.Id);

                if(reviews.Count==0)
                {
                    return Result<List<ReviewDto>>.Failure("Ovaj mentor jo� nema nijednu recenziju");
                }

                return Result<List<ReviewDto>>.Success(reviews);
            }
        }
    }
}*/