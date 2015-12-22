using System;
using System.Windows;

namespace Host.Desktop.Resource
{
    public class SharedResourceService : IResourceService
    {
        private readonly ResourceDictionary _resourceDictionary;

        public SharedResourceService(ResourceDictionary resourceDictionary)
        {
            _resourceDictionary = resourceDictionary;
        }

        public void Add(string resourcePack)
        {
            _resourceDictionary.MergedDictionaries.Add(new SharedResourceDictionary
            {
                Source=new Uri(resourcePack)
            });
        }
    }
}