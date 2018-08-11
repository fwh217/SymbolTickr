﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SymbolTickr.ViewModels;

namespace SymbolTickr.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewSymbolsPage : ContentPage
	{
		public ViewSymbolsPage ()
		{
			InitializeComponent ();
            this.BindingContext = new MainPageViewModel();
		}
	}
}