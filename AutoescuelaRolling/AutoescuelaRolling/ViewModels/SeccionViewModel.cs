using AutoescuelaRolling.Helpers;
using AutoescuelaRolling.Models;
using AutoescuelaRolling.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoescuelaRolling.ViewModels
{
    public class SeccionViewModel : ViewModelBase
    {
        private HelperAutoescuelaAzure helper;
        private Secciones _Seccion;

        public SeccionViewModel()
        {
            this.helper = new HelperAutoescuelaAzure();
        }

        public Secciones Seccion
        {
            get { return this._Seccion; }
            set
            {
                this._Seccion = value;
                OnPropertyChanged("Seccion");
            }
        }

        public Command InsertarSeccion
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.CrearSeccion(this.Seccion);
                });
            }
        }

        public Command ModificarSeccion
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.ModificarSeccion(this.Seccion);
                    OnPropertyChanged("Seccion");
                });
            }
        }

        public Command EliminarSeccion
        {
            get
            {
                return new Command(async () =>
                {
                    await helper.EliminarOficina(Seccion.Seccion);
                });
            }
        }
    }
}
