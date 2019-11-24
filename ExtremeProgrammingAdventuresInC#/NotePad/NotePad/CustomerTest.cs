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
        public void EmptyModel()
        {
            model.Enter();  
            Assert.AreEqual("<P>|</P>\r\n", model.TestText);
        }

        [Test]
        [Ignore("not current directory")]
        public void TestAllFiles()
        {
            var testFiles = Directory.GetFiles(@".\data\", "*.test");
            
            Assert.AreEqual(1, testFiles.Length);
            foreach (var testFile in testFiles)
            {
                InterpretFileInput(testFile);
            }
        }
        
        [Test]
        [Ignore("not current directory")]
        public void FileInput()
        {
            using (var streamReader = File.OpenText(@".\data\fileInput.txt"))
            {
                var contents = streamReader.ReadToEnd();
                InterpretCommands(contents, "fileInput.txt");
            }
        }

        private void InterpretFileInput(string fileName)
        {
            using(var stream = File.OpenText(fileName))
            {
                var contents = stream.ReadToEnd();
                InterpretCommands(contents, fileName);
            }
        }

        void InterpretCommands(string commands, string message)
        {
            var reader = new StringReader(commands);
            var line = reader.ReadLine();

            while (line != null)
            {
                if (line == "*enter")
                {
                    model.Enter();
                }
                if (line == "controlS")
                {
                    model.ControlS();
                }

                if (line == "*altS")
                {
                    model.AltS();
                }
                
                if (line == "*altP")
                {
                    model.AltP();
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
                result += line;    
                result += System.Environment.NewLine;    
                line = reader.ReadLine();
            }  
            return result;
        }
        
        void SetInput(StringReader reader)
        {
            var input = new InputCommand(reader);
            model.Lines = input.CleanLines();
        }
    }
}