using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using nibble.Interfaces;

namespace nibble.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged, ILifecycleAwarable
	{
		public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingField, value))
				return;

			backingField = value;

			OnPropertyChanged(propertyName);
		}

		// Life Cycle Related Hooks
		public virtual void ViewDidLoad() { }
		public virtual void ViewDidAppear() { }
		public virtual void ViewDidDisappear() { }
	}
}

