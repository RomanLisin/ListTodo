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
using System.ComponentModel;
using ListTodo.Services;  // fo using BindingList

namespace ListTodo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";   // в проекте/bin/debug
		private BindingList<TodoModel> _todoDataList;
		private FileInputOutputServices _fileInputOutputServices;
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			_fileInputOutputServices = new FileInputOutputServices(PATH);
			try
			{
				_todoDataList = _fileInputOutputServices.LoadData();
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				Close();
			}
			dgListTodo.ItemsSource = _todoDataList;
			_todoDataList.ListChanged += _todoDataList_ListChanged;
		}

		private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)   // подписываемся на это событие (какое-либо изменение в DataGrid)
		{

			if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
			{
				try
				{
					_fileInputOutputServices.SaveData(sender as BindingList<TodoModel>);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Close();

				}

			}
		}
	}
}
