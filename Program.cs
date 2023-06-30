using System;
using System.Diagnostics;
using System.IO;

namespace BoxesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();

            // Inserting boxes into the storage
            storage.AddBox(new Box(11.0, 20.0));
            storage.AddBox(new Box(11.0, 22.0));
            storage.AddBox(new Box(11.0, 19.0));
            storage.AddBox(new Box(15.0, 25.0));
            storage.AddBox(new Box(12.0, 34.0));
            storage.AddBox(new Box(8.0, 15.0));
            storage.AddBox(new Box(22, 34.0));
            storage.AddBox(new Box(22, 17.0));
            storage.AddBox(new Box(44.0, 31.0));
            storage.AddBox(new Box(18.0, 15.0));

            // Generate the PlantUML code for the tree
            string plantUmlCode = GeneratePlantUml(storage.avlTree.root);

            // Save the PlantUML code to a file
            string plantUmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tree.uml");
            File.WriteAllText(plantUmlFilePath, plantUmlCode);

            // Generate the image using PlantUML command-line tool
            string outputImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tree.png");
            string plantUmlJarPath = @"C:\Users\itama\Downloads\plantuml-1.2023.9.jar";
            string arguments = $"-tpng \"{plantUmlFilePath}\" -o \"{outputImagePath}\"";

            var processStartInfo = new ProcessStartInfo("java", $"-jar \"{plantUmlJarPath}\" {arguments}")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
            }

            Console.WriteLine("Output Path: " + outputImagePath);

            Console.WriteLine("Image generated successfully.");
        }

        static string GeneratePlantUml(Node node)
        {
            if (node == null)
                return string.Empty;

            string plantUml = "@startuml\n";
            GeneratePlantUmlRecursive(node, ref plantUml);
            plantUml += "@enduml";
            return plantUml;
        }

        static void GeneratePlantUmlRecursive(Node node, ref string plantUml)
        {
            if (node == null)
                return;

            plantUml += $"class {node.Box}\n";
            if (node.Left != null)
                plantUml += $"{node.Box} --> {node.Left.Box}\n";
            if (node.Right != null)
                plantUml += $"{node.Box} --> {node.Right.Box}\n";

            GeneratePlantUmlRecursive(node.Left, ref plantUml);
            GeneratePlantUmlRecursive(node.Right, ref plantUml);
        }
    }
}
