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
            const string backupDir = @"D:\BackupAll.zip";
            ArchiveFacade a = new ArchiveFacade();
            bool backupDone = false;
            Console.WriteLine($"Esperando entrada {entrada}");
            while (true)
            {
                if (backupDone)
                {
                    Console.WriteLine($"Esperando entrada {entrada}");
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);

                    backupDone = false;
                }

                if (Cross3.SyncVar.ShowVar($"$IN[{entrada}]") != "TRUE") continue;
                Console.WriteLine("Haciendo archivado...");
                string backupDirDt = $@"D:\{DateTime.Now:yyyyMMddhhmm}BackupAll.zip";
                try
                {
                    if (File.Exists(backupDir)){File.Delete(backupDir);}
                    if (File.Exists(backupDirDt)){File.Delete(backupDirDt);}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                try
                {
                    a.ArchiveAll(backupDir);
                    Console.WriteLine($"Archivado con exito como {backupDirDt}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                try
                {
                    File.Move(backupDir, backupDirDt);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                    
                backupDone = true;
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}


