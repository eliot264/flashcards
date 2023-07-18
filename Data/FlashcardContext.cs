using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards.Data
{
    public class FlashcardContext
    {
        private List<Set> _sets;
        public List<Set> Sets => _sets;

        public FlashcardContext()
        {
            _sets = new List<Set>();
            LoadSetData();
        }

        public void ReloadData()
        {
            _sets.Clear();
            LoadSetData();
        }

        private void LoadSetData()
        {
            string path = @"./sets";

            if (Directory.Exists(path))
            {
                var files = Directory.EnumerateFiles(path);

                if (files.Count() > 0)
                {
                    foreach (var file in files)
                    {
                        try
                        {
                            Set set = Newtonsoft.Json.JsonConvert.DeserializeObject<Set>(File.ReadAllText(file));
                            _sets.Add(set);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("File " + file + " is invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
