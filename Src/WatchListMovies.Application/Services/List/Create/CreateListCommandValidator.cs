using FluentValidation;

namespace WatchListMovies.Application.Services.List.Create;

public class CreateListCommandValidator : AbstractValidator<CreateListCommand>
{
    public CreateListCommandValidator()
    {

    }
}