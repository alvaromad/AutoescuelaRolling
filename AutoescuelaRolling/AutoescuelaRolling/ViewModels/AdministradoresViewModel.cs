using AutoescuelaRolling.Helpers;
using AutoescuelaRolling.Models;
using AutoescuelaRolling.ViewModels.Base;
using AutoescuelaRolling.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutoescuelaRolling.ViewModels
{
    public class AdministradoresViewModel : ViewModelBase
    {
        HelperAutoescuelaAzure helper;

        public AdministradoresViewModel()
        {
            helper = new HelperAutoescuelaAzure();
            Task.Run(async () => {
                List<Plantilla> lista = await helper.GetAdministradores();
                this.Administradores = new ObservableCollection<Plantilla>(lista);
            });
        }

        private ObservableCollection<Plantilla> _Administradores;

        public ObservableCollection<Plantilla> Administradores
        {
            get
            {
                return this._Administradores;
            }
            set
            {
                _Administradores = value;
                OnPropertyChanged("Administradores");
            }
        }

        private Plantilla _AdministradorSeleccionado;
        public Plantilla AdministradorSeleccionado
        {
            get { return this._AdministradorSeleccionado; }
            set
            {
                this._AdministradorSeleccionado = value;
                OnPropertyChanged("AdministradorSeleccionado");
            }
        }

        public Command DetallesAdministrador
        {
            get
            {
                return new Command(async () => {
                    if (AdministradorSeleccionado != null)
                    {
                        DetallesAdministrador detallesview = new DetallesAdministrador();
                        AdministradorViewModel viewmodeladministrador = new AdministradorViewModel();

                        viewmodeladministrador.Administrador = this.AdministradorSeleccionado;

                        detallesview.BindingContext = viewmodeladministrador;
                        await Application.Current.MainPage.Navigation.PushAsync(detallesview);
                    }
                    else
                    {
                        return;
                    }
                });
            }
        }
    }
}
