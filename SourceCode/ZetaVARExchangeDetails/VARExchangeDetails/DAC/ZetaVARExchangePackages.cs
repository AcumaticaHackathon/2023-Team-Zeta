using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace ZetaVARDataExchange
{
    [Serializable]
    [PXCacheName("ZetaVARExchangePackages")]
    public class ZetaVARExchangePackages : IBqlTable
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

        #region PackageName
        [PXDBString(100, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Package Name")]
        public virtual string PackageName { get; set; }
        public abstract class packageName : PX.Data.BQL.BqlString.Field<packageName> { }
        #endregion

        #region Published
        [PXDBBool()]
        [PXUIField(DisplayName = "Published")]
        public virtual bool? Published { get; set; }
        public abstract class published : PX.Data.BQL.BqlBool.Field<published> { }
        #endregion

        #region PackageLevel
        [PXDBInt()]
        [PXUIField(DisplayName = "Package Level")]
        public virtual int? PackageLevel { get; set; }
        public abstract class packageLevel : PX.Data.BQL.BqlInt.Field<packageLevel> { }
        #endregion

        #region PublishedDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Published Date")]
        public virtual DateTime? PublishedDate { get; set; }
        public abstract class publishedDate : PX.Data.BQL.BqlDateTime.Field<publishedDate> { }
        #endregion

        #region PublishedBy
        [PXDBString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Published By")]
        public virtual string PublishedBy { get; set; }
        public abstract class publishedBy : PX.Data.BQL.BqlString.Field<publishedBy> { }
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
