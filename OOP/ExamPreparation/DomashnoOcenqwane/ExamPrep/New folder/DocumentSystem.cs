using System;
using System.Collections.Generic;
using System.Linq;

public class DocumentSystem
{
    private static List<IDocument> documents = new List<IDocument>();

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader(@"..\..\DocumentSystem-Tests\test.003.in.txt"));
        //System.IO.StreamWriter writer = new System.IO.StreamWriter("../../DocumentSystem-Tests/test.003.txt");
        //    Console.SetOut(writer);

#endif

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

    private static void AddDocument(IDocument document, string[] attributes)
    {
        foreach (var attr in attributes)
        {
            string[] property = attr.Split('=');
            string key = property[0];
            string value = property[1];

            document.LoadProperty(key, value);
        }

        if (document.Name == null || document.Name == "")
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        //Console.WriteLine("Test");
    }

    private static string ParseDocumentName(string[] attributes)
    {
        IList<KeyValuePair<string, string>> props = new List<KeyValuePair<string, string>>();
        foreach (var item in attributes)
        {
            string[] properties = item.Split('=');
            string key = properties[0];
            string value = properties[1];
            props.Add(new KeyValuePair<string, string>(key, value));
        }

        var result = props.Where(x => x.Key == "name").Select(x => x.Value).FirstOrDefault();
        if (result == null)
        {
            return "";
        }

        return result.ToString();
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(ParseDocumentName(attributes)), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(ParseDocumentName(attributes)), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(ParseDocumentName(attributes)), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(ParseDocumentName(attributes)), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(ParseDocumentName(attributes)), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(ParseDocumentName(attributes)), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (IDocument item in documents)
            {

                Console.WriteLine(item.ToString());
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        var document =
            (from doc in documents
             where doc.Name == name
             select doc).ToList();

        if (document.Count == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
        else
        {
            foreach (Document item in document)
            {
                if (item is EncryptableBinaryDocument)
                {
                    (item as EncryptableBinaryDocument).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", name);
                }
            }
        }
    }

    private static void DecryptDocument(string name)
    {
        var document =
            (from doc in documents
             where doc.Name == name
             select doc).ToList();

        if (document.Count == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
        else
        {
            foreach (Document item in document)
            {
                if (item is EncryptableBinaryDocument)
                {
                    (item as EncryptableBinaryDocument).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", name);
                }
            }
        }
    }

    private static void EncryptAllDocuments()
    {
        var document =
            (from doc in documents
             where (doc is EncryptableBinaryDocument)
             select doc).ToList();

        if (document.Count == 0)
        {
            Console.WriteLine("No encryptable documents found");
        }
        else
        {
            foreach (EncryptableBinaryDocument item in document)
            {
                item.Encrypt();
            }
            Console.WriteLine("All documents encrypted");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        var document =
            (from doc in documents
             where doc.Name == name
             select doc).ToList();

        if (document.Count == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
        else
        {
            foreach (Document item in document)
            {
                if (item is IEditable)
                {
                    (item as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", name);
                }
            }
        }
    }
}


