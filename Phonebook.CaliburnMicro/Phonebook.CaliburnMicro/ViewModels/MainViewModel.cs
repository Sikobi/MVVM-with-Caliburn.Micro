﻿using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;
using System.Windows;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class MainViewModel : Conductor<Screen>.Collection.OneActive,
		IHandle<EditPersonMessage>,
		IHandle<ViewPersonMessage>
	{
		public MainViewModel(IWindowManager windowManager)
		{
			DisplayName = "Phonebook";

			WindowManager = windowManager;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			Items.Add(IoC.Get<AllFriendsViewModel>());
		}

		public void Handle(EditPersonMessage message)
		{
			var editPersonViewModel = IoC.Get<EditPersonViewModel>();
			editPersonViewModel.Person = message.Person;

			WindowManager.ShowDialog(editPersonViewModel);
		}

		public void Handle(ViewPersonMessage message)
		{
			// TODO: 5.Handle ViewPersonMessage Refactored
			MessageBox.Show("View Clicked!");
		}

		private IWindowManager WindowManager { get; set; }
	}
}
