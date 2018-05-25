using AutoescuelaRolling.Helpers;
using AutoescuelaRolling.Models;
using AutoescuelaRolling.ViewModels.Base;
using AutoescuelaRolling.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AutoescuelaRolling.ViewModels
{
    public class AlumnosViewModel : ViewModelBase
    {
        HelperAutoescuelaAzure helper;

        public AlumnosViewModel()
        {
            helper = new HelperAutoescuelaAzure();
            Task.Run(async () =>
            {
                List<Alumno> lista = await helper.GetAlumnos();
                this.Alumnos = new ObservableCollection<Alumno>(lista);
            });
        }

        private ObservableCollection<Alumno> _Alumnos;

        public ObservableCollection<Alumno> Alumnos
        {
            get
            {
                return this._Alumnos;
            }
            set
            {
                _Alumnos = value;
                OnPropertyChanged("Alumnos");
            }
        }

        private Alumno _AlumnoSeleccionado;
        public Alumno AlumnoSeleccionado
        {
            get { return this._AlumnoSeleccionado; }
            set
            {
                this._AlumnoSeleccionado = value;
                OnPropertyChanged("AlumnoSeleccionado");
            }
        }

        public Command DetallesAlumno
        {
            get
            {
                return new Command(async () =>
                {
                    if (AlumnoSeleccionado != null)
                    {
                        DetallesAlumno detallesview = new DetallesAlumno();
                        AlumnoViewModel viewmodelalumno = new AlumnoViewModel();

                        viewmodelalumno.Alumno = this.AlumnoSeleccionado;

                        detallesview.BindingContext = viewmodelalumno;
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

