using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace ExtendedStandardMine
{
    internal sealed class ModEntry : Mod
    {

        private ModConfig _config;
        public override void Entry(IModHelper helper)
        {
            I18n.Init(helper.Translation);
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            this.Monitor.Log($"ExtendedStandardMine loaded successfully. :)", LogLevel.Info);
        }

        private void OnGameLaunched(object sender, EventArgs e)
        {
            return;
        }
    }
}
