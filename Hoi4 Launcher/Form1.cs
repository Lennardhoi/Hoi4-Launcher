using Hoi4_Launcher.Model;
using Hoi4_Launcher.Utility;
using Newtonsoft.Json;
using Steamworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Text;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Threading;
namespace Hoi4_Launcher
{
    
    public partial class Form1 : Form
    {
        private static readonly string ParadoxFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Paradox Interactive");
        private static readonly string Hoi4_Doc = Path.Combine(ParadoxFolder, "Hearts of Iron IV");
        private static readonly string Hoi4_Enb_Mods = Path.Combine(Hoi4_Doc, "dlc_load.json");
        private static readonly string Hoi4_Mods = Path.Combine(Hoi4_Doc, "mod");
        private static readonly string Hoi4_Saves = Path.Combine(Hoi4_Doc, "save games");
        private static readonly string sCurrentDirectory = Directory.GetCurrentDirectory();
        private static readonly string sFile = Path.Combine(sCurrentDirectory, @"..\..\workshop\content\394360");
        private static readonly string Workshop = Path.GetFullPath(sFile);
        private static dlcModel[] dis_dlc = null;
        private static int modsCount;
        private bool m_bInitialized;
        protected Callback<DownloadItemResult_t> m_DownloadItemResult;
        private static LHSettings gameSettings = new LHSettings();
        private string args;

        private static int _nakama = 0;
        private readonly Timer updateUI = new Timer(100);
        private static readonly launchSettings data = new launchSettings();

        static class Global
        {

            public static bool updateComplete = false;
            private static int _crashdata = 0;
            private static int _debug = 0;
            private static int _binary = 0;
            private static int _debugsaves = 0;
            public static int crashdata
            {
                get { return _crashdata; }
                set { _crashdata = value; }
            }
            public static int randomlog
            {
                get { return _binary; }
                set { _binary = value; }
            }
            public static int nakama
            {
                get { return _nakama; }
                set { _nakama = value; }
            }
            public static int debugsaves
            {
                get { return _debugsaves; }
                set { _debugsaves = value; }
            }
            public static int debug
            {
                get { return _debug; }
                set { _debug = value; }
            }
        }
        public Form1(string[] args)
        {
            foreach (string arg in args)
            {
                this.args += arg + " ";
            }
            InitializeComponent();
        }
       
        public launchSettings load_items()
        {
            launchSettings obj;

            string data = File.ReadAllText(Hoi4_Enb_Mods);
            obj = JsonConvert.DeserializeObject<launchSettings>(data);
            return obj;
        }
        static void UpdateWorkshopContent(ulong workshopItemId, string contentPath)
        {
            Global.updateComplete = false;
            AppId_t AppID = new AppId_t(394360);
            var handle = SteamUGC.StartItemUpdate(AppID, new PublishedFileId_t(workshopItemId));
            MessageBox.Show(workshopItemId.ToString()+ " "+ contentPath);
            // Set only the content path
            SteamUGC.SetItemContent(handle, contentPath);
            
            Console.WriteLine("Starting content update...");
            SteamAPICall_t updateCall = SteamUGC.SubmitItemUpdate(handle, "Updated content only");
            CallResult<SubmitItemUpdateResult_t> callResult = new CallResult<SubmitItemUpdateResult_t>();
            callResult.Set(updateCall, OnContentUpdated);
        }

