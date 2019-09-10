namespace BernardBr.PoCs.TransformacaoMensagem.API.Validators
{
    using FluentValidation;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Classe responsável pela validação do <see cref="IFormFile"/>.
    /// </summary>
    public class FormFileValidator : AbstractValidator<IFormFile>
    {
        /// <summary>
        /// Inicizaliza uma nova instância de <see cref="FormFileValidator"/>.
        /// </summary>
        public FormFileValidator()
        {
            RuleFor(file => file)
                .NotNull();
            RuleFor(file => file.ContentType)
                .Must((contentType) => contentType.Equals("application/xml") || contentType.Equals("application/json"));
        }
    }
}