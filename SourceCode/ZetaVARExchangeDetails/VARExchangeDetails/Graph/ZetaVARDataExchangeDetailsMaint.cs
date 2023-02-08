using PX.Data;
using System.Collections;

namespace ZetaVARDataExchange
{
    public class ZetaVARDataExchangeDetailsMaint : PXGraph<ZetaVARDataExchangeDetailsMaint>
    {
        public PXSave<ZetaVARExchangeDetails> save;
        public PXSelect<ZetaVARExchangeDetails> VARExchnageDetailsView;
        public PXSelect<ZetaVARExchangeDetails, Where<ZetaVARExchangeBuildVersion.companyName, Equal<Current<ZetaVARExchangeBuildVersion.companyName>>>> VARExchnageCurrentDetails;
        public PXSelect<ZetaVARExchangeBuildVersion, Where<ZetaVARExchangeBuildVersion.companyName, Equal<Required<ZetaVARExchangeBuildVersion.companyName>>>> BuildVersionView;
        public PXAction<ZetaVARExchangeDetails> ViewDetails;
        [PXUIField(DisplayName = ZetaVARConstants.ViewExchangeDetails, Visible = false)]
        [PXButton]
        public virtual IEnumerable viewDetails(PXAdapter adapter)
        {
            ZetaVARExchangeBuildVersion version = BuildVersionView.Select(VARExchnageCurrentDetails.Current.CompanyName);
           
            ZetaVARExchangeDetailsInq graph = CreateInstance<ZetaVARExchangeDetailsInq>();

            graph.ZetaVARCustomerInstanceFilterView.Current.CompanyName = VARExchnageCurrentDetails.Current.CompanyName;
            graph.ZetaVARCustomerInstanceFilterView.Current.Tenantname = VARExchnageCurrentDetails.Current.Tenantname;
            graph.ZetaVARCustomerInstanceFilterView.Current.URL = VARExchnageCurrentDetails.Current.InstanceUrl;
            graph.ZetaVARCustomerInstanceFilterView.Current.CurrentVersion = version?.CurrentVersion;
            graph.ZetaVARCustomerInstanceFilterView.Current.LastUpdateDate = version?.LastUpdateDate;
            throw new PXRedirectRequiredException(graph, ZetaVARConstants.ViewExchangeDetails) { Mode = PXBaseRedirectException.WindowMode.New };
           
        }
    }
}
