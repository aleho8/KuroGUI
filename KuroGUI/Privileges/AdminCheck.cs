using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuroGUI.Handlers;
using Discord.Commands;

namespace KuroGUI.Privileges
{
    public class IsAdmin : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (PermHandler.IsAdmin(context.User.Id))
            {
                return Task.Run(() => PreconditionResult.FromSuccess());
            }
            return Task.Run(() => PreconditionResult.FromError("Not my Admin."));
        }
    }

}
