using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Jogos.Web.Identity
{
    public class JogoIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public JogoIdentityDbContext()
            : base("JogoDbContext")
        {

        }
    }
}