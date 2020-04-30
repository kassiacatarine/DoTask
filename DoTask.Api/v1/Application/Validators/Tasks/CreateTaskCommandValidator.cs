using DoTask.Api.v1.Application.Commands.Tasks.CreateTaskCommand;
using FluentValidation;

namespace DoTask.Api.v1.Application.Validators.Tasks
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(command => command.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(command => command.UserId).NotEmpty().WithMessage("UserId is required");
        }
    }
}
