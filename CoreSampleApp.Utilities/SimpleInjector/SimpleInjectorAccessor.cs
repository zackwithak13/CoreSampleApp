using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Utilities.SimpleInjector
{
    public static class SimpleInjectorAccessor
    {
        private static Container _container;

        public static Container Container
        {
            get
            {
                return _container;
            }
        }

        public static void RegisterContainer(Container container)
        {
            _container = container;
        }

        public static void Load(Action<Container> loadSimpleInjector)
        {
            loadSimpleInjector(_container);
        }
    }
}
