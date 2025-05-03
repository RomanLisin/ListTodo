using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ListTodo.Models;
using System.IO;   // fo using File
using Newtonsoft.Json;  // for using JsonConvert

namespace ListTodo.Services
{
	internal class FileInputOutputServices
	{
		private readonly string PATH;

		public FileInputOutputServices(string path)
		{
			PATH = path;
		}
		public BindingList<TodoModel> LoadData()
		{
			var fileExists = File.Exists(PATH);
			if(!fileExists)
			{
				File.CreateText(PATH).Dispose();   // Dispose освобождает ресурсы
				return new BindingList<TodoModel>();  // и создаём BindingList
			}
			using (var reader = File.OpenText(PATH))
			{
				var fileText = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);    // конвретирует и возврщает из Json в BindingList 
			}
			return null;
		}
		public void SaveData(BindingList<TodoModel> todoDataList)
		{
			using (StreamWriter writer = File.CreateText(PATH))   // 32:00  https://youtu.be/Mb3S2IK3NzI?t=1982
			{
				string output = JsonConvert.SerializeObject(todoDataList);
				writer.Write(output);
			}

		}
	}
}
