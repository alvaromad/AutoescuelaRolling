using AutoescuelaRolling.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoescuelaRolling.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdministradoresView : ContentPage
	{
		public AdministradoresView ()
		{
			InitializeComponent ();
            this.entryBusqueda.TextChanged += EntryBusqueda_TextChanged;
		}

        private void EntryBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textoIntroducido = e.NewTextValue;
            AdministradoresViewModel viewModel = (AdministradoresViewModel)this.BindingContext;
            viewModel.Busqueda(textoIntroducido);
        }
    }
}