using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ConfigurationMock : IConfiguration
    {
        private Dictionary<string, string> _configuration;
        public string this[string key]
        {   
            get => _configuration[key];
            set 
            {
                if (!_configuration.ContainsKey(key))
                {
                    _configuration.Add(key, value);
                }
                else
                {
                    _configuration[key] = value;
                }        
            }
        }

        public ConfigurationMock()
        {
        }

        public ConfigurationMock(Dictionary<string, string> configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}
