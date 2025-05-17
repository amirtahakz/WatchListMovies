using FluentValidation;

namespace WatchListMovies.Application.Services.Tv.Create;

public class CreateTvCommandValidator : AbstractValidator<CreateTvCommand>
{
    public CreateTvCommandValidator()
    {

    }
}