using System;
using System.Collections;
using System.IO;
using NUnit.Framework;

namespace NotePad
{
    public class CustomerTest
    {
        TextModel model;
        [SetUp]
        public void SetUp()
        {
            model = new TextModel();
        }

        [Test]
        public void FileInput()
        {
            using (var streamReader = File.OpenText(@".\data\fileInput.txt"))
            {
                var contents = streamReader.ReadToEnd();
                InterpretCommands(contents);
            }
        }

        [Test]
        public void TestAllFiles()
        {
            var testFiles = Directory.GetFiles(@".\data\", "*.test");
            
            Assert.AreEqual(1, testFiles.Length);
            foreach (var testFile in testFiles)
            {
                InterpretFileInput(testFile);
            }
        }

        private void InterpretFileInput(string fileName)
        {
            using(var stream = File.OpenText(fileName))
            {
                var contents = stream.ReadToEnd();
                InterpretFileInput(contents);
            }
        }


        [Test]
        public void StringInput()
        {
            string commands = "*input\n some line\n *end\n *enter\n *display\n *output\n some line\n <P>|</P>";

            InterpretCommands(commands);
        }

        void InterpretCommands(string commands)
        {
            var reader = new StringReader(commands);
            var line = reader.ReadLine();

            while (line != null)
            {
                if (line == "*enter")
                {
                    model.Enter();
                }

                if (line == "*display")
                {
                    Console.WriteLine("display\r\n{0}\r\nend", model.TestText);
                }

                if (line == "*output")
                {
                    CompareOutput(reader);
                }

                if (line == "*input")
                {
                    SetInput(reader);
                }
                line = reader.ReadLine();
            }
        }

        void SetInput(StringReader reader)
        {
            var input = new InputCommand(reader);
            model.Lines = input.CleanLines();
        }

        private int CursorLocation(string[] input)
        {
            throw new NotImplementedException();
        }

        private string[] CleanLines(string[] input)
        {
            throw new NotImplementedException();
        }

        string[] ArrayToEnd(StringReader reader)
        {
            ArrayList result = new ArrayList();  
            string line = reader.ReadLine();
            while (line != null && line != "*end")
            {
                result.Add(line.TrimEnd());
                line = reader.ReadLine();
            }  
            string[] answer = new string[result.Count];  
            result.CopyTo(answer);
            return answer;
        }

        void CompareOutput(StringReader reader, string message)
        {
            string expected = ExpectedOutput(reader);  
            
            Assert.AreEqual(message, expected, model.TestText);
        }

        void CompareOutput(StringReader reader)
        {
            CompareOutput(reader, String.Empty);
        }

        string ExpectedOutput(StringReader reader)
        {
            return ReadToEnd(reader);
        }

        string ReadToEnd(StringReader reader)
        {
            string result = "";  
            string line = reader.ReadLine();
            while (line != null && line != "*end")
            {
                result += line;    result += System.Environment.NewLine;    
                line = reader.ReadLine();
            }  
            return result;
        }
    }
}