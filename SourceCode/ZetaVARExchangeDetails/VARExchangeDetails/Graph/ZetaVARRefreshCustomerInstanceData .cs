using Newtonsoft.Json;
using PX.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ZetaVARDataExchange
{
    public class ZetaVARRefreshCustomerInstanceData : PXGraph<ZetaVARRefreshCustomerInstanceData>
    {
        #region Views

        public PXCancel<ZetaVARExchangeDetails> Cancel;
        public PXProcessing<ZetaVARExchangeDetails> ProcessData;
        public PXSelect<ZetaVARExchangeBuildVersion, Where<ZetaVARExchangeBuildVersion.companyName, Equal<Required<ZetaVARExchangeBuildVersion.companyName>>>> BuildVersions;
        public PXSelect<ZetaVARExchangeTenants, Where<ZetaVARExchangeTenants.companyName, Equal<Required<ZetaVARExchangeTenants.companyName>>>> TenantDetails;
        public PXSelect<ZetaVARExchangeLicenseData, Where<ZetaVARExchangeLicenseData.companyName, Equal<Required<ZetaVARExchangeLicenseData.companyName>>>> LicenseDetails;
        public PXSelect<ZetaVARExchangePackages, Where<ZetaVARExchangePackages.companyName, Equal<Required<ZetaVARExchangePackages.companyName>>, And<ZetaVARExchangePackages.packageName, Equal<Required<ZetaVARExchangePackages.packageName>>>>> PackageDetails;
        public PXSelect<ZetaVARExchangeFinPeriods, Where<ZetaVARExchangeFinPeriods.companyName, Equal<Required<ZetaVARExchangeFinPeriods.companyName>>, And<ZetaVARExchangeFinPeriods.financialPeriod, Equal<Required<ZetaVARExchangeFinPeriods.financialPeriod>>>>> FinPeriodDetails;

        #endregion

        #region .ctor
        public ZetaVARRefreshCustomerInstanceData()
        {
            ProcessData.SetProcessDelegate(delegate (List<ZetaVARExchangeDetails> list)
             {
                 RefreshCustomerInstanceData(list);
             });

            var data = ProcessData.Current;
        }
        #endregion


        #region Helper Method

        public static void RefreshCustomerInstanceData(List<ZetaVARExchangeDetails> list)
        {
            ZetaVARRefreshCustomerInstanceData graph = CreateInstance<ZetaVARRefreshCustomerInstanceData>();
            graph.RefreshCustomerInstanceDataProcess(list);
        }

        public virtual void RefreshCustomerInstanceDataProcess(List<ZetaVARExchangeDetails> list)
        {
            try
            {
                foreach (ZetaVARExchangeDetails instancedetails in list)
                {
                    string baseAPIUrl = instancedetails.InstanceUrl.TrimEnd('/');

                    ZetaVARRestService service = new ZetaVARRestService(baseAPIUrl, instancedetails.LoginName, instancedetails.LoginPassword, instancedetails.Tenantname, instancedetails.Branch);

                    //Get Build version details
                    GetBuildVersionDetails(service, instancedetails);

                    //Get Tenant Details
                    GetTenantDetails(service, instancedetails);

                    //Get License Details
                    GetLicenseDetails(service, instancedetails);

                    //Get package Details
                    GetPackageDetails(service, instancedetails);

                    //Get Finanical Period Details
                    GetFinPeriodDetails(service, instancedetails);
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteInformation(ex.Message);
            }
        }

        public void GetBuildVersionDetails(ZetaVARRestService service, ZetaVARExchangeDetails instancedetails)
        {
            try
            {
                string jsonData = service.Get(ZetaVARConstants.GetBuildVersion);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    List<GetBuildVersion> deDerializedBuildVersionData = JsonConvert.DeserializeObject<List<GetBuildVersion>>(jsonData);
                    ZetaVARExchangeBuildVersion buildVersion = BuildVersions.Select(instancedetails.CompanyName);

                    if (buildVersion == null)
                    {
                        ZetaVARExchangeBuildVersion newbuildVersion = new ZetaVARExchangeBuildVersion()
                        {
                            CompanyName = instancedetails.CompanyName,
                            Tenantname = instancedetails.Tenantname,
                            CurrentVersion = deDerializedBuildVersionData[0].CurrentVersion.value,
                            LastUpdateDate = deDerializedBuildVersionData[0].LastUpdateDate.value.ToString(),
                        };
                        BuildVersions.Insert(newbuildVersion);
                        this.Actions.PressSave();
                    }
                    else
                    {
                        buildVersion.CurrentVersion = deDerializedBuildVersionData[0].CurrentVersion.value;
                        buildVersion.LastUpdateDate = deDerializedBuildVersionData[0].LastUpdateDate.value.ToString();
                        BuildVersions.Update(buildVersion);
                        this.Actions.PressSave();
                    }
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteInformation("GetBuildVersionDetails: " + ex.Message);
            }
        }

        public void GetTenantDetails(ZetaVARRestService service, ZetaVARExchangeDetails instancedetails)
        {
            try
            {
                string jsonData = service.Get(ZetaVARConstants.GetTenantDetails);

                if (!string.IsNullOrEmpty(jsonData))
                {
                    List<GetTenantDetails> deDerializedTenantDetails = JsonConvert.DeserializeObject<List<GetTenantDetails>>(jsonData);
                    ZetaVARExchangeTenants TenantDet = TenantDetails.Select(instancedetails.CompanyName);

                    if (TenantDet == null)
                    {
                        ZetaVARExchangeTenants newTenantInfo = new ZetaVARExchangeTenants()
                        {
                            CompanyName = instancedetails.CompanyName,
                            TenantID = deDerializedTenantDetails[0].TenantID.value,
                            TenantName = deDerializedTenantDetails[0].TenantName.value,
                            LoginName = deDerializedTenantDetails[0].LoginName.value,
                            Status = deDerializedTenantDetails[0].Status.value
                        };
                        TenantDetails.Insert(newTenantInfo);
                        this.Actions.PressSave();
                    }
                    else
                    {
                        if (TenantDet.Status != deDerializedTenantDetails[0].Status.value)
                        {
                            TenantDet.Status = deDerializedTenantDetails[0].Status.value;
                            TenantDetails.Update(TenantDet);
                            this.Actions.PressSave();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteInformation("GetTenantDetails" + ex.Message);
            }

        }

        public void GetLicenseDetails(ZetaVARRestService service, ZetaVARExchangeDetails instancedetails)
        {
            try
            {
                string emptyData = "{ }";
                //Get License Details
                string LicneseDetjsonData = service.Put(ZetaVARConstants.GetLicenseDetails, string.Empty, emptyData);
                //Get License Status
                string LicneseStatusjsonData = service.Put(ZetaVARConstants.GetLicenseStatus, string.Empty, emptyData);

                if (!string.IsNullOrEmpty(LicneseDetjsonData) || !string.IsNullOrEmpty(LicneseStatusjsonData))
                {
                    GetLicenseDetails deserializedLicenseDetails = JsonConvert.DeserializeObject<GetLicenseDetails>(LicneseDetjsonData);
                    GetLicenseStatus deserializedLicenseStatus = JsonConvert.DeserializeObject<GetLicenseStatus>(LicneseStatusjsonData);

                    ZetaVARExchangeLicenseData LicenseDet = LicenseDetails.Select(instancedetails.CompanyName);

                    if (LicenseDet == null)
                    {
                        ZetaVARExchangeLicenseData newLincenseInfo = new ZetaVARExchangeLicenseData()
                        {
                            CompanyName = instancedetails.CompanyName,
                            Tenantname = instancedetails.Tenantname,
                            LicenseStatus = deserializedLicenseStatus?.Status.value,
                            LicenseTier = deserializedLicenseDetails?.LicenseTier.value,
                            NumberOfProcessors = deserializedLicenseStatus?.NumberofProcessors.value,
                            NumberOfTenants = deserializedLicenseStatus?.NumberofTenants.value,
                            NumberOfUsers = deserializedLicenseStatus?.NumberofUsers.value,
                            ValidFrom = deserializedLicenseStatus?.ValidFrom.value,
                            ValidTo = deserializedLicenseStatus?.ValidTo.value,
                            Month = deserializedLicenseDetails?.Month.value.ToString(),
                            ERPTransactionsofLimit = deserializedLicenseDetails?.ERPTransactionsofLimit.value,
                            CommercialTransactionsofLimit = deserializedLicenseDetails?.CommercialTransactionsofLimit.value,
                        };
                        LicenseDetails.Insert(newLincenseInfo);
                        this.Actions.PressSave();
                    }
                    else
                    {
                        LicenseDet.LicenseStatus = deserializedLicenseStatus?.Status.value;
                        LicenseDet.LicenseTier = deserializedLicenseDetails?.LicenseTier.value;
                        LicenseDet.NumberOfProcessors = deserializedLicenseStatus?.NumberofProcessors.value;
                        LicenseDet.NumberOfTenants = deserializedLicenseStatus?.NumberofTenants.value;
                        LicenseDet.NumberOfUsers = deserializedLicenseStatus?.NumberofUsers.value;
                        LicenseDet.ValidFrom = deserializedLicenseStatus?.ValidFrom.value;
                        LicenseDet.ValidTo = deserializedLicenseStatus?.ValidTo.value;
                        LicenseDet.Month = deserializedLicenseDetails?.Month.value.ToString();
                        LicenseDet.ERPTransactionsofLimit = deserializedLicenseDetails?.ERPTransactionsofLimit.value;
                        LicenseDet.CommercialTransactionsofLimit = deserializedLicenseDetails?.CommercialTransactionsofLimit.value;
                        LicenseDetails.Update(LicenseDet);
                        this.Actions.PressSave();
                    }
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteInformation("GetLicenseDetails" + ex.Message);
            }
        }

        public void GetPackageDetails(ZetaVARRestService service, ZetaVARExchangeDetails instancedetails)
        {
            try
            {
                string jsonData = service.Get(ZetaVARConstants.GetPackageList);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    List<GetPackageList> deDerializedPackageDet = JsonConvert.DeserializeObject<List<GetPackageList>>(jsonData);

                    foreach (GetPackageList packageDet in deDerializedPackageDet)
                    {

                        ZetaVARExchangePackages PackageInfo = PackageDetails.Select(instancedetails.CompanyName, packageDet.ProjectName.value);
                        if (PackageInfo == null)
                        {
                            ZetaVARExchangePackages newPackage = new ZetaVARExchangePackages()
                            {
                                CompanyName = instancedetails.CompanyName,
                                Tenantname = instancedetails.Tenantname,
                                PackageName = packageDet.ProjectName.value,
                                Published = packageDet.Published.value,
                                PackageLevel = packageDet.Level.value,
                                PublishedBy = packageDet.CreatedBy.value,
                                PublishedDate = packageDet.LastModifiedOn.value,
                            };
                            PackageDetails.Insert(newPackage);
                        }
                        else
                        {
                            PackageInfo.PackageName = packageDet.ProjectName.value;
                            PackageInfo.Published = packageDet.Published.value;
                            PackageInfo.PackageLevel = packageDet.Level.value;
                            PackageDetails.Update(PackageInfo);
                        }
                        this.Actions.PressSave();
                    }
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteInformation("GetPackageDetails" + ex.Message);
            }
        }

        public void GetFinPeriodDetails(ZetaVARRestService service, ZetaVARExchangeDetails instancedetails)
        {
            FinancialYear year = new FinancialYear()
            {
                value = this.Accessinfo.BusinessDate.Value.Year.ToString()
            };
            FinInfo finInfo = new FinInfo()
            {
                FinancialYear = year,
            };

            string requestData = JsonConvert.SerializeObject(finInfo);

            try
            {
                string jsonData = service.Put(ZetaVARConstants.GetFinancialPeriod, "$expand=FinDetails", requestData);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    GetFinancialPeriod deDerializedFinPeriodDet = JsonConvert.DeserializeObject<GetFinancialPeriod>(jsonData);

                    foreach (var findet in deDerializedFinPeriodDet.FinDetails)
                    {
                        ZetaVARExchangeFinPeriods FinPeriodInfo = FinPeriodDetails.Select(instancedetails.CompanyName, findet.FinancialPeriodID.value);
                        if (FinPeriodInfo == null)
                        {
                            ZetaVARExchangeFinPeriods newFInPeriod = new ZetaVARExchangeFinPeriods()
                            {
                                CompanyName = instancedetails.CompanyName,
                                TenantName = instancedetails.Tenantname,
                                FinancialPeriod = findet.FinancialPeriodID.value,
                                StartDate = findet.StartDate.value,
                                EndDate = findet.EndDate.value,
                                Status = findet.Status.value,
                                ClosedInAP = findet.ClosedinAP.value,
                                ClosedInAR = findet.ClosedinAR.value,
                                ClosedInCA = findet.ClosedinCA.value,
                                ClosedInFA = findet.ClosedinFA.value,
                                ClosedInGL = findet.ClosedinGL.value,
                                ClosedInIN = findet.ClosedinIN.value
                            };
                            FinPeriodDetails.Insert(newFInPeriod);
                            this.Actions.PressSave();
                        }
                        else
                        {
                            FinPeriodInfo.StartDate = findet.StartDate.value;
                            FinPeriodInfo.EndDate = findet.EndDate.value;
                            FinPeriodInfo.Status = findet.Status.value;
                            FinPeriodInfo.ClosedInAP = findet.ClosedinAP.value;
                            FinPeriodInfo.ClosedInAR = findet.ClosedinAR.value;
                            FinPeriodInfo.ClosedInCA = findet.ClosedinCA.value;
                            FinPeriodInfo.ClosedInFA = findet.ClosedinFA.value;
                            FinPeriodInfo.ClosedInGL = findet.ClosedinGL.value;
                            FinPeriodInfo.ClosedInIN = findet.ClosedinIN.value;
                            FinPeriodDetails.Update(FinPeriodInfo);
                            this.Actions.PressSave();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteInformation("GetFinPeridDetails" + ex.Message);
            }
        }
        #endregion
    }
}