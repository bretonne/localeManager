using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

using LocaleManager.data;
using LocaleManager.utils;

namespace LocaleManager.services
{
    public class PropertyFileService :IResourceService
    {
        private static readonly string JavaExtension = ".properties";

        public static string Extension
        {
            get { return JavaExtension; }
        }

        public SortedDictionary<string, ResourceItem> Load(string path)
        {
            SortedDictionary<string, ResourceItem> kvps = new SortedDictionary<string, ResourceItem>();
            if (!File.Exists(path))
            {
                throw new Exception(path + " does not exist.");
            }

            using (StreamReader rs = new StreamReader(path))
            {
                string line;
                string[] tokens;

                while ((line = rs.ReadLine()) != null)
                {
                    ResourceItem kvp = new ResourceItem();

                    line.Trim();
                    if (line.Length == 0 || line.StartsWith("#"))
                        continue;

                    tokens = line.Split('=');

                    if (null != tokens)
                    {
                        if (tokens.Length > 0)
                            kvp.key = tokens[0];
                        else
                        {//there must be a key
                            continue;
                        }

                        if (tokens.Length > 1)
                            kvp.value = line.Substring(line.IndexOf('=')+1); //tokens[1];
                        else
                            kvp.value = "";

                        try
                        {
                            kvps.Add(kvp.key, kvp);
                        }
                        catch (Exception e)
                        {
                            LogUtils.Log(LogUtils.DuplicateLog, line);
                        }
                    }
                }
            }

            return kvps;
        }

        public void Save(string path, SortedDictionary<string, ResourceItem> kvps)
        {
            using (StreamWriter wr = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, ResourceItem> kvp in kvps)
                {
                    ResourceItem item = kvp.Value;

                    string line = item.key + "=" + item.value;
                    wr.WriteLine(line);
                }
                wr.Close();
            }

        }
    }
}
