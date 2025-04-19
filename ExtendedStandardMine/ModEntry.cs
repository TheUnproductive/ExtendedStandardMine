using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace ExtendedStandardMine
{
    internal sealed class ModEntry : Mod
    {

        private ModConfig _config;
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            this.Monitor.Log($"ExtendedStandard Mine loaded successfully. :)", LogLevel.Info);
        }

        private void OnGameLaunched(object sender, EventArgs e)
        {
            return;
        }
    }
}
