﻿using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Classes.CreateClass
{
    public class CreateClassHandler : Handler<CreateClassRequest>
    {
        private readonly AppDbContext _context;

        public CreateClassHandler(AppDbContext context)
        {
            _context = context;
        }

        public override async Task<Result> Handle(CreateClassRequest request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);

            if (course == null)
                return NotFound(ErrorCatalog.Course.NotFound);

            if (request.ClassName.Length < 3)
                return BusinessRuleViolated(ErrorCatalog.Class.InvalidName);

            if (await _context.Classes.AnyAsync(c => c.Name.ToUpper() == request.ClassName.ToUpper(), cancellationToken))
                return BusinessRuleViolated(ErrorCatalog.Class.Exists);

            var _class = new Class
            {
                Id = Guid.NewGuid(),
                Name = request.ClassName,
                Description = request.Description,
                Video = request.Video,
                Course = course,
                CourseId = request.CourseId,
                Workload = 1
            };

            await _context.Classes.AddAsync(_class, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
