using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SharpYaml.Serialization;

namespace Cxlt.Extensions.Configuration.Yaml
{
    internal class YamlConfigurationFileParser
    {
        private readonly IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.Ordinal);
        private readonly Stack<string> _context = new Stack<string>();
        private string _currentPath;

        public IDictionary<string, string> Parse(Stream input)
        {
            _data.Clear();
            _context.Clear();

            var yaml = new YamlStream();
            yaml.Load(new StreamReader(input));

            if (yaml.Documents.Count > 0)
            {
                var rootNode = yaml.Documents[0].RootNode;

                VisitYamlNode("", rootNode);
            }

            return _data;
        }


        private void VisitYamlNode(string context, YamlNode node)
        {
            if (node is YamlScalarNode)
            {
                VisitYamlScalarNode(context, (YamlScalarNode)node);
            }
            else if (node is YamlMappingNode)
            {
                VisitYamlMappingNode(context, (YamlMappingNode)node);
            }
            else if (node is YamlSequenceNode)
            {
                VisitYamlSequenceNode(context, (YamlSequenceNode)node);
            }
        }


        private void VisitYamlScalarNode(string context, YamlScalarNode node)
        {
            EnterContext(context);
            if (_data.ContainsKey(_currentPath))
            {
                throw new FormatException(string.Format(Resources.Error_KeyIsDuplicated, _currentPath));
            }

            _data[_currentPath] = node.Value;
            ExitContext();
        }


        private void VisitYamlMappingNode(string context, YamlMappingNode node)
        {
            EnterContext(context);

            foreach (var yamlNode in node.Children)
            {
                context = ((YamlScalarNode)yamlNode.Key).Value;
                VisitYamlNode(context, yamlNode.Value);
            }
            ExitContext();
        }


        private void VisitYamlSequenceNode(string context, YamlSequenceNode node)
        {
            EnterContext(context);

            for (int i = 0; i < node.Children.Count; i++)
            {
                VisitYamlNode(i.ToString(), node.Children[i]);
            }

            ExitContext();
        }

        private void EnterContext(string context)
        {
            if (!string.IsNullOrEmpty(context))
            {
                _context.Push(context);
            }
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }

        private void ExitContext()
        {
            if (_context.Any())
            {
                _context.Pop();
            }
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }
    }
}
