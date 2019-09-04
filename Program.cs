using KukaRoboter.OnlineServicesFacade;
using System;
using System.IO;

namespace ArchivadoRemoto
{
    class Program
    {
        static void Main()
        {
            int entrada = Convert.ToInt32(Cross3.SyncVar.ShowVar("$inBckpPlc"));
            const string backupDir = @"D:\BackupAll.zip";
            string robName = StringManipulation.GetBetween(Cross3.SyncVar.ShowVar("$robname[]"), "\"", "\"");

            ArchiveFacade a = new ArchiveFacade();

            if (!Directory.Exists(@"D:\PlcBackups")) Directory.CreateDirectory(@"D:\PlcBackups");

            do
            {
                if (Cross3.SyncVar.ShowVar($"$IN[{entrada}]") != "TRUE") continue;

                string backupDirDt = $@"D:\PlcBackups\{DateTime.Now:yyyyMMddhhmm}{robName}.zip";

                if (File.Exists(backupDir)) File.Delete(backupDir);
                if (File.Exists(backupDirDt)) File.Delete(backupDirDt);

                a.ArchiveAll(backupDir);

                File.Move(backupDir, backupDirDt);

            } while (true);
        }
    }

}


