using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SymbolTickr.ViewModels;

namespace SymbolTickr.Views
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
            MainPageViewModel viewModel = new MainPageViewModel();
            foreach (ContentPage page in this.Children)
            {
                page.BindingContext = viewModel;
            }
		}
	}
}
