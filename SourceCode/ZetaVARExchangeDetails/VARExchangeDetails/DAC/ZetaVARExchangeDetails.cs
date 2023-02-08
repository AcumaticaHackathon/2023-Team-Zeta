using PX.Data;
using PX.Data.BQL;
using System;

namespace ZetaVARDataExchange
{
    [Serializable]
    [PXCacheName("ZetaVARExchangeDetails")]
    public class ZetaVARExchangeDetails : IBqlTable
    {

        #region Selected        
        [PXBool()]
        [PXUIField(DisplayName = "Selected", Visible = false)]
        [PXFormula(typeof(False))]
        public virtual bool? Selected { get; set; }
        public abstract class selected : BqlBool.Field<selected> { }
        #endregion


        #region CompanyName
        [PXDBString(100, IsUnicode = true, IsKey = true, InputMask = "")]
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

        #region Branch
        [PXDBString(50, IsUnicode = true, InputMask = "")] 
        [PXUIField(DisplayName = "Branch")]
        public virtual string Branch { get; set; }
        public abstract class branch : PX.Data.BQL.BqlString.Field<branch> { }
        #endregion


        #region Url
        [PXDBString(500, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Instance Url")]
        public virtual string InstanceUrl { get; set; }
        public abstract class instanceUrl : PX.Data.BQL.BqlString.Field<instanceUrl> { }
        #endregion    

        #region LoginName
        [PXDBString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "User Name")]
        public virtual string LoginName { get; set; }
        public abstract class loginName : PX.Data.BQL.BqlString.Field<loginName> { }
        #endregion

        #region LoginPassword
        [PXRSACryptString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Password")]
        public virtual string LoginPassword { get; set; }
        public abstract class loginPassword : PX.Data.BQL.BqlString.Field<loginPassword> { }
        #endregion

        
        #region Action
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Action", Enabled = false)]
        [PXDefault("View")]
        public virtual string Action { get; set; }
        public abstract class action : PX.Data.BQL.BqlString.Field<action> { }
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