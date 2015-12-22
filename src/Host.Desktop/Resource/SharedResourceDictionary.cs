using System;
using System.Collections.Generic;
using System.Windows;

namespace Host.Desktop.Resource
{
    public sealed class SharedResourceDictionary : ResourceDictionary
    {
        private static readonly IDictionary<Uri, ResourceDictionary> ShareDictionaries = new Dictionary<Uri, ResourceDictionary>();
        private Uri _sourceUri;

        public new Uri Source
        {
            get { return _sourceUri; }
            set
            {
                _sourceUri = value;
                if (ShareDictionaries.ContainsKey(value))
                    MergedDictionaries.Add(ShareDictionaries[value]);
                else
                {
                    base.Source = value;
                    ShareDictionaries.Add(value, this);
                }
            }
        }

    }
}
