using System;
using Android.App;
using Android.Runtime;
using Autofac;
using Test.Core;

namespace Test
{
    [Application]
    public class MainApp : Application
    {
        public static IContainer Container;

        public MainApp(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var builder = new ContainerBuilder();
            builder.RegisterType<DataStorage>().SingleInstance();

            Container = builder.Build();
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
        }
    }
}