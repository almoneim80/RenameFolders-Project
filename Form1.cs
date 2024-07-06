using SharpCompress.Archives;
using SharpCompress.Common;

namespace RenameFolders
{
    public partial class Form1 : Form
    {
        string folderPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowesBTN_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowes = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowes.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowes.SelectedPath))
                {
                    folderPath = folderBrowes.SelectedPath;
                    FolderNameLBL.Text = folderPath;
                }
            }
        }

        private async void RunBTN_Click(object sender, EventArgs e)
        {
            await DoRename(folderPath);
        }

        public async Task DoRename(string parentFolderPath)
        {
            if (Directory.Exists(parentFolderPath) && !string.IsNullOrWhiteSpace(FolderNameLBL.Text))
            {
                try
                {
                    string[] subdirectories = Directory.GetDirectories(parentFolderPath);

                    foreach (string subdirectory in subdirectories)
                    {
                        
                        string[] folderFullName = subdirectory.Split('-');

                        if (folderFullName.Length < 2)
                        {
                            MessageBox.Show("Folder does'n has version. try fix it and try again");
                            StatusLBL.Text = "";
                            FolderNameLBL.Text = "";
                            MessageBox.Show("Process failed.");
                            return;
                        }

                        StatusLBL.Text = "Wait...";
                        string Name = folderFullName[0].Trim();
                        string Version = folderFullName[folderFullName.Length - 1].Trim();


                        //rename the folder
                        string currentFolderPath = subdirectory;
                        string newFolderPath = Path.Combine(Path.GetDirectoryName(currentFolderPath), Name);
                        string newInsideFolder = null;

                        if (Directory.Exists(newFolderPath))        //ÇÐÇ æÌÏ ãÌáÏ ÈäÝÓ ÇáÇÓã íÊã ÇäÔÇÁ ãÌáÏ ÈÃÓã ÇáÇÕÏÇÑ ÈÏÇÎá ÇáãÌáÏ ÇáãæÌæÏ
                        {
                            newFolderPath = Path.Combine(newFolderPath, Version);
                            Directory.CreateDirectory(newFolderPath);
                            newInsideFolder = newFolderPath;

                            //cut files inside new folder
                            if (Directory.GetFiles(currentFolderPath).Length != 0)   //íÝÍÕ ãÍÊæì ÇáãÌáÏ ÇáÐí ÊãÊ ÇÚÇÏÉ ÊÓãíå
                            {
                                foreach (string currentFilePath in Directory.GetFiles(currentFolderPath))
                                {
                                    string fileName = Path.GetFileName(currentFilePath);
                                    string newFilePath = Path.Combine(newInsideFolder, fileName);
                                    File.Move(currentFilePath, newFilePath);
                                }
                            }
                            else
                                MessageBox.Show($"There is no files inside Folder: {Name}");


                            if (Directory.GetDirectories(currentFolderPath).Length != 0)
                            {
                                foreach (string oldDirectory in Directory.GetDirectories(currentFolderPath))
                                {
                                    string folderName = new DirectoryInfo(oldDirectory).Name;
                                    if (oldDirectory != newInsideFolder)
                                    {
                                        string newDirectory = Path.Combine(newInsideFolder, folderName);
                                        Directory.Move(oldDirectory, newDirectory);
                                    }
                                }
                            }
                            else
                                MessageBox.Show($"There is no sub folders inside Folder: {Name}");

                            //Compress Folder
                            await CompressFolder(newInsideFolder);

                            Directory.Delete(newInsideFolder, true);
                            Directory.Delete(currentFolderPath, true);
                        }
                        else                                             //æÇáÇ íÊã ÇÚÇÏÉ ÊÓãíÉ ÇáãÌáÏ ãÚ ÍÐÝ ÇáÇÕÏÇÑ ãä ÇáÇÓã
                        {
                            Directory.Move(currentFolderPath, newFolderPath);

                            //åäÇ Ýí ÍÇáÉ Çäå Êã ÇÚÇÏÉ ÊÓãíÉ ÇáãÌáÏ ÈäÌÇÍ íÊã ÇäÔÇÁ ãÌáÏ ÇáÇÕÏÇÑ ÈÏÇÎá ÇáãÌáÏ ÇáÐí ÊãÊ ÇÚÇÏÉ ÊÓíÊå
                            //create new folder
                            newInsideFolder = Path.Combine(newFolderPath, Version);
                            if (Directory.Exists(newInsideFolder))
                            {
                                MessageBox.Show($"Folder {Version} is exists. Do you want to delete it");
                            }
                            else
                            {
                                Directory.CreateDirectory(newInsideFolder);
                            }

                            //cut files inside new folder
                            if (Directory.GetFiles(newFolderPath).Length != 0)   //íÝÍÕ ãÍÊæì ÇáãÌáÏ ÇáÐí ÊãÊ ÇÚÇÏÉ ÊÓãíå
                            {
                                foreach (string currentFilePath in Directory.GetFiles(newFolderPath))
                                {
                                    string fileName = Path.GetFileName(currentFilePath);
                                    string newFilePath = Path.Combine(newInsideFolder, fileName);
                                    File.Move(currentFilePath, newFilePath);
                                }
                            }
                            else
                                MessageBox.Show($"There is no files inside Folder: {Name}");


                            if (Directory.GetDirectories(newFolderPath).Length != 0)
                            {
                                foreach (string oldDirectory in Directory.GetDirectories(newFolderPath))
                                {
                                    string folderName = new DirectoryInfo(oldDirectory).Name;
                                    if (oldDirectory != newInsideFolder)
                                    {
                                        string newDirectory = Path.Combine(newInsideFolder, folderName);
                                        Directory.Move(oldDirectory, newDirectory);
                                    }
                                }
                            }
                            else
                                MessageBox.Show($"There is no sub folders inside Folder: {Name}");


                            //Compress Folder
                            await CompressFolder(newInsideFolder);
                            Directory.Delete(newInsideFolder, true);
                        }
                    }
                    StatusLBL.Text = "";
                    FolderNameLBL.Text = "";
                    MessageBox.Show("Process completed.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        //Compress method
        public async Task CompressFolder(string path)
        {
            string tarFilePath = path + ".tar";

            if (File.Exists(tarFilePath))
            {
                MessageBox.Show("Compressed folder already exists.");
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    using (var archive = ArchiveFactory.Create(ArchiveType.Tar))
                    {
                        Stack<(string directoryPath, string relativePath)> stack = new Stack<(string directoryPath, string relativePath)>();
                        stack.Push((path, ""));

                        while (stack.Count > 0)
                        {
                            var (currentDirectory, currentRelativePath) = stack.Pop();

                            foreach (string filePath in Directory.GetFiles(currentDirectory))
                            {
                                archive.AddEntry(Path.Combine(currentRelativePath, Path.GetFileName(filePath)), filePath);
                            }

                            foreach (string subdirectoryPath in Directory.GetDirectories(currentDirectory))
                            {
                                stack.Push((subdirectoryPath, Path.Combine(currentRelativePath, Path.GetFileName(subdirectoryPath))));
                            }
                        }

                        archive.SaveTo(tarFilePath, CompressionType.None);
                    }

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}
