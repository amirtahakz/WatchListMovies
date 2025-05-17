using FluentValidation;

namespace WatchListMovies.Application.Services.Favorite.Create;

public class CreateFavoriteCommandValidator : AbstractValidator<CreateFavoriteCommand>
{
    public CreateFavoriteCommandValidator()
    {

    }
}