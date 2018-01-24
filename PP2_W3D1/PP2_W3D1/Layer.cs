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
        public DirectoryInfo dirInfo;
        public string path;
        public int index;
        public List<FileSystemInfo> items;

        public Layer(string path, int index)
        {
            this.path = path;
            this.index = index;
            this.dirInfo = new DirectoryInfo(path);

            items = new List<FileSystemInfo>();
            items.AddRange(dirInfo.GetDirectories());
            items.AddRange(dirInfo.GetFiles());

        }

        public void Process(int v)
        {
            this.index += v;
            if (this.index < 0)
            {
                this.index = items.Count - 1;
            }
            if (this.index >= items.Count)
            {
                this.index = 0;
            }
        }

        public string GetSelectedItemInfo()
        {
            return this.items[index].FullName;
        }
    }
}
