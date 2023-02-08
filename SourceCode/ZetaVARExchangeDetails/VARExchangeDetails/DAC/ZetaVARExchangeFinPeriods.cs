using PX.Data;
using System;

namespace ZetaVARDataExchange
{
    [Serializable]
    [PXCacheName("ZetaVARExchangeFinPeriods")]
    public class ZetaVARExchangeFinPeriods : IBqlTable
    {
        #region CompanyName
        [PXDBString(100, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Company Name")]
        public virtual string CompanyName { get; set; }
        public abstract class companyName : PX.Data.BQL.BqlString.Field<companyName> { }
        #endregion

        #region Tenant Name
        [PXDBString(100, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Tenant Name")]
        public virtual string TenantName { get; set; }
        public abstract class tenantName : PX.Data.BQL.BqlString.Field<tenantName> { }
        #endregion
       
        #region FinancialPeriod
        [PXDBString(250, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Financial Period")]
        public virtual string FinancialPeriod { get; set; }
        public abstract class financialPeriod : PX.Data.BQL.BqlString.Field<financialPeriod> { }
        #endregion

        #region ClosedInAP
        [PXDBBool()]
        [PXUIField(DisplayName = "Closed In AP")]
        public virtual bool? ClosedInAP { get; set; }
        public abstract class closedInAP : PX.Data.BQL.BqlBool.Field<closedInAP> { }
        #endregion

        #region ClosedInAR
        [PXDBBool()]
        [PXUIField(DisplayName = "Closed In AR")]
        public virtual bool? ClosedInAR { get; set; }
        public abstract class closedInAR : PX.Data.BQL.BqlBool.Field<closedInAR> { }
        #endregion

        #region ClosedInCA
        [PXDBBool()]
        [PXUIField(DisplayName = "Closed In CA")]
        public virtual bool? ClosedInCA { get; set; }
        public abstract class closedInCA : PX.Data.BQL.BqlBool.Field<closedInCA> { }
        #endregion

        #region ClosedInFA
        [PXDBBool()]
        [PXUIField(DisplayName = "Closed In FA")]
        public virtual bool? ClosedInFA { get; set; }
        public abstract class closedInFA : PX.Data.BQL.BqlBool.Field<closedInFA> { }
        #endregion

        #region ClosedInGL
        [PXDBBool()]
        [PXUIField(DisplayName = "Closed In GL")]
        public virtual bool? ClosedInGL { get; set; }
        public abstract class closedInGL : PX.Data.BQL.BqlBool.Field<closedInGL> { }
        #endregion

        #region ClosedInIN
        [PXDBBool()]
        [PXUIField(DisplayName = "Closed In IN")]
        public virtual bool? ClosedInIN { get; set; }
        public abstract class closedInIN : PX.Data.BQL.BqlBool.Field<closedInIN> { }
        #endregion

        #region StartDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Start Date")]
        public virtual DateTime? StartDate { get; set; }
        public abstract class startDate : PX.Data.BQL.BqlDateTime.Field<startDate> { }
        #endregion

        #region EndDate
        [PXDBDate()]
        [PXUIField(DisplayName = "End Date")]
        public virtual DateTime? EndDate { get; set; }
        public abstract class endDate : PX.Data.BQL.BqlDateTime.Field<endDate> { }
        #endregion


        #region Status
        [PXDBString(20, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
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
