using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ServiceComposer.AspNetMvc
{
    public interface IHandleResult : IInterceptRoutes
    {
        Task Handle(ResultExecutingContext context, dynamic viewModel, int httpStatusCode);
    }
}
