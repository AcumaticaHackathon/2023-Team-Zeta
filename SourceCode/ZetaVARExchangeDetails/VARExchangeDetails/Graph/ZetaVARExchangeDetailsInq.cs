using PX.Data;

namespace ZetaVARDataExchange
{
    public class ZetaVARExchangeDetailsInq : PXGraph<ZetaVARExchangeDetailsInq>
    {
        #region Views
        public PXFilter<ZetaVARCustomerInstanceFilter> ZetaVARCustomerInstanceFilterView;
        public PXSelect<ZetaVARExchangeTenants, Where<ZetaVARExchangeTenants.companyName, Equal<Current<ZetaVARCustomerInstanceFilter.companyName>>>, OrderBy<Asc<ZetaVARExchangeTenants.tenantID>>> TenantsView;
        public PXSelect<ZetaVARExchangeFinPeriods, Where<ZetaVARExchangeFinPeriods.companyName, Equal<Current<ZetaVARCustomerInstanceFilter.companyName>>>, OrderBy<Asc<ZetaVARExchangeFinPeriods.financialPeriod>>> FinPeriodsView;
        public PXSelect<ZetaVARExchangeLicenseData, Where<ZetaVARExchangeLicenseData.companyName, Equal<Current<ZetaVARCustomerInstanceFilter.companyName>>>> LicensedDataView;
        public PXSelect<ZetaVARExchangePackages, Where<ZetaVARExchangePackages.companyName, Equal<Current<ZetaVARCustomerInstanceFilter.companyName>>, And<ZetaVARExchangePackages.published, Equal<True>>>, OrderBy<Asc<ZetaVARExchangePackages.packageLevel>>> PackagesView;
        public PXSelect<ZetaVARExchangeBuildVersion, Where<ZetaVARExchangeBuildVersion.companyName, Equal<Required<ZetaVARCustomerInstanceFilter.companyName>>>> BuildVersionView;
        public PXSelect<ZetaVARExchangeDetails, Where<ZetaVARExchangeDetails.companyName, Equal<Required<ZetaVARExchangeDetails.companyName>>>> VARExchangeDetails;

        #endregion

        protected virtual void ZetaVARCustomerInstanceFilter_CompanyName_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e)
        {
            ZetaVARCustomerInstanceFilter row = e.Row as ZetaVARCustomerInstanceFilter;
            if (row == null) return;

            ZetaVARExchangeDetails det = VARExchangeDetails.Select(row.CompanyName);
            row.URL = det?.InstanceUrl;
            ZetaVARExchangeBuildVersion version = BuildVersionView.Select(row.CompanyName);
            row.CurrentVersion = version?.CurrentVersion;
            row.LastUpdateDate = version?.LastUpdateDate;
        }
    }
}
