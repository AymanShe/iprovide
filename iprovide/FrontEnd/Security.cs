using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Security
    {
        public static void Authentication(RazorPagesOptions options)
        {
            options.Conventions.AuthorizePage("/index");
            options.Conventions.AuthorizeFolder("/Transactions");
            options.Conventions.AuthorizeFolder("/Admin", "Admin");
            //options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
            //options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
        }
        public static void Authorization(AuthorizationOptions options)
        {
            options.AddPolicy("EditTransaction", policy => { policy.RequireUserName("ayman@email.com").Build(); });
            options.AddPolicy("DeleteTransaction", policy => { policy.RequireUserName("ayman@email.com").Build(); });
            options.AddPolicy("Admin", policy => { policy.RequireAuthenticatedUser().RequireIsAdminClaim(); });
        }
    }
}
