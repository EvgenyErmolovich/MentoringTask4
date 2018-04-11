using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Task.Configuration;

namespace Task
{
    class Program
    {
        private static SimpleConfigurationSection _section;
        private static bool _cancelled;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleCancelKeyPress);
            _section = (SimpleConfigurationSection)ConfigurationManager.GetSection("simpleSection");

            var watchers = new List<FileSystemWatcher>();
            foreach (DirectoryElement dir in _section.Directories)
            {
                var watcher = new FileSystemWatcher(dir.DirectoryPath);
                watcher.IncludeSubdirectories = true;
                watcher.NotifyFilter = NotifyFilters.FileName;
                watcher.Created += WatcherCreated;
                watcher.EnableRaisingEvents = true;
                watchers.Add(watcher);
            }

            while (!_cancelled)
            { }
        }

        private static void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Cancelling");
            if (e.SpecialKey == ConsoleSpecialKey.ControlC || e.SpecialKey == ConsoleSpecialKey.ControlBreak)
            {
                _cancelled = true;
                e.Cancel = true;
            }
        }

        private static void WatcherCreated(object sender, FileSystemEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_section.CultureInfo.Culture);

            Console.WriteLine(Resources.FindedFile + e.FullPath + " " + new FileInfo(e.FullPath).CreationTime.ToString(new CultureInfo(_section.CultureInfo.Culture)));

            var directory = _section.DefaultPath.Path;
            foreach (RuleElement rule in _section.Rules)
            {
                Regex regex = new Regex(rule.Pattern);
                if (regex.Matches(e.Name).Count > 0)
                {
                    directory = rule.Path;
                    Console.WriteLine(Resources.FindedRule + rule.Pattern);
                    break;
                }
            }

            var fullName = e.Name;
            if (_section.Options.AddDate) fullName = DateTime.Today.ToString("dd.MM.yyyy") + " " + fullName;
            if (_section.Options.AddNumber) fullName = new DirectoryInfo(directory).GetFiles().Length + " " + fullName;
            if (File.Exists(directory + @"\" + fullName)) fullName = new DirectoryInfo(directory).GetFiles().Length + " " + fullName;
            fullName = directory + @"\" + fullName;

            File.Move(e.FullPath, fullName);
            Console.WriteLine(Resources.FileMovedTo + fullName);
        }
    }
}


