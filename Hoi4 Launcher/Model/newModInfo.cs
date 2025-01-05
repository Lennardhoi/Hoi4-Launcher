using System.Collections.Generic;

namespace Hoi4_Launcher.Model
{
    public class newModInfo
    {
        public string displayName { get; set; }
        public string gameRegestryMod { get; set; }
        public string modfolder { get; set; }

        public List<string> tags { get; set; }
        public string supported_version { get; set; }
        public string remote_fileid { get; set; }
    }
}