        static void OnContentUpdated(SubmitItemUpdateResult_t callback, bool ioFailure)
        {
            if (ioFailure || callback.m_eResult != EResult.k_EResultOK)
            {
                MessageBox.Show("Failed to update the workshop item. Check the log for details.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Workshop item updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Global.updateComplete = true;
        }


        public List<newModInfo> load_mods_info()
        {
            string[] stringSeparators = new string[] { "\n\t" };
            List<newModInfo> mods = new List<newModInfo>();
            Logger(Hoi4_Mods);
            DirectoryInfo d = new DirectoryInfo(Hoi4_Mods);
            FileInfo[] Files = d.GetFiles("*.mod");
            foreach (FileInfo file in Files)
            {
                newModInfo mod = new newModInfo
                {
                    gameRegestryMod = "mod/" + file.Name
                };
                //if (mod.gameRegestryMod == "mod/ugc_1368243403.mod")
                //{
                //    Debugger.Break();
                //}
                string[] modFiles = File.ReadAllLines(file.FullName);
                string modFileWhole = File.ReadAllText(file.FullName);
                foreach (string modFile in modFiles)
                {
                    if (modFile.Contains("name="))
                    {
                        if (modFileWhole.Contains("workshop"))
                        {
                            mod.displayName = modFile.Split('=')[1].Replace("\"", "");
                        }
                        else
                        {
                            mod.displayName = modFile.Split('=')[1].Replace("\"", "");
                            string v = mod.displayName + "[LOCAL]";
                            mod.displayName = v;
                        }
                    }
                    if (modFile.Contains("supported_version="))
                    {
                        mod.supported_version = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("remote_file_id="))
                    {
                        mod.remote_fileid = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("path="))
                    {
                        mod.modfolder = modFile.Split('=')[1].Replace("\"", "");
                    }
                    if (modFile.Contains("tags={"))
                    {
                        List<string> tagsList = new List<string>();
                        string tagsNotFormated = removeBrackets(modFileWhole, "tags={", "}", false);
                        string[] tagsFormated = tagsNotFormated.Split(stringSeparators, StringSplitOptions.None);
                        foreach (string tag in tagsFormated)
                        {
                            if (tag != "")
                            {
                                string currentTag = removeBrackets(tag, "\"", "\"");
                                tagsList.Add(currentTag);
                                bool isItemInList = false;
                                //foreach (object listItem in categoriesBox.Items)
                                //{
                                //    if (listItem.ToString().ToLower() == currentTag.ToLower())
                                //    {
                                //        isItemInList = true;
                                //    }
                                //}
                                //if (!isItemInList)
                                //{
                                //    categoriesBox.Items.Add(currentTag);
                                //}
                            }
                        }
                        mod.tags = tagsList;
                    }
                }
                mods.Add(mod);
            }
            return mods;
        }

        private void load()
        {
            //Load Mods
            m_bInitialized = SteamAPI.Init();
#if DEBUG
            Directory.SetCurrentDirectory(Path.GetFullPath(@"G:\SteamLibrary\steamapps\common\Hearts of Iron IV"));
#endif
            //SteamUGC.StopPlaytimeTrackingForAllItems();
            if (!m_bInitialized)
            {
                Logger("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information." + this);

                return;
            }
            launchSettings items = load_items();
            List<newModInfo> mods = load_mods_info();
            int enabled_mods = 0;
            foreach (newModInfo mod in mods)
            {
                bool enabled = false;
                if (items.enabled_mods.Contains(mod.gameRegestryMod)) { enabled = true; enabled_mods++; }
                list_mods.Items.Add(mod.displayName, enabled);
            }
            modsCount = mods.Count;
            updateModsCount(enabled_mods, modsCount);

            if (items.my_launchersettings != null &&items.my_launchersettings.Count == 5 )
            {
                List<int> integers = items.my_launchersettings.ConvertAll(s => int.Parse(s));
                Global.debug = integers[0];
                Global.crashdata = integers[1];
                Global.randomlog = integers[2];
                Global.debugsaves = integers[3];
                Global.nakama = integers[4];
                if (Global.nakama == 1)
                {
                    nakama.Checked = true;
                }
                if (Global.debug ==1)
                {
                    enable_debug.Checked = true;
                }
                if (Global.crashdata == 1)
                {
                    enable_crashdatalog.Checked = true;
                }
                if (Global.randomlog == 1)
                {
                    enable_random_log.Checked = true;
                }
                if (Global.debugsaves > 0)
                {
                    debugsaves.Value = Global.debugsaves;
                }
            }
            else
            {
                Global.debug = 0;
                Global.crashdata = 0;
                Global.randomlog = 0;
                Global.debugsaves = 0;
                Global.nakama = 0;
            }
           

            //Load DLC
            foreach (dlcModel dlc in dis_dlc)
            {
                bool enabled = true;
                if (items.disabled_dlcs.Contains(dlc.path)) { enabled = false; }
                list_dlc.Items.Add(dlc.name, enabled);
            }
            //Load LHSetthings
            string data = File.ReadAllText(@"launcher-settings.json");
            gameSettings = JsonConvert.DeserializeObject<LHSettings>(data);
            label_version.Text += " " + gameSettings.version;
        }

        public void SerializeConfig(object x)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            File.WriteAllText(Hoi4_Enb_Mods, JsonConvert.SerializeObject(x, Formatting.Indented, settings));
        }

        public dlcModel[] GetDLCs()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "dlc");
            List<dlcModel> dlcs = new List<dlcModel>();
            foreach (string dir in Directory.GetDirectories(path))
            {
                // try
                // {
                DirectoryInfo dInfo = new DirectoryInfo(dir);
                if (dInfo.GetFilesByExtensions(".dlc").Count() > 0)
                {
                    string dlcFullPath = dInfo.GetFilesByExtensions(".dlc").First().FullName;
                    dlcModel dlc = new dlcModel();
                    IEnumerable<string> x = File.ReadLines(dlcFullPath);
                    dlc.name = x.First().Split('"')[1].Replace('"', ' ');
                    // string test2 = x.ElementAt(1);
                    // if (test2.Contains('"'))
                    // { x.ElementAt(1).Replace("= dlc", "= \"dlc"); }
                    dlc.path = dlcFullPath.Replace("Hearts of Iron IV", "~").Split('~')[1].Replace('\\', '/').Substring(1);
                    // dlc.path = "dlc/"+x.ElementAt(1).Replace("= dlc", "= \"dlc").Split('"')[1].Split('/')[1] + ".dlc";
                    string party = x.ElementAt(x.Count() - 2).Split('=')[1].Replace(" ", "");
                    if (party == "yes")
                    { dlc._3rdparty = true; button2.BackgroundImage = Properties.Resources.play3rd; }
                    else { dlc._3rdparty = false; button2.BackgroundImage = Properties.Resources.play; }
                    dlcs.Add(dlc);
                }
                //  }
                // catch (Exception)
                //  {
                //  }
            }
            return dlcs.ToArray();
        }




