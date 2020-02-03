using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyMusic.Resources;

namespace MyMusic.Validators
{
    public class SaveMusicResourceValidator : AbstractValidator<SaveMusicResource>
    {
        public SaveMusicResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.ArtistId)
                .NotEmpty()
                .WithMessage("'ArtistId' must not be 0");
        }
    }
}
