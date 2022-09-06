// Copyright Myrkur @2022

using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using Microsoft.Win32;

namespace EZ2CoopInstaller;

public class EZ2COOPInstaller
{
    static void Main(string[] args)
    {
        if (!IsAdministrator())
        {
            Console.WriteLine("This application must be run as administrator to create the symlink...\nPlease exist and run as administrator.");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
        // var rundirectory = Directory.GetCurrentDirectory();
        
        // Get SourcemodPath from registry
        RegistryKey registryKeySmodInstall = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
        var SModInstall = registryKeySmodInstall.GetValue("SourceModInstallPath","");
        
        // Get steamPath from registry
        RegistryKey registryKeySteamInstall = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
        var SteamInstall = registryKeySteamInstall.GetValue("SteamPath","");
        
        Console.WriteLine($"SourceModsPath: {SModInstall}");

        // steampath to EntropyZ2
        var steampath = SteamInstall + "/steamapps/common/EntropyZero2";

        var workshoppath = SteamInstall + "/steamapps/workshop/content/1583720/2856851374";
        var workshopdatapath = SteamInstall + "/steamapps/workshop/content/1583720/2856851374/ez2coop";

        Console.WriteLine($"SteamPath: {steampath}");


        #region Funny string builder

        var generategametext = new StringBuilder();

        generategametext.AppendLine("\"GameInfo\"");
        generategametext.AppendLine("{");
        generategametext.AppendLine("\tgame \t\t\"Entropy : Zero 2 Coop Mod\"");
        generategametext.AppendLine("\ttitle \t\t\"E N T R O P Y : Z E R O  2\"");
        generategametext.AppendLine("\ttitle2\t\t\"\"");
        generategametext.AppendLine("\tsupportsvr\t0");
        generategametext.AppendLine("\tGameData\t\"bin/EntropyZero2.fgd\"");
        generategametext.AppendLine("\ttype\t\tsingleplayer_only");
        generategametext.AppendLine("\ticon \"resource/ez_icon\"");
        generategametext.AppendLine("\tFileSystem");
        generategametext.AppendLine("\t{");
        generategametext.AppendLine("\t\tSteamAppId\t\t\t\t1583720");
        generategametext.AppendLine("\t\tSearchPaths");
        generategametext.AppendLine("\t\t{");
        generategametext.AppendLine("\t\t\tgame+mod+addon\t\t\t\"%ABS_PATH%entropyzero2/custom/*\"");
        generategametext.AppendLine("\t\t\tgame+mod+addon\t\t\t\"%ABS_PATH%ep2/custom/*\"");
        generategametext.AppendLine("\t\t\tgame+mod+addon\t\t\t\"%ABS_PATH%episodic/custom/*\"");
        generategametext.AppendLine("\t\t\tgame+mod+addon\t\t\t\"%ABS_PATH%hl2/custom/*\"");
        generategametext.AppendLine("\t\t\tgame+mod+addon\t\t\t\"%ABS_PATH2%*\"");
        generategametext.AppendLine("\t\t\tgame+mod+addon\t\t\"%ABS_PATH%entropyzero2\"");
        generategametext.AppendLine("\t\t\tgame+mod+mod_write+default_write_path\t\t|gameinfo_path|.");
        generategametext.AppendLine("\t\t\tgamebin\t\t\t\t|gameinfo_path|bin");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%entropyzero2/ez2/*\"");
        generategametext.AppendLine("\t\t\tgamebin\t\t\t\t\"%ABS_PATH%mapbase/episodic/bin\"");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%mapbase/episodic/*\"");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%mapbase/hl2/*\"");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%mapbase/css_weapons_in_hl2\"");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%mapbase/css_weapons_in_hl2/content/*\"");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%mapbase/shared/shared_content_v7_0.vpk\"");
        generategametext.AppendLine("\t\t\tgame_lv\t\t\t\t\"%ABS_PATH%hl2/hl2_lv.vpk\"");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%ep2/ep2_english.vpk\"");
        generategametext.AppendLine("\t\t\tgame+mod\t\t\t\"%ABS_PATH%ep2/ep2_pak.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%episodic/ep1_english.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%episodic/ep1_pak.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%hl2/hl2_english.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%hl2/hl2_pak.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%hl2/hl2_textures.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%hl2/hl2_sound_vo_english.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%hl2/hl2_sound_misc.vpk\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%hl2/hl2_misc.vpk\"");
        generategametext.AppendLine("\t\t\tplatform\t\t\t\"%ABS_PATH%platform/platform_misc.vpk\"");
        generategametext.AppendLine("\t\t\tgame+game_write\t\t\"%ABS_PATH%ep2\"");
        generategametext.AppendLine("\t\t\tgamebin\t\t\t\t\"%ABS_PATH%episodic/bin\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%episodic\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%hl2\"");
        generategametext.AppendLine("\t\t\tgame\t\t\t\t\"%ABS_PATH%platform\"");
        generategametext.AppendLine("\t\t}");
        generategametext.AppendLine("\t}");
        generategametext.AppendLine("}");
        generategametext.Replace("%ABS_PATH%", $"{steampath}\\");



        #endregion

        if (!Directory.Exists(workshopdatapath))
        {
            Console.WriteLine("Path to mod doesnt exist, did you subscribe to workshop addon?");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
        var ez2cooppath = SModInstall + "\\ez2coop";
        
        Console.WriteLine($"Workshopdatapath: {workshopdatapath}");

        if (!Directory.Exists(ez2cooppath))
        {
            Console.WriteLine("EZ2CoopPath: Doesnt exists... creating");
            Directory.CreateSymbolicLink(ez2cooppath, workshopdatapath);
        }
        else
        {
            Console.WriteLine("EZ2CoopPath: exists... re-creating");
            Directory.Delete(ez2cooppath,true);
            Directory.CreateSymbolicLink(ez2cooppath, workshopdatapath);
        }

        var ez2coopGameInfo = workshoppath + "\\ez2coop" + "\\gameinfo.txt";

        if (!File.Exists(ez2coopGameInfo))
        {
            Console.WriteLine("GameInfo: Doesnt exists... creating");
            using (StreamWriter writer = new StreamWriter($"{ez2coopGameInfo}"))
            {
                writer.WriteLine(generategametext);
            }
        }
        else
        {
            Console.WriteLine("GameInfo: exists... re-creating");
            File.Delete(ez2coopGameInfo);
            using (StreamWriter writer = new StreamWriter($"{ez2coopGameInfo}"))
            {
                writer.WriteLine(generategametext);
            }
        }
        
        
        
        Console.WriteLine("all operations completed successfully");
        
        Thread.Sleep(5000);
        Environment.Exit(0);
    }

    private static bool IsAdministrator()
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}