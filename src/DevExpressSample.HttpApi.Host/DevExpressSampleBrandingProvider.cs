using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DevExpressSample
{
    [Dependency(ReplaceServices = true)]
    public class DevExpressSampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DevExpressSample";
    }
}
