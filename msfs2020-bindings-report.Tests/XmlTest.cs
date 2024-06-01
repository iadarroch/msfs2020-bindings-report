﻿using System.Drawing;
using FSControls.Classes;
using FSControls.Models;
using Xunit;
using Action = FSControls.Models.Action;

namespace FSControls.Tests
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
                new Context
                {
                    ContextName = "Test Context",
                    BackColor = Color.Black,
                    Actions =
                    [
                        new Action
                        {
                            ActionName = "Key",
                            Bindings = 
                            [
                                new Binding
                                {
                                    Key = "Actions 1"
                                }
                            ]
                        }
                    ]
                },

                new Context
                {
                    ContextName = "Test Context 2",
                    BackColor = Color.Red,
                    Actions =
                    [
                        new Action
                        {
                            ActionName = "Key 2",
                            Bindings = 
                            [
                                new Binding
                                {
                                    Key = "Actions 2"
                                },

                                new Binding
                                {
                                    Priority = Priority.Secondary,
                                    Key = "Actions 3"
                                }
                            ]
                        }
                    ]
                }
            };
        }
    }
}
