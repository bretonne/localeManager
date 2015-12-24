using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using LocaleManager.data;

namespace LocaleManager.services
{
    public class ResourcesFactory
    {
        private static ResourcesFactory _instance;
        private string _extension=null;
        private bool _isNetResource;
        private DirectoryInfo _baseDir;
        private DirectoryInfo _rootDir;

        public string[] Locales;


        public static ResourcesFactory GetInstance()
        {
            if (_instance == null)
                _instance = new ResourcesFactory();

            return _instance;
        }

        private ResourcesFactory()
        {//make it singleton class
        }

        public DirectoryInfo BaseDir
        {
            get { return _baseDir; }
            set
            {
                _baseDir = value;
                _rootDir = _baseDir.Parent;

                //look for supported file types
                Extension = null;
                FileInfo[] files = _baseDir.GetFiles("*" + ResxFileService.Extension);
                if (files != null && files.Length > 0)
                    Extension = ResxFileService.Extension;
                else 
                {
                    files = _baseDir.GetFiles("*" + PropertyFileService.Extension);
                    if (files != null && files.Length > 0)
                        Extension = PropertyFileService.Extension;
                }
            }
        }

        public DirectoryInfo RootDir
        {
            get { return _rootDir; }
        }


        public bool IsSupported
        {
            get
            {
                if (_baseDir==null)
                    throw new Exception("BaseDir has to be set before this function is called.");

                return (_extension != null);
            }
        }


        public  string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                _isNetResource = (_extension == ResxFileService.Extension);
            }
        }

        public bool isNetResource
        {
            get { return _isNetResource; }

            set
            {
                _isNetResource = value;
            }
        }

        public IResourceService GetResourceService()
        {
            if (_isNetResource)
                return new ResxFileService();
            else
                return new PropertyFileService();
        }
    }
}
