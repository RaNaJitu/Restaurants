using Microsoft.Owin.Security.OAuth;
using Repo.DbContexts;
using Repo.Models;
using Repo.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Apis.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        DefaultDbContext db = new DefaultDbContext();
        private readonly CommonRepository<DefaultDbContext> _repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _repo.Get<CredentialDbModel>(s => s.IsActive && s.Username == context.UserName && s.Password == context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
            string role=db.Database.SqlQuery<string>("select Code from tbl_designation where id=(select top 1 roleid from tbl_designation_role_mapping where userid={0})", user.Id).FirstOrDefault();
            if(string.IsNullOrEmpty(role))
            {
                context.SetError("invalid_grant", "You must have a role");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, role));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            context.Validated(identity);
        }
    }
}