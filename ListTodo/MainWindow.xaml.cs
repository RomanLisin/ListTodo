using ListTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ListTodo.Models;  // fo using TodoModel private BindingList<TodoModel>;
using System.ComponentModel;  // fo using BindingList

namespace ListTodo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private BindingList<TodoModel> _todoData;
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			_todoData = new BindingList<TodoModel>()
			{
				new TodoModel() {Text = "test"},
				new TodoModel() {Text = "djsad"}
			};

			dgListTodo.ItemsSource = _todoData;
		}
	}
}
