using System;
using PX.Data;

namespace ZetaVARDataExchange
{
    [Serializable]
    [PXCacheName("ZetaVARExchangeLicenseData")]
    public class ZetaVARExchangeLicenseData : IBqlTable
    {
        #region CompanyName
        [PXDBString(100, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Company Name")]
        public virtual string CompanyName { get; set; }
        public abstract class companyName : PX.Data.BQL.BqlString.Field<companyName> { }
        #endregion

        #region Tenantname
        [PXDBString(100, IsUnicode = true, IsKey = true, InputMask = "")]
        [PXUIField(DisplayName = "Tenant Name")]
        public virtual string Tenantname { get; set; }
        public abstract class tenantname : PX.Data.BQL.BqlString.Field<tenantname> { }
        #endregion

        #region LicenseStatus
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "License Status")]
        public virtual string LicenseStatus { get; set; }
        public abstract class licenseStatus : PX.Data.BQL.BqlString.Field<licenseStatus> { }
        #endregion

        #region LicenseTier
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "License Tier")]
        public virtual string LicenseTier { get; set; }
        public abstract class licenseTier : PX.Data.BQL.BqlString.Field<licenseTier> { }
        #endregion

        #region NumberOfProcessors
        [PXDBInt()]
        [PXUIField(DisplayName = "Number of Processors")]
        public virtual int? NumberOfProcessors { get; set; }
        public abstract class numberOfProcessors : PX.Data.BQL.BqlInt.Field<numberOfProcessors> { }
        #endregion

        #region NumberOfTenants
        [PXDBInt()]
        [PXUIField(DisplayName = "Number of Tenants")]
        public virtual int? NumberOfTenants { get; set; }
        public abstract class numberOfTenants : PX.Data.BQL.BqlInt.Field<numberOfTenants> { }
        #endregion

        #region NumberOfUsers
        [PXDBInt()]
        [PXUIField(DisplayName = "Number of Users")]
        public virtual int? NumberOfUsers { get; set; }
        public abstract class numberOfUsers : PX.Data.BQL.BqlInt.Field<numberOfUsers> { }
        #endregion

        #region Month
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Month")]
        public virtual string Month { get; set; }
        public abstract class month : PX.Data.BQL.BqlString.Field<month> { }
        #endregion

        #region CommercialTransactionsofLimit
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Commercial Transactions of Limit")]
        public virtual string CommercialTransactionsofLimit { get; set; }
        public abstract class commercialTransactionsofLimit : PX.Data.BQL.BqlString.Field<commercialTransactionsofLimit> { }
        #endregion

        #region ERPTransactionsofLimit
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "ERP Transactions of Limit")]
        public virtual string ERPTransactionsofLimit { get; set; }
        public abstract class eRPTransactionsofLimit : PX.Data.BQL.BqlString.Field<eRPTransactionsofLimit> { }
        #endregion

        #region ValidFrom
        [PXDBDate()]
        [PXUIField(DisplayName = "Valid From")]
        public virtual DateTime? ValidFrom { get; set; }
        public abstract class validFrom : PX.Data.BQL.BqlDateTime.Field<validFrom> { }
        #endregion

        #region ValidTo
        [PXDBDate()]
        [PXUIField(DisplayName = "ValidTo")]
        public virtual DateTime? ValidTo { get; set; }
        public abstract class validTo : PX.Data.BQL.BqlDateTime.Field<validTo> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion
    }
}
