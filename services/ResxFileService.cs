using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Text;

using LocaleManager.data;
using LocaleManager.utils;

namespace LocaleManager.services
{
    public class ResxFileService :IResourceService
    {
        private static readonly string NetExtension = ".resx";

        public static string Extension
        {
            get { return NetExtension; }
        }

        public SortedDictionary<string, ResourceItem> Load(string path)
        {
            SortedDictionary<string, ResourceItem> kvps = new SortedDictionary<string, ResourceItem>();
            if (!File.Exists(path))
            {
                throw new Exception(path + " does not exist.");
            }

            using (ResXResourceReader rd = new ResXResourceReader(path))
            {
                foreach (DictionaryEntry d in rd)
                {
                    ResourceItem kvp = new ResourceItem();
                    kvp.key = d.Key.ToString();
                    if (d.Value != null)
                        kvp.value = d.Value.ToString();
                    else
                        kvp.value = "";

                    try
                    {
                        kvps.Add(kvp.key, kvp);
                    }
                    catch (Exception e)
                    {
                        LogUtils.Log(LogUtils.DuplicateLog, kvp.key + "=" + kvp.value);
                    }
                }
            }

            //go another round to get comment out through Enumerator
            using (ResXResourceReader rd = new ResXResourceReader(path))
            {
                rd.UseResXDataNodes = true;
                IEnumerator enumerator = rd.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DictionaryEntry d = (DictionaryEntry)enumerator.Current;
                    ResXDataNode dataNode = (ResXDataNode)d.Value;
                    ResourceItem kvp = (ResourceItem)kvps[dataNode.Name];
                    if (dataNode != null)
                        kvp.comment = dataNode.Comment;
                    else
                        kvp.comment = "";
                }
            }
            return kvps;
        }

        public void Save(string path, SortedDictionary<string, ResourceItem> kvps)
        {
            using (ResXResourceWriter wr = new ResXResourceWriter(path))
            {
                foreach (KeyValuePair<string, ResourceItem> kvp  in kvps)
                {
                    ResourceItem item = kvp.Value;

                    //ResXDataNode dataNode = new ResXDataNode(kvp.key, kvp);
                    //wr.AddResource(dataNode);
                    wr.AddResource(item.key, item.value);
                }
                wr.Close();
            }

        }
    }
}
