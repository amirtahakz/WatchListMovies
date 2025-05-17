using FluentValidation;

namespace WatchListMovies.Application.Services.Genre.Create
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {

        }
    }
}
