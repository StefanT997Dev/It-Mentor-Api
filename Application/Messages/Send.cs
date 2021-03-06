// using System.Threading;
// using System.Threading.Tasks;
// using Application.Core;
// using Application.DTOs;
// using Domain;
// using MediatR;
// using Persistence;

// namespace Application.Messages
// {
//     public class Send
//     {
//         public class Command : IRequest<Result<MessageDto>>
//         {
//             public string MentorId { get; set; }
//             public Message Message { get; set; }
//         }

//         public class Handler : IRequestHandler<Command,Result<MessageDto>>
//         {
//             private readonly DataContext _context;
//             public Handler(DataContext context)
//             {
//                 _context = context;
//             }

//             public async Task<Result<MessageDto>> Handle(Command request, CancellationToken cancellationToken)
//             {
//                 var Mentor = await _context.Users.FindAsync(request.MentorId);

//                 var message = new Message{
//                     Id=request.Message.Id,
//                     Content=request.Message.Content,
//                     Mentor=Mentor
//                 };

//                 _context.Messages.Add(message);

//                 await _context.SaveChangesAsync();

//                 return Unit.Value;
//             }
//         }
//     }
// }