using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoescuelaRolling.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IContainer _container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProfesoresViewModel>();

            builder.RegisterType<ProfesorViewModel>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        public ProfesoresViewModel DoctoresViewModel
        {
            get { return _container.Resolve<ProfesoresViewModel>(); }
        }

        public ProfesorViewModel DoctorViewModel
        {
            get { return _container.Resolve<ProfesorViewModel>(); }
        }
    }
}
