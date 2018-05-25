﻿using AutoescuelaRolling.Helpers;
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
    public class SeccionesViewModel : ViewModelBase
    {
        HelperAutoescuelaAzure helper;

        public SeccionesViewModel()
        {
            helper = new HelperAutoescuelaAzure();
            Task.Run(async () => {
                List<Secciones> lista = await helper.GetOficinas();
                this.Secciones = new ObservableCollection<Secciones>(lista);
            });
        }

        private ObservableCollection<Secciones> _Secciones;

        public ObservableCollection<Secciones> Secciones
        {
            get
            {
                return this._Secciones;
            }
            set
            {
                _Secciones = value;
                OnPropertyChanged("Secciones");
            }
        }

        private Secciones _SeccionSeleccionado;
        public Secciones SeccionSeleccionado
        {
            get { return this._SeccionSeleccionado; }
            set
            {
                this._SeccionSeleccionado = value;
                OnPropertyChanged("SeccionSeleccionado");
            }
        }

        public Command DetallesSeccion
        {
            get
            {
                return new Command(async () => {
                    if (SeccionSeleccionado != null)
                    {
                        DetallesSeccion detallesview = new DetallesSeccion();
                        SeccionViewModel viewmodelAdministrador = new AdministradorViewModel();

                        viewmodelAdministrador.Administrador = this.SeccionSeleccionado;

                        detallesview.BindingContext = viewmodelAdministrador;
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