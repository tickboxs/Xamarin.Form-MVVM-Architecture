using System;
using nibble.Interfaces;
using nibble.Services;
using Autofac;

namespace nibble
{
    public class DIContainer
    {

        public static IContainer Current;

        public static void Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new PageService()).As<IPageService>();
            builder.RegisterInstance(new LocalStorageService()).As<ILocalStorageService>();
            builder.RegisterInstance(new AssetService()).As<IAssetService>();
            builder.RegisterInstance(new CurrencyService()).As<ICurrencyService>();
            builder.RegisterInstance(new CurrencyService()).As<ICurrencyService>();
            builder.RegisterInstance(new ItemService()).As<IItemService>();
            builder.RegisterInstance(new ChartService()).As<IChartService>();

            Current = builder.Build();
        }

    }
}
