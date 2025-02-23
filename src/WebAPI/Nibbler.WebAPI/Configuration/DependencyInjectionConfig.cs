using FluentValidation.Results;
using MediatR;
using Nibbler.Core.Mediator;
using Nibbler.Core.Messages;
using Nibbler.Diario.app.Commands;
using Nibbler.Diario.App.Commands;
using Nibbler.Diario.app.Events;
using Nibbler.Diario.App.Events;
using Nibbler.Diario.app.Queries;
using Nibbler.Diario.Domain.Interfaces;
using Nibbler.Diario.Infra.Repositories;
using Nibbler.Usuario.App.Commands;
using Nibbler.Usuario.App.Queries;
using Nibbler.Usuario.Domain.Interfaces;
using Nibbler.Usuario.Infra.Repositories;
using Nibbler.Diario.App.Queries;
using Nibbler.Diario.app.Queries.QueriesInterface;

namespace Nibbler.WebAPI.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        //Usuario
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IUsuarioQueries, UsuarioQueries>();
        
        //Diario
        services.AddScoped<IDiarioRepository, DiarioRepository>();
        services.AddScoped<IDiarioQueries, DiarioQueries>();
        //Entrada
        services.AddScoped<IDiarioQueries, DiarioQueries>();
        services.AddScoped<IEntradaQueries, EntradaQueries>();
        //Etiqueta
        services.AddScoped<IEtiquetaQueries, EtiquetaQueries>();
        services.AddScoped<IRequestHandler<AdicionarEtiquetaCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<CriarEtiquetaCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarEtiquetaCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<RemoverEtiquetaDoDiarioCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AdicionarEtiquetaAoDiarioCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<ExcluirEtiquetaCommand, ValidationResult>, DiarioCommandHandler>();
        //Contexto de Usuários
        services.AddScoped<IRequestHandler<AdicionarUsuarioCommand, ValidationResult>, UsuariosCommandHandler>();
        services.AddScoped<INotificationHandler<UsuarioAtualizadoEvent>,UsuarioAtualizadoEventHandler>();

        //Contexto de Diario
        services.AddScoped<INotificationHandler<DiarioCriadoEvent>, DiarioEventHandler>();
        services.AddScoped<IRequestHandler<AdicionarDiarioCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarDiarioCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AdicionarReflexaoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<MarcarComoExcluidoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AdicionarEntradaCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarEntradaCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<RemoverEntradaCommand, ValidationResult>, DiarioCommandHandler>();
        
        // Reflexao
        services.AddScoped<IReflexaoQueries, ReflexaoQueries>();
        services.AddScoped<IRequestHandler<AdicionarReflexaoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarReflexaoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<ExcluirReflexaoCommand, ValidationResult>, DiarioCommandHandler>();

        // Emocao
        services.AddScoped<IEmocaoQueries, EmocaoQueries>();
        services.AddScoped<IRequestHandler<AdicionarEmocaoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarEmocaoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<ExcluirEmocaoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<AssociarEmocaoNaReflexaoCommand, ValidationResult>, DiarioCommandHandler>();
        services.AddScoped<IRequestHandler<RemoverEmocaoDaReflexaoCommand, ValidationResult>, DiarioCommandHandler>();
    }
}
