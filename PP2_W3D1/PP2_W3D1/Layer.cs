using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_W3D1
{
    class Layer
    {
        public Layer(string path, int index)
        {
            this.path = path;
            this.index = index;
            this.dirInfo = new DirectoryInfo(path);
        }
        public DirectoryInfo dirInfo;
        public string path;
        public int index;

        public void Process(int v)
        {
            this.index += v;
            if (this.index < 0)
            {
                this.index = this.dirInfo.GetFileSystemInfos().Length - 1;
            }

            if (this.index >= this.dirInfo.GetFileSystemInfos().Length)
            {
                this.index = 0;
            }
        }

        public string GetSelectedDirInfo()
        {
            return this.dirInfo.GetDirectories()[index].FullName;
        }
    }
}
