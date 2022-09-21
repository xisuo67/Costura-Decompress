using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.IO;

namespace Costura_Decompress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
		private void btnDeCompress_Click(object sender, EventArgs e)
		{
			txtLog.Clear();
			string inputFile = txtInput.Text.Trim();
			string dir = txtOutput.Text.Trim();
			if (string.IsNullOrEmpty(inputFile) || !File.Exists(inputFile))
			{
				MessageBox.Show("文件路径为空，或文件不存在！");
			}
			else if (string.IsNullOrEmpty(dir))
			{
				MessageBox.Show("请填入输出目录！");
			}
			else if (inputFile.EndsWith(".exe"))
			{
				try
				{
					ProcessExe(inputFile, dir);
				}
				catch (Exception)
				{
					Log("加载失败，确认是否是一个.net module");
				}
			}
			else if (inputFile.EndsWith(".compressed"))
			{
				Task.Factory.StartNew(delegate
				{
					string outFile = string.Empty;
					ProcessCompressedFile(inputFile, dir, out outFile);
					Log("success: costura file output:" + outFile + "\r\n");
				});
			}
			else
			{
				Log("只支持 .exe or .compressed 文件 \r\n");
			}
		}
		private void ProcessCompressedFile(string inputFile, string saveDir, out string outFile)
		{
			string text = inputFile.Replace("costura.", null);
			text = text.Replace(".compressed", null);
			outFile = Path.Combine(saveDir, text);
            using (FileStream input = File.OpenRead(inputFile))
            {
				File.WriteAllBytes(outFile, DecompressResource(input));
			}
		}

		private byte[] DecompressResource(Stream input)
		{
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (DeflateStream deflateStream = new DeflateStream(input, CompressionMode.Decompress))
                {
					deflateStream.CopyTo(memoryStream);
					return memoryStream.ToArray();
				}
            }
		}

		private void ProcessExe(string inputFile, string saveDir)
		{
			ModuleDef moduleDef = ModuleDefMD.Load(inputFile);
			Log(moduleDef.FullName + " start 解析...\r\n");
			if (!moduleDef.HasResources)
			{
				Log(moduleDef.FullName + " 没有找到任何Resources");
				return;
			}
			if (!Directory.Exists(saveDir))
			{
				Directory.CreateDirectory(saveDir);
			}
			foreach (Resource resource in moduleDef.Resources)
			{
				if (resource.Name.Length >= 19 && (resource.Name.StartsWith("costura.") || resource.Name.EndsWith(".compressed")))
				{
					DataReader dataReader = moduleDef.Resources.FindEmbeddedResource(resource.Name).CreateReader();
					string path = resource.Name.Substring(8, resource.Name.LastIndexOf(".compressed") - 8);
                    using (Stream input = dataReader.AsStream())
                    {
						byte[] bytes = DecompressResource(input);
						string text = Path.Combine(saveDir, path);
						File.WriteAllBytes(text, bytes);
						Log("success:output:" + text);
					}
				}
			}
			Log("success all end...");
		}

		private void Log(string str)
		{
			txtLog.AppendText(str + "\r\n");
		}
	}
}
