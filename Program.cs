using KukaRoboter.OnlineServicesFacade;
using System;
using System.IO;

namespace ArchivadoRemoto
{
    class Program
    {
        static void Main()
        {
            const int entrada = 100;
            string backupDir = $@"D:\{DateTime.Now:MM/dd/yyyyHH:mm}BackupAll.zip";
            ArchiveFacade a = new ArchiveFacade();

            while (true)
                if (Cross3.SyncVar.ShowVar($"$IN[{entrada}]") == "TRUE")
                {
                    if (File.Exists(backupDir))
                    {
                        File.Delete(backupDir);
                    }
                    a.ArchiveAll(backupDir);

                    System.Threading.Thread.Sleep(5000);
                }
        }
    }
}


