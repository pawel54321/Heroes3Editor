using System.Collections.Generic;
using System.Linq;

namespace Heroes3Editor.Models
{
    public class BaseArtifact
    {
        internal Dictionary<short, string> _namesByCode { get; set; }

        internal Dictionary<short, string> _HOTANamesByCode { get; set; }

        internal Dictionary<string, short> _codesByName => _namesByCode?.ToDictionary(i => i.Value, i => i.Key);

        public Dictionary<short, string> GetArtifacts => _namesByCode.Where(x => x.Value != "Brak").ToDictionary(x => x.Key, x => x.Value);

        public BaseArtifact()
        {
            _namesByCode = new Dictionary<short, string>();
            _HOTANamesByCode = new Dictionary<short, string>();
        }

        public string[] Names => _namesByCode?.Values.ToArray();

        public string this[short key] => _namesByCode[key];

        public short this[string key] => _codesByName[key];

        public void LoadHotaReferenceCodes()
        {
            foreach (var code in _HOTANamesByCode)
            {
                if (_namesByCode.ContainsKey(code.Key))
                {
                    continue;
                }
                _namesByCode.Add(code.Key, code.Value);
            }
        }

        public void RemoveHotaReferenceCodes()
        {
            foreach (var kvp in _HOTANamesByCode)
            {
                if (_namesByCode.ContainsKey(kvp.Key))
                {
                    _namesByCode.Remove(kvp.Key);
                }
            }
        }
    }
}
