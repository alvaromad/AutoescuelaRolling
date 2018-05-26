using AutoescuelaRolling.Models;
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
	public partial class ProfesoresView : ContentPage
	{
		public ProfesoresView ()
		{
			InitializeComponent ();
            this.entryBusqueda.TextChanged += EntryBusqueda_TextChanged;
            this.lstprofesores.ItemSelected += Lstprofesores_ItemSelected;
        }

        private void Lstprofesores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Plantilla profesor = (Plantilla)e.SelectedItem;
            ProfesoresViewModel viewModel = (ProfesoresViewModel)this.BindingContext;
            viewModel.ProfesorSeleccionado = profesor;
        }


        private void EntryBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textoIntroducido = e.NewTextValue;
            ProfesoresViewModel viewModel = (ProfesoresViewModel)this.BindingContext;
            viewModel.Busqueda(textoIntroducido);
        }
    }
}