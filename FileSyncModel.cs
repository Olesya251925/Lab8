using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileSyncApp
{
    public class FileSyncModel
    {
        private string sourceDirectory;
        private string destinationDirectory;
        private FileSystemWatcher fileWatcher;
        private HashSet<string> processedFiles;

        public FileSyncModel(string sourceDirectory, string destinationDirectory)
        {
            this.sourceDirectory = sourceDirectory;
            this.destinationDirectory = destinationDirectory;

            InitializeFileWatcher();
            processedFiles = new HashSet<string>();
        }

        private void InitializeFileWatcher()
        {
            fileWatcher = new FileSystemWatcher(sourceDirectory);
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.Created += OnFileCreated;
            fileWatcher.Deleted += OnFileDeleted;
            fileWatcher.Renamed += OnFileRenamed;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            if (!processedFiles.Contains(e.Name))
            {
                string status = $"Файл создан: {e.Name}";
                DisplayStatus(status);
                processedFiles.Add(e.Name);
            }
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            string status = $"Файл удален: {e.Name}";
            DisplayStatus(status);
            processedFiles.Remove(e.Name);
        }

        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            if (!processedFiles.Contains(e.Name))
            {
                string status = $"Файл переименован: {e.OldName} -> {e.Name}";
                DisplayStatus(status);
                processedFiles.Remove(e.OldName);
                processedFiles.Add(e.Name);
            }
        }

        private void DisplayStatus(string status)
        {
            MessageBox.Show(status);
        }

        public string CheckChanges()
        {
            string status = "";

            if (!Directory.Exists(sourceDirectory) || !Directory.Exists(destinationDirectory))
            {
                status =
                "Исходный или конечный каталог не существует.";
            }
            else
            {
                // Проверка наличия созданных файлов
                string[] sourceFiles = Directory.GetFiles(sourceDirectory);
                string[] destinationFiles = Directory.GetFiles(destinationDirectory);

                foreach (string file in sourceFiles)
                {
                    string fileName = Path.GetFileName(file);
                    if (!Array.Exists(destinationFiles, f => Path.GetFileName(f) == fileName))
                    {
                        status += $"Файл создан: {fileName}\n" + Environment.NewLine;
                    }
                }

                // Проверка наличия измененных файлов
                foreach (string file in sourceFiles)
                {
                    string fileName = Path.GetFileName(file);
                    string sourceFilePath = Path.Combine(sourceDirectory, fileName);
                    string destinationFilePath = Path.Combine(destinationDirectory, fileName);

                    if (File.Exists(destinationFilePath))
                    {
                        DateTime sourceLastWriteTime = File.GetLastWriteTime(sourceFilePath);
                        DateTime destinationLastWriteTime = File.GetLastWriteTime(destinationFilePath);

                        if (sourceLastWriteTime > destinationLastWriteTime)
                        {
                            status += $"Файл изменен: {fileName}\n" + Environment.NewLine;
                        }
                    }
                }

                // Проверка наличия удаленных файлов
                foreach (string file in destinationFiles)
                {
                    string fileName = Path.GetFileName(file);
                    if (!Array.Exists(sourceFiles, f => Path.GetFileName(f) == fileName))
                    {
                        status += $"Файл удален: {fileName}\n";
                    }
                }

                // Проверяет, скопированы ли файлы на флэш-накопитель
                string[] flashDriveFiles = Directory.GetFiles("F:\\Forms1");

                foreach (string file in flashDriveFiles)
                {
                    string fileName = Path.GetFileName(file);
                    status += $"Файл скопирован на флеш-накопитель: {fileName}\n" + Environment.NewLine;
                }
            }

            return status;
        }
    }
}
