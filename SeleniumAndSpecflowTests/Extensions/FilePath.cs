using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumAndSpecflowTests.Extensions
{
    public class FilePath
    {
        public string ReturnCurrentDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string currentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            return currentDirectory;
        }

        public string ReturnCombinedFilePathFromCurrentDirectory(string filePath)
        {
            return Path.Combine(ReturnCurrentDirectory(), filePath);
        }
    }
}
