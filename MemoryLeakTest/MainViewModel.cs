using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakTest
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private ObservableCollection<DummyRecord> FItems = new ObservableCollection<DummyRecord>();

		public ObservableCollection<DummyRecord> Items
		{
			get => this.FItems;
			set
			{
				if (this.FItems != value)
				{
					this.FItems = value;
					this.OnPropertyChanged(nameof(this.Items));
				}
			}
		}

		public void AddRecord()
		{
			this.Items.Add(new DummyRecord() { Id = this.Items.Count + 1, Name = "Hoge" });
		}

		public void RemoveRecord()
		{
			if (0 < this.Items.Count)
			{
				this.Items.RemoveAt(0);
			}
			GC.Collect(2);
		}
	}
}
