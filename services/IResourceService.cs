using System;
using System.Collections.Generic;
using System.Text;

using LocaleManager.data;

namespace LocaleManager.services
{
    public interface IResourceService
    {
        SortedDictionary<string, ResourceItem> Load(string path);

        void Save(string path, SortedDictionary<string, ResourceItem> kvps);
    }
}
