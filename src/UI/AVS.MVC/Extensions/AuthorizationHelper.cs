using Microsoft.AspNetCore.Authorization;

namespace AVS.MVC.Extensions
{
    public class PermissaoRequerida : IAuthorizationRequirement
    {
        public string Permissao { get; set; }
        public PermissaoRequerida(string permissao)
        {
            Permissao = permissao;
        }
    }

    public class PermissaoRequeridaHandler : AuthorizationHandler<PermissaoRequerida>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoRequerida requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permissao" && c.Value.Contains(requirement.Permissao)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
