

using System;
using Ninject;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core
{
    public static class IoC
    {
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            //bind ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
