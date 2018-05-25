using AutoescuelaRolling.Helpers;
using AutoescuelaRolling.Models;
using AutoescuelaRolling.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoescuelaRolling.ViewModels
{
    public class AlumnoViewModel : ViewModelBase
    {
        private HelperAutoescuelaAzure helper;
        private Alumno _Alumno;

        public AlumnoViewModel()
        {
            this.helper = new HelperAutoescuelaAzure();
        }

        public Alumno Alumno
        {
            get { return this._Alumno; }
            set
            {
                this._Alumno = value;
                OnPropertyChanged("Doctor");
            }
        }

        public Command InsertarAlumno
        {
            get
            {
                return new Command(async () => {
                    await helper.CrearAlumno(this.Alumno);
                });
            }
        }

        public Command ModificarAlumno
        {
            get
            {
                return new Command(async () => {
                    await helper.ModificarAlumno(this.Alumno);
                    OnPropertyChanged("Doctor");
                });
            }
        }

        public Command EliminarAlumno
        {
            get
            {
                return new Command(async () => {
                    await helper.EliminarAlumno(this.Alumno.Codigo);
                });
            }
        }

    }
}
