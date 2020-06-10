using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace origin.Model
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class ControlFileClass
    {
        //字段声明
        private ArrayList fileListPath = new ArrayList();
        private ArrayList fileListName = new ArrayList();

        /// <summary>
        /// 文件路径
        /// </summary>
        public ArrayList FileListPath
        {
            get { return fileListPath; }
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public ArrayList FileListName
        {
            get { return fileListName; }
        }

        /// <summary>
        /// 构造函数并遍历文件夹获取文件名称，路径
        /// </summary>
        /// <param name="sourceDirectory">文件夹路径</param>
        /// <param name="nextFold">是否继续查找更深路径</param>
        public ControlFileClass(string sourceDirectory, bool nextFold)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            GetAllList(diSource, nextFold);
        }

        public void GetAllList(DirectoryInfo source, bool nextFold)
        {
            try
            {
                foreach (FileInfo fi in source.GetFiles())
                {
                    fileListPath.Add(fi.FullName);
                    fileListName.Add(fi.Name);
                }
                if (nextFold)//如果设置为可以向更深目录遍历则遍历
                {
                    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                    {
                        GetAllList(diSourceSubDir, nextFold);
                    }
                }
                else//如果设置为不向更深目录遍历则直接用文件夹表示
                {
                    //遍历获取文件夹
                    foreach (DirectoryInfo d in source.GetDirectories())
                    {
                        fileListPath.Add(d.FullName);
                        fileListName.Add(d.Name);
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 判断一个路径是文件还是文件夹
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>true:文件夹，false:文件</returns>
        public static bool IsFolder(string fileNamePath)
        {
            FileInfo fileInfo = new FileInfo(fileNamePath);
            if ((fileInfo.Attributes & FileAttributes.Directory) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除指定文件夹
        /// </summary>
        /// <param name="dir">文件夹路径</param>
        public static void DeleteFolder(string dirPath)
        {
            foreach (string d in Directory.GetFileSystemEntries(dirPath))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件   
                }
                else
                {
                    DeleteFolder(d);//递归删除子文件夹   
                }
            }//end of for
            Directory.Delete(dirPath);//删除已空文件夹   
        }//end of DeleteFolder

        public static void CreateFolder(string dirPath, string name)
        {
            foreach (string d in Directory.GetFileSystemEntries(dirPath))
            {
                if (File.Exists(dirPath + @"\" + name))
                {
                    Console.WriteLine("创建文件夹 " + name + " 失败,文件夹已经存在");
                    return;
                }
            }//end of for
            DirectoryInfo info = new DirectoryInfo(dirPath);
            info.CreateSubdirectory(name);
            //info.Parent.CreateSubdirectory(name);//可以在父目录生成文件夹，很方便

        }//end of CreateFolder

        public static void CreateFile(string dirPath, string name)
        {
            foreach (string d in Directory.GetFileSystemEntries(dirPath))
            {
                if (File.Exists(dirPath + @"\" + name))
                {
                    Console.WriteLine("创建文件 " + name + " 失败,文件已经存在");
                    return;
                }
            }//end of for
            File.Create(dirPath + @"\" + name);
        }//end of CreateFile


        public static void MoveFile(string dirPath, string tarPath, string name)
        {
            bool flag = false;
            foreach (string d in Directory.GetFileSystemEntries(dirPath))
            {
                if (File.Exists(dirPath + @"\" + name))
                {
                    flag = true;
                }
            }//end of for

            if (!flag)
            {
                Console.WriteLine("目标文件 " + name + " 不存在");
                return;
            }

            File.Move(dirPath + @"\" + name, tarPath + @"\" + name);
        }//end of MoveFile


        public static void CopyFile(string dirPath, string tarPath, string name)
        {
            bool flag = false;
            foreach (string d in Directory.GetFileSystemEntries(dirPath))
            {
                if (File.Exists(dirPath + @"\" + name))
                {
                    flag = true;
                }
            }//end of for

            if (!flag)
            {
                Console.WriteLine("目标文件 " + name + " 不存在");
                return;
            }

            File.Copy(dirPath + @"\" + name, tarPath + @"\" + name);
        }//end of CopyFile

        public static string GetFileName(string dirpath)
        {
            for (int i = dirpath.Length - 1; i >= 0; i--)
            {
                if (dirpath[i] == '\\')
                {
                    dirpath = dirpath.Substring(i + 1, dirpath.Length - i - 1);
                    break;//不使用break要崩溃！！
                }
            }
            return dirpath;
        }

        public static string GetFolderPath(string dirpath)
        {
            for (int i = dirpath.Length - 1; i >= 0; i--)
            {
                if (dirpath[i] == '\\')
                {
                    dirpath = dirpath.Substring(0, i);
                    break;//不使用break要崩溃！！
                }
            }
            return dirpath;
        }



    }//end of class 
}//end of namespace 