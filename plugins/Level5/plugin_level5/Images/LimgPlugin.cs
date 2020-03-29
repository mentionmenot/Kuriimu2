﻿using System;
using System.Threading.Tasks;
using Komponent.IO;
using Kontract.Interfaces.FileSystem;
using Kontract.Interfaces.Managers;
using Kontract.Interfaces.Plugins.Identifier;
using Kontract.Interfaces.Plugins.State;
using Kontract.Interfaces.Providers;
using Kontract.Models;
using Kontract.Models.IO;

namespace plugin_level5.Images
{
    public class LimgPlugin : IFilePlugin, IIdentifyFiles
    {
        public Guid PluginId => Guid.Parse("169acf3f-ccc8-4193-b32c-84b44c0f6f68");
        public string[] FileExtensions => new[] { "*.cimg" };
        public PluginMetadata Metadata { get; }

        public LimgPlugin()
        {
            Metadata = new PluginMetadata("LIMG", "onepiecefreak", "Main image for later DS Level-5 games.");
        }

        public async Task<bool> IdentifyAsync(IFileSystem fileSystem, UPath filePath, ITemporaryStreamProvider temporaryStreamProvider)
        {
            var fileStream = await fileSystem.OpenFileAsync(filePath);
            using var br = new BinaryReaderX(fileStream);

            return br.ReadString(4) == "LIMG";
        }

        public IPluginState CreatePluginState(IPluginManager pluginManager)
        {
            return new LimgState();
        }
    }
}