        private string removeBrackets(string text, string from, string to, bool tolast = true)
        {
            int pFrom = text.IndexOf(from) + from.Length;
            int pTo = 0;
            if (tolast)
            {
                pTo = text.LastIndexOf(to);
            }
            else
            {
                pTo = text.IndexOf(to);
            }
            try
            {
                return text.Substring(pFrom, pTo - pFrom);
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Logger("Modified Version of Xferno2s launcher https://github.com/Xferno2/Hearts-Of-Iron-IV-Launcher");


            DoubleBuffered = true;
            Utility.Utility.enableDoubleBuff(tabControl1);
            dis_dlc = GetDLCs();
            load();
            updateUI.Elapsed += updateUI_DoWork;
            updateUI.Start();
        }

        private void updateUI_DoWork(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.InvokeEx(x => updateUIinvokable());
            }
            catch (Exception) { }
        }

        private void updateModsCount(int count, int maxCount)
        {
            label_mods.Text = "Mods: " + count + "/" + maxCount;
        }

        private void updateUIinvokable()
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                updateModsCount(list_mods.CheckedItems.Count, modsCount);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                checkFor3rdParty();
            }
        }
        private void checkFor3rdParty()
        {
            foreach (dlcModel dlc in dis_dlc)
            {
                if (dlc._3rdparty && list_dlc.CheckedItems.Contains(dlc.name))
                {
                    button2.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.play3rd;
                    break;
                }
                else
                {
                }

                button2.BackgroundImage = global::Hoi4_Launcher.Properties.Resources.play;
            }
        }
        public void Logger(string log)
        {
            textBox1.InvokeEx(tx => tx.Text += "[" + DateTime.Now + "] " + log + System.Environment.NewLine);
        }

        private void userControl12_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<newModInfo> mods = load_mods_info();
            List<string> enabled_mods = new List<string>();

            foreach (newModInfo mod in mods)
            {
                if (list_mods.CheckedItems.Contains(mod.displayName))
                {
                    if (mod.displayName != null)
                    {
                        if (!string.IsNullOrEmpty(mod.remote_fileid))
                        {
                            PublishedFileId_t r = (PublishedFileId_t)ulong.Parse(mod.remote_fileid);
                            Logger("Updated " + mod.displayName + " (" + mod.remote_fileid + ")");
                            UInt32 unItemState = SteamUGC.GetItemState(r);
                            Logger(mod.remote_fileid + " " + unItemState);
                            if (unItemState > 7 && unItemState < 16)
                            {
                                Logger(mod.remote_fileid + "update is needed" + unItemState);
                                _ = SteamUGC.DownloadItem(r, true);
                            }
                            else if (unItemState < 7)
                            {
                                Logger(mod.displayName + " is up to date " + unItemState);
                            }
                        }
                    }
                }
                //uint nSubscriptions = SteamUGC.GetNumSubscribedItems();
                // UInt64 r = Convert.ToUInt64(mod.remote_fileid);
                //UInt64 m_PublishedFileId = Convert.ToUInt64(mod.remote_fileid);
            }
        }
        
        private void enable_debug_CheckedChanged(object sender, EventArgs e)
        {
           
            if (((CheckBox)sender).Checked == true)
            {
                Global.debug = 1;
            }
            else
            {
                Global.debug = 0;
            }
        }

        
        private void enable_crashdatalog_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                Global.crashdata = 1;
            }
            else
            {
                Global.crashdata = 0;
            }

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Global.debugsaves = ((int)debugsaves.Value);
            
            
        }

        private void enable_random_log_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                Global.randomlog = 1;
            }
            else
            {
                Global.randomlog = 0;
            }
        }
        private void button2_click(object sender, EventArgs e)
        {
            List<newModInfo> mods = load_mods_info();
            List<string> enabled_mods = new List<string>();
            foreach (newModInfo mod in mods)
            {
                if (list_mods.CheckedItems.Contains(mod.displayName))
                {
                    if (mod.displayName != null)
                    {
                        enabled_mods.Add(mod.gameRegestryMod);
                    }
                }
            }
            List<string> disabled_dlc = new List<string>();
            foreach (object dlc in list_dlc.Items)
            {
                if (!list_dlc.CheckedItems.Contains(dlc))
                {
                    foreach (dlcModel disdlc in dis_dlc)
                    {
                        if (disdlc.name == dlc.ToString()) { disabled_dlc.Add(disdlc.path); }
                    }
                }
            }
            launchSettings config = load_items();
            config.enabled_mods = enabled_mods;
            config.disabled_dlcs = disabled_dlc;
            var numbers2 = new List<int>() { Global.debug, Global.crashdata, Global.randomlog,Global.debugsaves,Global.nakama };
            List<string> l2 = numbers2.ConvertAll<string>(delegate(int i) { return i.ToString(); });
            List<int> myStringList = l2.Select(s => int.Parse(s)).ToList();
            config.my_launchersettings = l2;
            SerializeConfig(config);
            if(Global.crashdata==1)
            {
                args = "--crash_data_log";

            }
            if (Global.debug == 1)
            {

                args += "--debug";

            }
            if (Global.debugsaves>0)
            {

                args += "--autosave_count="+ Global.debugsaves;

            }
            if (Global.randomlog > 0)
            {

                args += "--hotjoinlog";

            }
            if (Global.nakama == 1)
            {

                args += " --nakama";

            }
            Process.Start(@"hoi4.exe", args);
            Application.Exit();
        }

        private void unselect_mods(object sender, EventArgs e)
        {
            while (list_mods.CheckedIndices.Count > 0)
                list_mods.SetItemChecked(list_mods.CheckedIndices[0], false);
        }

        private void open_save(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @Hoi4_Saves);
        }

        private void vanilla(object sender, EventArgs e)
        {

            List<newModInfo> mods = new List<newModInfo>();
            DirectoryInfo d = new DirectoryInfo(Hoi4_Mods);
            DirectoryInfo c = new DirectoryInfo(Workshop);
            DirectoryInfo[] Folders = c.GetDirectories();
            FileInfo[] Files = d.GetFiles("*ugc");
            foreach (FileInfo file in Files)
            {
                if (Folders.Any(r => r.FullName.Equals(file.FullName.Replace("ugc_","")))==false)
                {
                    File.Delete(file.FullName);
                }
            }
        }
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            launchSettings items = load_items();
            List<newModInfo> mods = load_mods_info();

            list_mods2.Items.Clear();
            foreach (newModInfo mod in mods)
            {
                bool enabled = false;
                if (items.enabled_mods.Contains(mod.gameRegestryMod)) { enabled = true; }
                list_mods2.Items.Add(mod.displayName, enabled);
            }

            if (textBox2.Text.Length > 0)
            {
                list_mods2.Visible = true;
                list_mods.Visible = false;
                List<string> removals = new List<string>();
                foreach (string s in list_mods2.Items)
                {
                    if (!s.ToUpper().Contains(textBox2.Text.ToUpper()))
                   
                        {
                        removals.Add(s);
                    }

                }
                foreach (string s in removals)
                {
                    list_mods2.Items.Remove(s);
                }



            }
            else {
                list_mods2.Visible = false;
                list_mods.Visible = true;
            }
        }

        private void list_mods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void list_mods2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       

        private void list_mods2_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            bool status=false;
            if (e.CurrentValue == CheckState.Unchecked)
            {
                status = true;
            }
            else if ((e.CurrentValue == CheckState.Checked))
            {
                status = false;
            }
            //Logger("Hallo");
            string curItem = list_mods2.Items[e.Index].ToString();
            int index = list_mods.FindString(curItem);
            // If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
            list_mods.SetItemChecked(index, status);
          //  list_mods.SetSelected(index, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(Workshop);
            DirectoryInfo[] Files = d.GetDirectories();
            foreach (DirectoryInfo file in Files)
            {
                if (long.TryParse(file.Name, out _))
                {
                    string descriptorname = "ugc_" + file.Name;
                    FileInfo[] descriptor = file.GetFiles("*.mod");
                    if (descriptor.Length > 0)
                    {
                        //if (mod.gameRegestryMod == "mod/ugc_1368243403.mod")
                        //{
                        //    Debugger.Break();
                        //}
                        string[] modFiles = File.ReadAllLines(descriptor[0].FullName);
                        Array.Resize(ref modFiles, modFiles.Length + 1);
                        modFiles[modFiles.Length - 1] = modFiles[modFiles.Length - 2];
                        modFiles[modFiles.Length - 2] = "path=\"" + file.FullName.Replace("\\", "/") + "\"";
                        File.WriteAllLines(Path.Combine(Hoi4_Mods, descriptorname + ".mod"), modFiles, Encoding.UTF8);
                    }
                }
                
            }
            launchSettings items = load_items();
            List<newModInfo> mods = load_mods_info();
            int enabled_mods = 0;
            foreach (newModInfo mod in mods)
            {
                bool enabled = false;
                if (items.enabled_mods.Contains(mod.gameRegestryMod)) { enabled = true; enabled_mods++; }
                if (list_mods.Items.Contains(mod.displayName) == false)
                { list_mods.Items.Add(mod.displayName, enabled);
                }
            }
            modsCount = mods.Count;
            updateModsCount(enabled_mods, modsCount);
        }

        private void launch_vanilla(object sender, EventArgs e)
        {
            List<string> enabled_mods = new List<string>();
            List<string> disabled_dlc = new List<string>();
            launchSettings config = load_items();
            config.enabled_mods = enabled_mods;
            config.disabled_dlcs = disabled_dlc;
            var numbers2 = new List<int>() { Global.debug, Global.crashdata, Global.randomlog, Global.debugsaves };
            List<string> l2 = numbers2.ConvertAll<string>(delegate (int i) { return i.ToString(); });
            List<int> myStringList = l2.Select(s => int.Parse(s)).ToList();
            config.my_launchersettings = l2;
            SerializeConfig(config);
            Process.Start(@"hoi4.exe");
        }

        private void updateworkshopbutton_Click(object sender, EventArgs e)
        {
            List<newModInfo> mods = load_mods_info();
            newModInfo mod = mods.Find(x => x.displayName == list_mods.CheckedItems[0].ToString());
            Logger(mod.remote_fileid);
            Logger(mod.modfolder);
            UpdateWorkshopContent(ulong.Parse(mod.remote_fileid), mod.modfolder);
            while (!Global.updateComplete)
            {
                SteamAPI.RunCallbacks();
                Thread.Sleep(1000);
            }
        }

        private void nakama_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                Global.nakama = 1;
            }
            else
            {
                Global.nakama = 0;
            }
        }
    }

    internal class Uint32
    {
    }
}
public static class ISynchronizeInvokeExtensions
{
    public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
    {
        if (@this.InvokeRequired)
        {
            @this.Invoke(action, new object[] { @this });
        }
        else
        {
            action(@this);
        }
    }
}
