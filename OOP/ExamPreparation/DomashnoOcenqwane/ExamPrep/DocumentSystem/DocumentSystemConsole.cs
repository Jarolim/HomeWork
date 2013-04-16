using System;
using System.Collections.Generic;

namespace DocumentSystem
{

    public class DocumentSystemConsole
    {
       private static IList<IDocument> documents = new List<IDocument>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);
          /*  TextDocument doc = new TextDocument();
            foreach (var attrib in attributes)
            {
                string[] tokens = attrib.Split('=');
                string propName = tokens[0];
                string propValue = tokens[1];
                doc.LoadProperty(propName, propValue);
            }
            if (doc.Name != null)
            {
                documents.Add(doc);
                Console.WriteLine("Document added : " + doc.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }*/
            
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
            
        }

        private static void AddDocument(IDocument doc, string[] attributes)
        {
            foreach (var attrib in attributes)
            {
                string[] tokens = attrib.Split('=');
                string propName = tokens[0];
                string propValue = tokens[1];
                doc.LoadProperty(propName, propValue);
            }
            if (doc.Name != null)
            {
                documents.Add(doc);
                Console.WriteLine("Document added : " + doc.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            // TODO
        }

        private static void AddAudioDocument(string[] attributes)
        {
            // TODO
        }

        private static void AddVideoDocument(string[] attributes)
        {
            // TODO
        }

        private static void ListDocuments()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found!");
            }
            else
            {
                foreach (var doc in documents)
                {
                    Console.WriteLine(doc);
                }
            }
        }

        private static void EncryptDocument(string name)
        {
            // TODO
        }

        private static void DecryptDocument(string name)
        {
            // TODO
        }

        private static void EncryptAllDocuments()
        {
            // TODO
        }

        private static void ChangeContent(string name, string content)
        {
            // TODO
        }
    }
}
