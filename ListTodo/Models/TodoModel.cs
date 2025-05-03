using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ListTodo.Models
{
	internal class TodoModel:INotifyPropertyChanged
	{
		private bool _isDone;
		private string _text;

		[JsonProperty(PropertyName = "creationDate")]  // для того чтобы в json отображались так
		public DateTime CreationDate { get; set; } = DateTime.Now;

		public event PropertyChangedEventHandler PropertyChanged;
		 
		public bool IsDone
		{
			get { return _isDone; }
			set
			{ 
				if(_isDone == value)
					return;
				_isDone = value;
				OnPropertyChanged("IsDone");
			}
		}

		[JsonProperty(PropertyName = "text")]   // для того чтобы в json отображались так
		public string Text
		{
			get { return _text; }
			set 
			{ 
				if(_text == value)
					return;
				_text = value;
				OnPropertyChanged("Text");
			}
		}
		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // 24:00  https://youtu.be/Mb3S2IK3NzI?t=1501    
			// знак вопроса проверяет на нал, далее передаем параметры, получается как внизу
			//PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
