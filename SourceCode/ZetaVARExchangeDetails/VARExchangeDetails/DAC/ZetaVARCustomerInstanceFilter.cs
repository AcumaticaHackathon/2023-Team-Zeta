using PX.Data;
using System;

namespace ZetaVARDataExchange
{

    #region Filter Class
    [Serializable()]
    [PXCacheName("ZetaVARCustomerInstanceFilter")]
    public partial class ZetaVARCustomerInstanceFilter : PX.Data.IBqlTable
    {
        #region CompanyName
        [PXString(100, IsUnicode = true, InputMask = "")]
        [PXSelector(typeof(ZetaVARExchangeDetails.companyName))]
        [PXUIField(DisplayName = "Company Name")]
        public virtual string CompanyName { get; set; }
        public abstract class companyName : PX.Data.BQL.BqlString.Field<companyName> { }
        #endregion

        #region URL
        [PXString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Company URL", IsReadOnly = true)]
        [PXDefault(typeof(Search<ZetaVARExchangeDetails.instanceUrl, Where<ZetaVARExchangeDetails.companyName, Equal<Current<ZetaVARExchangeDetails.companyName>>>>), PersistingCheck = PXPersistingCheck.Nothing)]       
        public virtual string URL { get; set; }
        public abstract class uRL : PX.Data.BQL.BqlString.Field<uRL> { }
        #endregion

        #region CurrentVersion
        [PXString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Current Acumatica Version", IsReadOnly = true)]
        public virtual string CurrentVersion { get; set; }
        public abstract class currentVersion : PX.Data.BQL.BqlString.Field<currentVersion> { }
        #endregion

        #region LastUpdateDate
        [PXString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Last Update Date", IsReadOnly = true)]
        public virtual string LastUpdateDate { get; set; }
        public abstract class lastUpdateDate : PX.Data.BQL.BqlString.Field<lastUpdateDate> { }
        #endregion

        #region Tenantname
        [PXDBString(100, IsUnicode = true, IsKey = true, InputMask = "")]
        [PXUIField(DisplayName = "Tenant Name", IsReadOnly = true)]
        public virtual string Tenantname { get; set; }
        public abstract class tenantname : PX.Data.BQL.BqlString.Field<tenantname> { }
        #endregion
    }
    #endregion

}
