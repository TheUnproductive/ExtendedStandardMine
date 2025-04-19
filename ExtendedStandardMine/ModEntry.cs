using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using xTile;
using xTile.Layers;
using xTile.Tiles;
using xTile.Dimensions;

namespace ExtendedStandardMine
{
    internal sealed class ModEntry : Mod
    {

        private ModConfig _config;
        public override void Entry(IModHelper helper)
        {
            I18n.Init(helper.Translation);
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            helper.Events.Content.AssetRequested += this.ReplaceLevel120;
            this.Monitor.Log($"ExtendedStandardMine loaded successfully. :)", LogLevel.Info);
        }

        private void ReplaceLevel120(object? sender, AssetRequestedEventArgs e)
        {
            if (e.Name.IsEquivalentTo("Maps/Mines/120"))
            {
                e.Edit(asset =>
                {
                    IAssetDataForMap editor = asset.AsMap();
                    Map map = editor.Data;

                    Layer layer = map.GetLayer("Back");

                    layer.Tiles[14, 11] = new StaticTile(
                        layer: layer,
                        tileSheet: map.GetTileSheet("mine"),
                        tileIndex: 173,
                        blendMode: BlendMode.Alpha
                    );

                    Tile tile = this.GetTile(map, layer, 14, 11);
                    if (tile == null)
                    {
                        return;
                    }
                    tile.Properties["Passable"] = "F";
                    
                });
            }
            return;
        }

        private Tile GetTile(Map map, Layer layer, int tileX, int tileY)
        {
            Location pixelPosition = new Location(tileX * Game1.tileSize, tileY * Game1.tileSize);

            return layer.PickTile(pixelPosition, Game1.viewport.Size);
        }

        private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            return;
        }
    }
}
