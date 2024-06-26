﻿using System.Drawing;
using FSProfiles.Common.Classes;
using FSProfiles.Common.Models;
using Xunit;

namespace FSProfiles.Tests
{
    public class XmlTest
    {
        [Fact]
        public void WriteXml()
        {
            var sut = BuildBindingList();

            using (var writer = new StringWriter())
            {
                Serializer.SerializeObject(writer, sut);
            }
        }

        [Fact]
        public void WriteXmlToFile()
        {
            var sut = BuildBindingList();

            sut.SerializeToFile("C:\\Temp\\Sample.xml");
        }

        [Fact]
        public void ReadXml()
        {
            using (var reader = new StreamReader("C:\\Temp\\Sample.xml"))
            {
                var sut = Serializer.DeserializeObject<BindingList>(reader);
                Assert.NotNull(sut);
            }
        }

        [Fact]
        public void ReadXmlFromFile()
        {
            var sut = Serializer.DeserializeFromFile<BindingList>("C:\\Temp\\Sample.xml");
            Assert.NotNull(sut);
        }

    
        public BindingList BuildBindingList()
        {
            return new BindingList
            {
                Contexts = new List<FSContext>
                {
                    new FSContext
                    {
                        ContextName = "Test Context",
                        BackColor = Color.Black,
                        Actions =
                        [
                            new FSAction
                            {
                                ActionName = "Keys",
                                Bindings = 
                                [
                                    new FSBinding
                                    {
                                        Keys = ["CTRL", "Actions 1"]
                                    }
                                ]
                            }
                        ]
                    },

                    new FSContext
                    {
                        ContextName = "Test Context 2",
                        BackColor = Color.Red,
                        Actions =
                        [
                            new FSAction
                            {
                                ActionName = "Keys 2",
                                Bindings = 
                                [
                                    new FSBinding
                                    {
                                        Keys = ["Actions 2"]
                                    },

                                    new FSBinding
                                    {
                                        Priority = Priority.Secondary,
                                        Keys = ["Actions 3"]
                                    }
                                ]
                            }
                        ]
                    }
                }
            };
        }
    }
}