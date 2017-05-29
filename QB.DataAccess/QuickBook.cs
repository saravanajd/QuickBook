using System;
using System.Collections.Generic;
using Interop.QBFC13;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Linq;

namespace QB.DAL
{
    public class QuickBook
    {
        private QBSessionManager sessionManager = null;
        private bool isConnectionOpened = false;
        private bool isSessionBegined = false;

        private readonly string countryQB = "US";
        private readonly short majorVersionQB = 13;
        private readonly short minorVersionQB = 0;

        private readonly string appName = "MyCompany";
        private readonly string appID = "QBFC";
        private readonly string companyFilePath = @"C:\Users\Public\Documents\Intuit\QuickBooks\sampl\MyCompany.qbw";


        #region Open Connection And Colse Connection

        private void OpenConnection()
        {
            try
            {
                if (sessionManager == null)
                {
                    sessionManager = new QBSessionManager();
                }
                if (!isConnectionOpened)
                {
                    sessionManager.OpenConnection(appID, appName);
                    isConnectionOpened = true;
                }

                if (!isSessionBegined)
                {
                    sessionManager.BeginSession(companyFilePath, ENOpenMode.omDontCare);
                    isSessionBegined = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CloseConnection()
        {
            try
            {
                if (sessionManager != null)
                {
                    sessionManager.EndSession();
                    isSessionBegined = false;
                }

                if (sessionManager != null)
                {
                    sessionManager.CloseConnection();
                    isConnectionOpened = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool OpenCon(string appName)
        {
            try
            {
                if (sessionManager == null)
                {
                    sessionManager = new QBSessionManager();
                }
                if (!isConnectionOpened)
                {
                    sessionManager.OpenConnection("", appName);
                    isConnectionOpened = true;
                }
                return isConnectionOpened;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool OpenSession(string QBFilePath)
        {
            try
            {
                if (sessionManager == null)
                    sessionManager = new QBSessionManager();

                if (!isConnectionOpened)
                    return false;

                if (!isSessionBegined)
                {
                    sessionManager.BeginSession("", ENOpenMode.omDontCare);
                    isSessionBegined = true;
                }
                return isSessionBegined;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CloseSession()
        {
            bool isSessionEnd = false;
            try
            {
                if (sessionManager != null)
                {
                    sessionManager.EndSession();
                    isSessionBegined = false;
                    isSessionEnd = true;
                }
                return isSessionEnd;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CloseCon()
        {
            bool isConnectionClosed = false;
            try
            {
                if (sessionManager != null)
                {
                    sessionManager.CloseConnection();
                    isConnectionOpened = false;
                    isConnectionClosed = true;
                }

                return isConnectionClosed;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Add Customer, View and Update Customer

        public bool AddCustomer(Customer customer)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerAdd customerAddRq = requestMsgSet.AppendCustomerAddRq();
                customerAddRq.Name.SetValue(customer.CustomerName);
                if (!string.IsNullOrEmpty(customer.BillAddressAdd1))
                    customerAddRq.BillAddress.Addr1.SetValue(customer.BillAddressAdd1);
                if (!string.IsNullOrEmpty(customer.BillAddressCity))
                    customerAddRq.BillAddress.City.SetValue(customer.BillAddressCity);
                if (!string.IsNullOrEmpty(customer.BillAddressState))
                    customerAddRq.BillAddress.State.SetValue(customer.BillAddressState);
                if (!string.IsNullOrEmpty(customer.BillAddressPostalCode))
                    customerAddRq.BillAddress.PostalCode.SetValue(customer.BillAddressPostalCode);
                if (!string.IsNullOrEmpty(customer.Phone))
                    customerAddRq.Phone.SetValue(customer.Phone);
                if (!string.IsNullOrEmpty(customer.Fax))
                    customerAddRq.Fax.SetValue(customer.Fax);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");
                else
                    return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable ViewCustomer()
        {
            var dt = new DataTable();
            DataRow dr;
            bool isVerified = false;
            try
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("QuickBooksID");
                dt.Columns.Add("EditSequence");
                dt.Columns.Add("Email");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Company");

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerQuery CustomerQueryRq = requestMsgSet.AppendCustomerQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                ICustomerRetList customerRetList = (ICustomerRetList)response.Detail;

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        if (customerRetList != null)
                        {
                            isVerified = true;
                            for (int i = 0; i < customerRetList.Count; i++)
                            {
                                ICustomerRet customerRet = customerRetList.GetAt(i);

                                dr = dt.NewRow();
                                if (customerRet.Name != null)
                                    dr["Name"] = customerRet.Name.GetValue();
                                if (customerRet.ListID != null)
                                    dr["QuickBooksID"] = customerRet.ListID.GetValue();
                                if (customerRet.EditSequence != null)
                                    dr["EditSequence"] = customerRet.EditSequence.GetValue();
                                if (customerRet.Email != null)
                                    dr["Email"] = customerRet.Email.GetValue();
                                if (customerRet.Phone != null)
                                    dr["Phone"] = customerRet.Phone.GetValue();
                                if (customerRet.CompanyName != null)
                                    dr["Company"] = customerRet.CompanyName.GetValue();

                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public Customer FindCustomer(string customerRefListID)
        {
            var customer = new Customer();
            bool isVerified = false;

            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerQuery CustomerQueryRq = requestMsgSet.AppendCustomerQueryRq();
                CustomerQueryRq.ORCustomerListQuery.ListIDList.Add(customerRefListID);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtCustomerQueryRs)
                        {
                            isVerified = true;
                            ICustomerRetList customerRetList = (ICustomerRetList)response.Detail;

                            if (customerRetList != null)
                            {
                                for (int i = 0; i < customerRetList.Count; i++)
                                {
                                    ICustomerRet customerRet = customerRetList.GetAt(i);
                                    if (customerRet != null)
                                    {
                                        if (customerRet.Phone != null)
                                            customer.Phone = customerRet.Phone.GetValue();
                                        if (customerRet.FullName != null)
                                            customer.CustomerName = customerRet.FullName.GetValue();
                                        if (customerRet.CompanyName != null)
                                            customer.CompanyName = customerRet.CompanyName.GetValue();
                                        if (customerRet.Email != null)
                                            customer.Email = customerRet.Email.GetValue();
                                        if (customerRet.EditSequence != null)
                                            customer.EditSequence = customerRet.EditSequence.GetValue();
                                    }
                                }
                            }
                        }
                    }
                }
                if (!isVerified)
                    throw new Exception($" Error: {response.StatusMessage}");

                return customer;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerMod CustomerModRq = requestMsgSet.AppendCustomerModRq();
                if (customer.CustomerName != null)
                    CustomerModRq.Name.SetValue(customer.CustomerName);
                if (customer.CompanyName != null)
                    CustomerModRq.CompanyName.SetValue(customer.CompanyName);
                if (customer.Email != null)
                    CustomerModRq.Email.SetValue(customer.Email);
                if (customer.Phone != null)
                    CustomerModRq.Phone.SetValue(customer.Phone);
                if (customer.ListId != null)
                    CustomerModRq.ListID.SetValue(customer.ListId);
                if (customer.EditSequence != null)
                    CustomerModRq.EditSequence.SetValue(customer.EditSequence);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode != 0)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable ViewCustomFieldCustomer()
        {
            var dt = new DataTable();
            dt.Columns.Add("CustomerName");
            DataRow dr;
            bool isVerified = false;
            try
            {
                #region RequestForCustomer
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerQuery CustomerQueryRq = requestMsgSet.AppendCustomerQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                ICustomerRetList customerRetList = (ICustomerRetList)response.Detail;
                #endregion

                #region RequestForCustomField

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSetCust = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSetCust.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerQuery CustomerQueryRqCust = requestMsgSetCust.AppendCustomerQueryRq();
                CustomerQueryRqCust.IncludeRetElementList.Add("DataExtRet");
                // Field visble in UI so its 0
                CustomerQueryRqCust.OwnerIDList.Add("0");

                OpenConnection();
                IMsgSetResponse responseMsgSetCust = sessionManager.DoRequests(requestMsgSetCust);
                CloseConnection();
                IResponse responseCust = responseMsgSetCust.ResponseList.GetAt(0);
                ICustomerRetList customerRetListCust = (ICustomerRetList)responseCust.Detail;

                #endregion


                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        if (customerRetList != null)
                        {
                            var columnNameList = new List<string>();
                            isVerified = true;
                            for (int i = 0; i < customerRetList.Count; i++)
                            {
                                var customerRet = customerRetList.GetAt(i);

                                dr = dt.NewRow();

                                if (customerRet.FullName != null)
                                    dr["CustomerName"] = customerRet.FullName.GetValue();

                                var customerRetCust = customerRetListCust.GetAt(i);

                                if (customerRetCust.DataExtRetList != null)
                                {
                                    for (int j = 0; j < customerRetCust.DataExtRetList.Count; j++)
                                    {

                                        var dataExt = customerRetCust.DataExtRetList.GetAt(j);
                                        string name = null;
                                        if (dataExt.DataExtName != null)
                                        {
                                            name = dataExt.DataExtName.GetValue();
                                            if (!columnNameList.Contains(name))
                                            {
                                                columnNameList.Add(name);
                                                dt.Columns.Add(name);
                                            }
                                        }

                                        if (dataExt.DataExtValue != null)
                                            dr[name] = dataExt.DataExtValue.GetValue();
                                    }
                                }

                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool AddCustomFieldCustomer(Customer customer)
        {
            try
            {
                try
                {
                    sessionManager = new QBSessionManager();

                    IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                    requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                    ICustomerAdd customerAddRq = requestMsgSet.AppendCustomerAddRq();

                    if (customer.CustomerName != null)
                        customerAddRq.Name.SetValue(customer.CustomerName);
                    if (!string.IsNullOrEmpty(customer.Phone))
                        customerAddRq.Phone.SetValue(customer.Phone);


                    OpenConnection();
                    IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                    CloseConnection();
                    IResponse response = responseMsgSet.ResponseList.GetAt(0);
                    var customerRet = (ICustomerRet)response.Detail;
                    string customerListID = "";
                    if (customerRet.ListID != null)
                        customerListID = customerRet.ListID.GetValue();

                    sessionManager = new QBSessionManager();

                    IMsgSetRequest requestMsgSetReq = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                    requestMsgSetReq.Attributes.OnError = ENRqOnError.roeContinue;

                    IDataExtAdd DataExtAddRq = requestMsgSetReq.AppendDataExtAddRq();
                    DataExtAddRq.OwnerID.SetValue("0"); //field visable in UI so it is "0"
                    DataExtAddRq.DataExtName.SetValue("CustomField"); //name of field

                    //set for customer add
                    DataExtAddRq.ORListTxnWithMacro.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    if (customerListID == null) throw new Exception("Customer ListID is Null");
                    //give list id for cust
                    DataExtAddRq.ORListTxnWithMacro.ListDataExt.ListObjRef.ListID.SetValue(customerListID);

                    //Set field value for DataExtValue
                    DataExtAddRq.DataExtValue.SetValue(customer.CustomField);
                    OpenConnection();
                    sessionManager.DoRequests(requestMsgSetReq);
                    CloseConnection();

                    if (response.StatusCode != 0)
                        throw new Exception($" Error: {response.StatusMessage}");
                    else
                        return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Item Add OR View Items

        public string AddItem(Item item)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IItemInventoryAdd itemInventoryAddRq = requestMsgSet.AppendItemInventoryAddRq();
                if (item.Name != null)
                    itemInventoryAddRq.Name.SetValue(item.Name);
                if (item.Description != null)
                    itemInventoryAddRq.SalesDesc.SetValue(item.Description);
                itemInventoryAddRq.SalesPrice.SetValue(item.Rate);
                itemInventoryAddRq.IncomeAccountRef.FullName.SetValue("Sales - Hardware Test");
                itemInventoryAddRq.AssetAccountRef.FullName.SetValue("Inventory");
                itemInventoryAddRq.COGSAccountRef.FullName.SetValue("Purchases - Hardware for Resale");
                itemInventoryAddRq.QuantityOnHand.SetValue(item.OnHandQuantity);


                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                IItemInventoryRet itemInventoryRet = (IItemInventoryRet)response.Detail;

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");

                item.QuickBooksID = itemInventoryRet.ListID.GetValue();
                return response.StatusCode == 0 ? $"Item Added Successfully \n ItemName = {item.Name}" : "Unknown Error";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable ViewItem()
        {
            try
            {

                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("Name");
                dt.Columns.Add("Description");
                dt.Columns.Add("Price");

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IItemQuery itemQueryRq = requestMsgSet.AppendItemQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                IORItemRetList itemRetList = (IORItemRetList)response.Detail;

                if (itemRetList != null)
                {
                    for (int j = 0; j < itemRetList.Count; j++)
                    {
                        IORItemRet itemRet = itemRetList.GetAt(j);
                        if (itemRet.ItemInventoryRet != null)
                        {
                            IItemInventoryRet itemInventoryRet = itemRet.ItemInventoryRet;
                            dr = dt.NewRow();
                            if (itemInventoryRet.Name != null)
                                dr["Name"] = itemInventoryRet.Name.GetValue();
                            if (itemInventoryRet.SalesDesc != null)
                                dr["Description"] = itemInventoryRet.SalesDesc.GetValue();
                            if (itemInventoryRet.SalesPrice != null)
                                dr["Price"] = itemInventoryRet.SalesPrice.GetValue();

                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                        else if (itemRet.ItemServiceRet != null)
                        {
                            IItemServiceRet itemServiceRet = itemRet.ItemServiceRet;
                            dr = dt.NewRow();
                            if (itemServiceRet.Name != null)
                                dr["Name"] = itemServiceRet.Name.GetValue();
                            if (itemServiceRet.ORSalesPurchase.SalesOrPurchase.Desc != null)
                                dr["Description"] = itemServiceRet.ORSalesPurchase.SalesOrPurchase.Desc.GetValue();
                            if (itemServiceRet.ORSalesPurchase.SalesOrPurchase.ORPrice.Price != null)
                                dr["Price"] = itemServiceRet.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.GetValue();

                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable ViewCustomFieldItem()
        {
            var dt = new DataTable();
            dt.Columns.Add("ItemName");
            DataRow dr;
            bool isVerified = false;
            try
            {
                #region RequestForVendor

                sessionManager = new QBSessionManager();

                var requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                var itemQueryRq = requestMsgSet.AppendItemInventoryQueryRq();

                OpenConnection();
                var responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                var response = responseMsgSet.ResponseList.GetAt(0);
                var itemRetList = (IItemInventoryRetList)response.Detail;

                #endregion

                #region RequestForCustomField

                sessionManager = new QBSessionManager();

                var requestMsgSetCust = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSetCust.Attributes.OnError = ENRqOnError.roeContinue;

                var ItemQueryRqCust = requestMsgSetCust.AppendItemInventoryQueryRq();
                ItemQueryRqCust.IncludeRetElementList.Add("DataExtRet");
                ItemQueryRqCust.OwnerIDList.Add("0");

                OpenConnection();
                var responseMsgSetCust = sessionManager.DoRequests(requestMsgSetCust);
                CloseConnection();
                var responseCust = responseMsgSetCust.ResponseList.GetAt(0);
                var itemRetListCust = (IItemInventoryRetList)responseCust.Detail;

                #endregion


                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        if (itemRetList != null)
                        {
                            var columnNameList = new List<string>();
                            isVerified = true;
                            for (int i = 0; i < itemRetList.Count; i++)
                            {
                                var itemRet = itemRetList.GetAt(i);

                                dr = dt.NewRow();

                                if (itemRet.Name != null)
                                    dr["ItemName"] = itemRet.Name.GetValue();

                                var itemRetCust = itemRetListCust.GetAt(i);

                                if (itemRetCust.DataExtRetList != null)
                                {
                                    for (int j = 0; j < itemRetCust.DataExtRetList.Count; j++)
                                    {

                                        var dataExt = itemRetCust.DataExtRetList.GetAt(j);
                                        string name = null;
                                        if (dataExt.DataExtName != null)
                                        {
                                            name = dataExt.DataExtName.GetValue();
                                            if (!columnNameList.Contains(name))
                                            {
                                                columnNameList.Add(name);
                                                dt.Columns.Add(name);
                                            }
                                        }

                                        if (dataExt.DataExtValue != null)
                                            dr[name] = dataExt.DataExtValue.GetValue();
                                    }
                                }

                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool AddCustomFieldItem(Item item)
        {
            try
            {
                try
                {
                    #region SetValueForVendor

                    sessionManager = new QBSessionManager();

                    IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                    requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                    IItemInventoryAdd itemInventoryAddRq = requestMsgSet.AppendItemInventoryAddRq();

                    if (item.Name != null)
                        itemInventoryAddRq.Name.SetValue(item.Name);

                    itemInventoryAddRq.SalesPrice.SetValue(item.Rate);
                    itemInventoryAddRq.QuantityOnHand.SetValue(item.OnHandQuantity);
                    itemInventoryAddRq.IncomeAccountRef.FullName.SetValue("Sales - Hardware");
                    itemInventoryAddRq.AssetAccountRef.FullName.SetValue("Inventory Asset");
                    itemInventoryAddRq.COGSAccountRef.FullName.SetValue("Cost of Goods Sold");


                    OpenConnection();
                    IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                    CloseConnection();
                    IResponse response = responseMsgSet.ResponseList.GetAt(0);
                    if(response.StatusCode != 0) throw new Exception($"Error: {response.StatusMessage}");
                    var itemRet = (IItemInventoryRet)response.Detail;
                    if (itemRet == null) throw new Exception($"Error: {response.StatusMessage}");
                    string itemListID = "";
                    if (itemRet.ListID != null)
                        itemListID = itemRet.ListID.GetValue();

                    #endregion

                    #region SetVendorCustomField

                    sessionManager = new QBSessionManager();

                    IMsgSetRequest requestMsgSetReq = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                    requestMsgSetReq.Attributes.OnError = ENRqOnError.roeContinue;

                    IDataExtAdd DataExtAddRq = requestMsgSetReq.AppendDataExtAddRq();
                    DataExtAddRq.OwnerID.SetValue("0"); //field visable in UI so it is "0"
                    DataExtAddRq.DataExtName.SetValue("ItemCustField"); //name of field

                    //set for customer add
                    DataExtAddRq.ORListTxnWithMacro.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetItem);
                    if (itemListID == null) throw new Exception("Item ListID is Null");
                    //give list id for cust
                    DataExtAddRq.ORListTxnWithMacro.ListDataExt.ListObjRef.ListID.SetValue(itemListID);

                    //Set field value for DataExtValue
                    DataExtAddRq.DataExtValue.SetValue(item.CustomField);
                    OpenConnection();
                    sessionManager.DoRequests(requestMsgSetReq);
                    CloseConnection();

                    #endregion

                    if (response.StatusCode != 0)
                        throw new Exception($" Error: {response.StatusMessage}");
                    else
                        return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Add Invoice OR View Invoice

        public bool AddInvoice(Invoice invoice)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceAdd InvoiceAddRq = requestMsgSet.AppendInvoiceAddRq();
                if (invoice.ListId != null)
                    InvoiceAddRq.CustomerRef.ListID.SetValue(invoice.ListId);
                if (invoice.CustomerName != null)
                    InvoiceAddRq.CustomerRef.FullName.SetValue(invoice.CustomerName);
                if (invoice.BillAddressAdd1 != null)
                    InvoiceAddRq.BillAddress.Addr1.SetValue(invoice.BillAddressAdd1);
                InvoiceAddRq.TxnDate.SetValue(DateTime.Now);
                IORInvoiceLineAdd invoiceLineAddListElement = InvoiceAddRq.ORInvoiceLineAddList.Append();
                if (invoice.Item != null)
                    invoiceLineAddListElement.InvoiceLineAdd.ItemRef.FullName.SetValue(invoice.Item);
                invoiceLineAddListElement.InvoiceLineAdd.Quantity.SetValue(invoice.Quantity);
                IORInvoiceLineAdd orInvoiceLineAdd = InvoiceAddRq.ORInvoiceLineAddList.Append();
                orInvoiceLineAdd.InvoiceLineAdd.ItemRef.FullName.SetValue(invoice.Item);
                orInvoiceLineAdd.InvoiceLineAdd.Desc.SetValue(invoice.ItemDescription);
                orInvoiceLineAdd.InvoiceLineAdd.Quantity.SetValue(Convert.ToDouble(invoice.Quantity));
                orInvoiceLineAdd.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(0.0);
                orInvoiceLineAdd.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(Convert.ToDouble(invoice.PerUnit));
                orInvoiceLineAdd.InvoiceLineAdd.Amount.SetValue(Convert.ToDouble(invoice.TotalPrice));

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");
                else
                    return response.StatusCode == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable ViewInvoice()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            bool isVerified = false;
            try
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("QuickBooksID");
                dt.Columns.Add("Date");

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IInvoiceQuery InvoiceQueryRq = requestMsgSet.AppendInvoiceQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                IInvoiceRetList invoiceRetList = (IInvoiceRetList)response.Detail;

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        if (invoiceRetList != null)
                        {
                            isVerified = true;
                            for (int i = 0; i < invoiceRetList.Count; i++)
                            {
                                IInvoiceRet invoiceRet = invoiceRetList.GetAt(i);

                                dr = dt.NewRow();
                                if (invoiceRet.CustomerRef.FullName != null)
                                    dr["Name"] = invoiceRet.CustomerRef.FullName.GetValue();
                                if (invoiceRet.CustomerRef.ListID != null)
                                    dr["QuickBooksID"] = invoiceRet.CustomerRef.ListID.GetValue();
                                if (invoiceRet.TxnDate != null)
                                    dr["Date"] = invoiceRet.TxnDate.GetValue();

                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Bills Add And View

        public bool AddBill(Bill bill)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IBillAdd billAddRq = requestMsgSet.AppendBillAddRq();
                billAddRq.defMacro.SetValue("IQBStringType");
                if (bill.VendorName != null)
                    billAddRq.VendorRef.FullName.SetValue(bill.VendorName);
                if (bill.Address != null)
                    billAddRq.VendorAddress.Addr1.SetValue(bill.Address);
                if (bill.Memo != null)
                    billAddRq.Memo.SetValue(bill.Memo);
                IORItemLineAdd itemLienAdd = billAddRq.ORItemLineAddList.Append();
                itemLienAdd.ItemLineAdd.Quantity.SetValue(bill.ItemQuantity);
                if (bill.ItemName != null)
                    itemLienAdd.ItemLineAdd.ItemRef.FullName.SetValue(bill.ItemName);
                if (bill.CustomerListID != null)
                    itemLienAdd.ItemLineAdd.CustomerRef.ListID.SetValue(bill.CustomerListID);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                IBillRet billRet = (IBillRet)response.Detail;

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");

                return response.StatusCode == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable ViewBill(Bill bill)
        {
            var dtbillQuery = new DataTable();
            DataRow drBillQuery;
            bool isVerified = false;
            try
            {
                dtbillQuery.Columns.Add("Name");
                dtbillQuery.Columns.Add("Amount");
                dtbillQuery.Columns.Add("TransactionId");
                dtbillQuery.Columns.Add("Date");

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IBillQuery BillQueryRq = requestMsgSet.AppendBillQueryRq();

                BillQueryRq.ORBillQuery.BillFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter
                    .TxnDateFilter.FromTxnDate.SetValue(DateTime.Parse(bill.FromDate));
                BillQueryRq.ORBillQuery.BillFilter.ORDateRangeFilter.TxnDateRangeFilter
                    .ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(DateTime.Parse(bill.ToDate));

                BillQueryRq.IncludeLineItems.SetValue(true);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponseList responseList = responseMsgSet.ResponseList;
                IResponse response = responseList.GetAt(0);

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtBillQueryRs)
                        {
                            isVerified = true;
                            IBillRetList billRet = (IBillRetList)response.Detail;
                            for (int j = 0; j < billRet.Count; j++)
                            {
                                drBillQuery = dtbillQuery.NewRow();

                                if (billRet.GetAt(j).VendorRef.FullName.GetValue() != null)
                                    drBillQuery["Name"] = billRet.GetAt(j).VendorRef.FullName.GetValue();
                                drBillQuery["Amount"] = billRet.GetAt(j).AmountDue.GetValue();
                                if (billRet.GetAt(j).TxnID.GetValue() != null)
                                    drBillQuery["TransactionId"] = billRet.GetAt(j).TxnID.GetValue();
                                if (billRet.GetAt(j).TxnDate.GetValue() != null)
                                    drBillQuery["Date"] = billRet.GetAt(j).TxnDate.GetValue();
                                dtbillQuery.Rows.Add(drBillQuery);
                                dtbillQuery.AcceptChanges();
                            }
                        }
                    }
                }

                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dtbillQuery;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Vendor Add and View

        public bool AddVendor(Vendor vendor)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorAdd VendorAddRq = requestMsgSet.AppendVendorAddRq();
                if (vendor.Name != null)
                    VendorAddRq.Name.SetValue(vendor.Name);
                if (vendor.CompanyName != null)
                    VendorAddRq.CompanyName.SetValue(vendor.CompanyName);
                VendorAddRq.OpenBalance.SetValue(vendor.Balance);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");

                return response.StatusCode == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

        }

        public DataTable ViewVendor()
        {
            var dt = new DataTable();
            DataRow dr;
            bool isVerified = false;
            try
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("Balance");

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorQuery VendorQueryRq = requestMsgSet.AppendVendorQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponseList responseList = responseMsgSet.ResponseList;
                IResponse response = responseList.GetAt(0);

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtVendorQueryRs)
                        {
                            isVerified = true;
                            IVendorRetList vendorRet = (IVendorRetList)response.Detail;
                            for (int j = 0; j < vendorRet.Count; j++)
                            {
                                dr = dt.NewRow();
                                if (vendorRet.GetAt(j).Name.GetValue() != null)
                                    dr["Name"] = vendorRet.GetAt(j).Name.GetValue();
                                if (vendorRet.GetAt(j).Balance.GetValue().ToString() != null)
                                    dr["Balance"] = vendorRet.GetAt(j).Balance.GetValue();
                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

        }

        public DataTable ViewCustomFieldVendor()
        {
            var dt = new DataTable();
            dt.Columns.Add("VendorName");
            DataRow dr;
            bool isVerified = false;
            try
            {
                #region RequestForVendor

                sessionManager = new QBSessionManager();

                var requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                var VendorQueryRq = requestMsgSet.AppendVendorQueryRq();

                OpenConnection();
                var responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                var response = responseMsgSet.ResponseList.GetAt(0);
                var vendorRetList = (IVendorRetList)response.Detail;

                #endregion

                #region RequestForCustomField

                sessionManager = new QBSessionManager();

                var requestMsgSetCust = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSetCust.Attributes.OnError = ENRqOnError.roeContinue;

                var VendroQueryRqCust = requestMsgSetCust.AppendVendorQueryRq();
                VendroQueryRqCust.IncludeRetElementList.Add("DataExtRet");
                // Field visble in UI so its 0
                VendroQueryRqCust.OwnerIDList.Add("0");

                OpenConnection();
                var responseMsgSetCust = sessionManager.DoRequests(requestMsgSetCust);
                CloseConnection();
                var responseCust = responseMsgSetCust.ResponseList.GetAt(0);
                var vendorRetListCust = (IVendorRetList)responseCust.Detail;

                #endregion


                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        if (vendorRetList != null)
                        {
                            var columnNameList = new List<string>();
                            isVerified = true;
                            for (int i = 0; i < vendorRetList.Count; i++)
                            {
                                var vendorRet = vendorRetList.GetAt(i);

                                dr = dt.NewRow();

                                if (vendorRet.Name != null)
                                    dr["VendorName"] = vendorRet.Name.GetValue();

                                var vendorRetCust = vendorRetListCust.GetAt(i);

                                if (vendorRetCust.DataExtRetList != null)
                                {
                                    for (int j = 0; j < vendorRetCust.DataExtRetList.Count; j++)
                                    {

                                        var dataExt = vendorRetCust.DataExtRetList.GetAt(j);
                                        string name = null;
                                        if (dataExt.DataExtName != null)
                                        {
                                            name = dataExt.DataExtName.GetValue();
                                            if (!columnNameList.Contains(name))
                                            {
                                                columnNameList.Add(name);
                                                dt.Columns.Add(name);
                                            }
                                        }

                                        if (dataExt.DataExtValue != null)
                                            dr[name] = dataExt.DataExtValue.GetValue();
                                    }
                                }

                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool AddCustomFieldVendor(Vendor vendor)
        {
            try
            {
                try
                {
                    #region SetValueForVendor

                    sessionManager = new QBSessionManager();

                    IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                    requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                    IVendorAdd VendorAddRq = requestMsgSet.AppendVendorAddRq();

                    if (vendor.Name != null)
                        VendorAddRq.Name.SetValue(vendor.Name);


                    OpenConnection();
                    IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                    CloseConnection();
                    IResponse response = responseMsgSet.ResponseList.GetAt(0);
                    var vendorRet = (IVendorRet)response.Detail;
                    string vendorListID = "";
                    if (vendorRet.ListID != null)
                        vendorListID = vendorRet.ListID.GetValue();

                    #endregion

                    #region SetVendorCustomField

                    sessionManager = new QBSessionManager();

                    IMsgSetRequest requestMsgSetReq = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                    requestMsgSetReq.Attributes.OnError = ENRqOnError.roeContinue;

                    IDataExtAdd DataExtAddRq = requestMsgSetReq.AppendDataExtAddRq();
                    DataExtAddRq.OwnerID.SetValue("0"); //field visable in UI so it is "0"
                    DataExtAddRq.DataExtName.SetValue("CustomField"); //name of field

                    //set for customer add
                    DataExtAddRq.ORListTxnWithMacro.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetVendor);
                    if (vendorListID == null) throw new Exception("Customer ListID is Null");
                    //give list id for cust
                    DataExtAddRq.ORListTxnWithMacro.ListDataExt.ListObjRef.ListID.SetValue(vendorListID);

                    //Set field value for DataExtValue
                    DataExtAddRq.DataExtValue.SetValue(vendor.CustomField);
                    OpenConnection();
                    sessionManager.DoRequests(requestMsgSetReq);
                    CloseConnection();

                    #endregion

                    if (response.StatusCode != 0)
                        throw new Exception($" Error: {response.StatusMessage}");
                    else
                        return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Account View And Add

        public bool AddAccount(Account account)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IAccountAdd AccountAddRq = requestMsgSet.AppendAccountAddRq();
                if (account.Name != null)
                    AccountAddRq.Name.SetValue(account.Name);
                AccountAddRq.AccountType.SetValue(ENAccountType.atIncome);
                if (account.Description != null)
                    AccountAddRq.Desc.SetValue(account.Description);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");

                return response.StatusCode == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

        }
        public DataTable ViewAccount()
        {
            var dt = new DataTable();
            DataRow dr;
            bool isVerified = false;
            try
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("Type");
                dt.Columns.Add("Balance");

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IAccountQuery AccountQueryRq = requestMsgSet.AppendAccountQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponseList responseList = responseMsgSet.ResponseList;
                IResponse response = responseList.GetAt(0);

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtAccountQueryRs)
                        {
                            isVerified = true;
                            IAccountRetList accountRetList = (IAccountRetList)response.Detail;
                            for (int j = 0; j < accountRetList.Count; j++)
                            {
                                dr = dt.NewRow();
                                if (accountRetList.GetAt(j).Name != null)
                                    dr["Name"] = accountRetList.GetAt(j).Name.GetValue();
                                if (accountRetList.GetAt(j).AccountType != null)
                                    dr["Type"] = accountRetList.GetAt(j).AccountType.GetValue();
                                if (accountRetList.GetAt(j).Balance != null)
                                    dr["Balance"] = accountRetList.GetAt(j).Balance.GetValue();
                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region SalesOrder Add And View

        public bool AddSalesOrder(SalesOrder salesOrder)
        {
            try
            {
                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderAdd salesOrderAddRq = requestMsgSet.AppendSalesOrderAddRq();
                if (salesOrder.CustomerRefListID != null)
                    salesOrderAddRq.CustomerRef.ListID.SetValue(salesOrder.CustomerRefListID);
                if (salesOrder.CustomerName != null)
                    salesOrderAddRq.CustomerRef.FullName.SetValue(salesOrder.CustomerName);
                if (salesOrder.Description != null)
                    salesOrderAddRq.BillAddress.Addr1.SetValue(salesOrder.Description);
                IORSalesOrderLineAdd salesOrderLineAddListElement951 = salesOrderAddRq.ORSalesOrderLineAddList.Append();
                if (salesOrder.ItemName != null)
                    salesOrderLineAddListElement951.SalesOrderLineAdd.ItemRef.FullName.SetValue(salesOrder.ItemName);
                salesOrderLineAddListElement951.SalesOrderLineAdd.Quantity.SetValue(salesOrder.ItemOrdered);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");

                return response.StatusCode == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

        }

        public DataTable ViewSalesOrder()
        {
            bool isVerified = false;
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("CustomerName");
                dt.Columns.Add("Total");

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQueryRq = requestMsgSet.AppendSalesOrderQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponseList responseList = responseMsgSet.ResponseList;
                IResponse response = responseList.GetAt(0);

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtSalesOrderQueryRs)
                        {
                            isVerified = true;
                            ISalesOrderRetList SalesOrderRet = (ISalesOrderRetList)response.Detail;
                            for (int j = 0; j < SalesOrderRet.Count; j++)
                            {
                                dr = dt.NewRow();
                                if (SalesOrderRet.GetAt(j).CustomerRef.FullName.GetValue().ToString() != null)
                                    dr["CustomerName"] = SalesOrderRet.GetAt(j).CustomerRef.FullName.GetValue();
                                if (SalesOrderRet.GetAt(j).TotalAmount.GetValue().ToString() != null)
                                    dr["Total"] = SalesOrderRet.GetAt(j).TotalAmount.GetValue();
                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            }
                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Generate Report

        public DataTable ExportExcel()
        {

            Excel.Application app = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            Excel.Range range = null;
            string path = @"C:\Users\ESTSYS\Downloads\QbReport.xlsx";

            var dt = new DataTable();
            bool isVerified = false;
            DataRow dr;
            try
            {

                app = new Excel.Application();
                workBook = app.Workbooks.Add(1);
                workSheet = (Excel.Worksheet)workBook.Sheets[1];

                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IGeneralSummaryReportQuery GeneralSummaryReportQueryRq = requestMsgSet.AppendGeneralSummaryReportQueryRq();
                GeneralSummaryReportQueryRq.GeneralSummaryReportType.SetValue(ENGeneralSummaryReportType.gsrtProfitAndLossStandard);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                IResponse response = responseList.GetAt(0);

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtGeneralSummaryReportQueryRs)
                        {
                            IReportRet ReportRet = (IReportRet)response.Detail;
                            if (ReportRet != null)
                            {
                                isVerified = true;

                                int columnNumber = 1;
                                bool isNextIsTextRow = false;
                                bool isNextSubTotalRow = false;
                                bool isDataRowHaveSubTotalRow = false;
                                bool isDataRowNextToTotalRow = false;
                                bool isNextToTextRowFirstTime = false;

                                string columnTitle = "";

                                //is data row 

                                if (ReportRet.ReportData != null)
                                {
                                    if (ReportRet.ReportData.ORReportDataList != null)
                                    {
                                        // Adding all the text row except amout
                                        #region Bind cell values 
                                        for (int rowNumber = 0; rowNumber < ReportRet.ReportData.ORReportDataList.Count; rowNumber++)
                                        {
                                            IORReportData ORReportData = ReportRet.ReportData.ORReportDataList.GetAt(rowNumber);

                                            // Text Row
                                            if (ORReportData.TextRow != null)
                                            {
                                                isNextSubTotalRow = false;
                                                isDataRowNextToTotalRow = false;

                                                if (isNextIsTextRow)
                                                {
                                                    dt.Columns.Add();
                                                    columnNumber += 1;
                                                }
                                                if (isDataRowHaveSubTotalRow)
                                                    columnNumber += 1;

                                                dr = dt.NewRow();
                                                if (ORReportData.TextRow.value != null)
                                                    columnTitle = ORReportData.TextRow.value.GetValue();
                                                if (columnTitle == "Income" || columnTitle == "Expense" || columnTitle == "Cost of Goods Sold")
                                                    columnNumber = 3;
                                                if (columnTitle == "Other Income/Expense" || columnTitle == "Ordinary Income/Expense")
                                                    columnNumber = 1;

                                                dr[columnNumber] = columnTitle;
                                                workSheet.Cells[rowNumber + 1, columnNumber + 1] = columnTitle;

                                                dt.Rows.Add(dr);
                                                dt.AcceptChanges();

                                                isNextToTextRowFirstTime = isNextIsTextRow;
                                                isDataRowHaveSubTotalRow = false;
                                                isNextIsTextRow = true;
                                            }
                                            // Data Row
                                            if (ORReportData.DataRow != null)
                                            {
                                                isNextIsTextRow = false;
                                                isNextSubTotalRow = false;
                                                isDataRowHaveSubTotalRow = true;


                                                if (isDataRowNextToTotalRow)
                                                    columnNumber -= 1;

                                                if (ORReportData.DataRow.ColDataList != null)
                                                {
                                                    dr = dt.NewRow();
                                                    string dataRow = "";
                                                    if (ORReportData.DataRow.ColDataList.GetAt(0).value != null)
                                                        dataRow = ORReportData.DataRow.ColDataList.GetAt(0).value.GetValue();

                                                    dr[columnNumber + 1] = dataRow;
                                                    workSheet.Cells[rowNumber + 1, columnNumber + 2] = dataRow;


                                                    dt.Rows.Add(dr);
                                                    dt.AcceptChanges();
                                                }

                                                isNextToTextRowFirstTime = false;
                                                isDataRowNextToTotalRow = false;
                                            }

                                            // Subtotal Row
                                            if (ORReportData.SubtotalRow != null)
                                            {
                                                if (isNextSubTotalRow)
                                                {
                                                    columnNumber -= 1;
                                                }
                                                isNextIsTextRow = false;
                                                isDataRowHaveSubTotalRow = false;

                                                if (ORReportData.SubtotalRow.ColDataList != null)
                                                {
                                                    dr = dt.NewRow();

                                                    if (ORReportData.SubtotalRow.ColDataList.GetAt(0).value != null)
                                                        columnTitle = ORReportData.SubtotalRow.ColDataList.GetAt(0).value.GetValue();

                                                    if (columnTitle == "Net Ordinary Income" || columnTitle == "Net Other Income")
                                                        columnNumber = 1;

                                                    dr[columnNumber] = columnTitle;
                                                    workSheet.Cells[rowNumber + 1, columnNumber + 1] = columnTitle;

                                                    dt.Rows.Add(dr);
                                                    dt.AcceptChanges();

                                                    isNextSubTotalRow = true;
                                                    isDataRowNextToTotalRow = true;

                                                }
                                            }

                                            // Total Row
                                            if (ORReportData.TotalRow != null)
                                            {
                                                isNextIsTextRow = false;
                                                string totalRow = "";
                                                // 1 column
                                                if (ORReportData.TotalRow.ColDataList != null)
                                                {
                                                    dr = dt.NewRow();

                                                    if (ORReportData.TotalRow.ColDataList.GetAt(0).value != null)
                                                        totalRow = ORReportData.TotalRow.ColDataList.GetAt(0).value.GetValue();
                                                    dr[0] = totalRow;
                                                    workSheet.Cells[rowNumber + 1, columnNumber] = totalRow;

                                                    dt.Rows.Add(dr);
                                                    dt.AcceptChanges();
                                                }


                                            }
                                        }
                                        #endregion

                                        // Remove empty columns 
                                        foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
                                        {
                                            if (dt.AsEnumerable().All(r => r.IsNull(column)))
                                                dt.Columns.Remove(column);
                                        }

                                        //Set all the cell style to bold before add the column amount
                                        range = workSheet.UsedRange;
                                        range.Font.Bold = true;

                                        // Amount Row
                                        #region amount row

                                        dt.Columns.Add();

                                        int colNumber = dt.Columns.Count - 1;


                                        for (int rowNumber = 0; rowNumber < ReportRet.ReportData.ORReportDataList.Count; rowNumber++)
                                        {
                                            IORReportData ORReportData = ReportRet.ReportData.ORReportDataList.GetAt(rowNumber);
                                            // Text Row
                                            if (ORReportData.TextRow != null)
                                            {
                                                dt.Rows[rowNumber][colNumber] = " ";
                                            }
                                            // Data Row
                                            if (ORReportData.DataRow != null)
                                            {
                                                if (ORReportData.DataRow.ColDataList != null)
                                                {
                                                    string dataRow = null;
                                                    if (ORReportData.DataRow.ColDataList.GetAt(1).value != null)
                                                        dataRow = ORReportData.DataRow.ColDataList.GetAt(1).value.GetValue();

                                                    if (dataRow != null)
                                                    {
                                                        dt.Rows[rowNumber][colNumber] = dataRow;
                                                        workSheet.Cells[rowNumber + 1, colNumber + 1] = dataRow;
                                                    }


                                                }
                                            }

                                            // Subtotal Row
                                            if (ORReportData.SubtotalRow != null)
                                            {
                                                if (ORReportData.SubtotalRow.ColDataList != null)
                                                {
                                                    string subTotalRow = null;
                                                    if (ORReportData.SubtotalRow.ColDataList.GetAt(1).value != null)
                                                        subTotalRow = ORReportData.SubtotalRow.ColDataList.GetAt(1).value.GetValue();
                                                    if (subTotalRow != null)
                                                    {
                                                        dt.Rows[rowNumber][colNumber] = subTotalRow;
                                                        workSheet.Cells[rowNumber + 1, colNumber + 1] = subTotalRow;
                                                    }
                                                }
                                            }

                                            // Total Row
                                            if (ORReportData.TotalRow != null)
                                            {
                                                if (ORReportData.TotalRow.ColDataList != null)
                                                {
                                                    string totaleRow = null;
                                                    if (ORReportData.TotalRow.ColDataList.GetAt(1).value != null)
                                                        totaleRow = ORReportData.TotalRow.ColDataList.GetAt(1).value.GetValue();
                                                    if (totaleRow != null)
                                                    {
                                                        dt.Rows[rowNumber][colNumber] = totaleRow;
                                                        workSheet.Cells[rowNumber + 1, colNumber + 1] = totaleRow;
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                        //Amount row end

                                        // Grouping
                                        #region Group

                                        range = workSheet.UsedRange;
                                        int startRow = 1;
                                        int endRow = ReportRet.ReportData.ORReportDataList.Count - 1;


                                        range = workSheet.get_Range($"a{startRow}", $"a{endRow}");
                                        range.Rows.Group();

                                        for (int col = 1; col < dt.Columns.Count - 1; col++)
                                        {
                                            for (int rowNumber = 0; rowNumber < ReportRet.ReportData.ORReportDataList.Count; rowNumber++)
                                            {

                                                IORReportData ORReportData = ReportRet.ReportData.ORReportDataList.GetAt(rowNumber);

                                                // Text Row
                                                if (ORReportData.TextRow != null)
                                                {
                                                    if (!string.IsNullOrEmpty(dt.Rows[rowNumber][col].ToString()))
                                                    {
                                                        startRow = rowNumber + 1;

                                                    }
                                                }
                                                // Data Row
                                                if (ORReportData.DataRow != null)
                                                {

                                                }

                                                // Subtotal Row
                                                if (ORReportData.SubtotalRow != null)
                                                {
                                                    if (!string.IsNullOrEmpty(dt.Rows[rowNumber][col].ToString()))
                                                    {

                                                        endRow = rowNumber;
                                                        if (startRow > endRow)
                                                        {
                                                            startRow = 2;

                                                        }
                                                        range = workSheet.get_Range($"a{startRow}", $"a{endRow}");
                                                        range.Rows.Group();
                                                    }
                                                }

                                            }
                                        }
                                        #endregion
                                        // End Grouping

                                    }
                                }


                            }

                            string reporTitle = ReportRet.ReportTitle.GetValue();
                            string reporSubTitle = ReportRet.ReportSubtitle.GetValue();
                            string colTitle = "";
                            if (ReportRet.ColDescList != null)
                            {
                                for (int i = 0; i < ReportRet.ColDescList.Count; i++)
                                {
                                    IColDesc ColDesc = ReportRet.ColDescList.GetAt(i);
                                    if (ColDesc.ColTitleList != null)
                                    {
                                        for (int j = 0; j < ColDesc.ColTitleList.Count; j++)
                                        {
                                            if (ColDesc.ColTitleList.GetAt(j).value != null)
                                                colTitle = ColDesc.ColTitleList.GetAt(j).value.GetValue();
                                        }
                                    }
                                }
                            }

                            range = (Excel.Range)workSheet.Rows[1];
                            range.Insert();
                            workSheet.Cells[1, dt.Columns.Count] = colTitle;
                            workSheet.Cells[1, dt.Columns.Count].Font.Bold = true;
                            workSheet.Cells[1, dt.Columns.Count].Font.Size = 12;
                            workSheet.Cells[1, dt.Columns.Count].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;

                            range = (Excel.Range)workSheet.Rows[1];
                            range.Insert();
                            workSheet.Cells[1, 1] = reporSubTitle;
                            workSheet.Cells[1, 1].Font.Bold = true;

                            range = (Excel.Range)workSheet.Rows[1];
                            range.Insert();
                            workSheet.Cells[1, 1] = reporTitle;
                            workSheet.Cells[1, 1].Font.Bold = true;

                            range = (Excel.Range)workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, dt.Columns.Count - 1]];
                            range.Merge();
                            range = (Excel.Range)workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[2, dt.Columns.Count - 1]];
                            range.Merge();
                            range = (Excel.Range)workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[2, dt.Columns.Count - 1]];
                            range.Font.Bold = true;
                            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                            range.Font.Size = 14;
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                app.ActiveWindow.SplitRow = 3;
                app.ActiveWindow.SplitColumn = dt.Columns.Count - 1;
                app.ActiveWindow.FreezePanes = true;
                range = workSheet.UsedRange;
                range.Columns.AutoFit();
                workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);
                workBook = null;
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);

                    workBook.Close(true);
                }
                workBook = null;
                if (app != null)
                {
                    app.Quit();
                }
                Marshal.ReleaseComObject(app);
                CloseConnection();
            }
        }

        public DataTable ReportProfitAndLossByJob()
        {
            // Initialize variable for Excel
            Excel.Application app = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            Excel.Range range = null;
            string path = @"C:\Users\ESTSYS\Downloads\QbReport.xlsx";

            var dt = new DataTable();
            bool isVerified = false;
            DataRow dr;

            try
            {

                app = new Excel.Application();
                workBook = app.Workbooks.Add(1);
                workSheet = (Excel.Worksheet)workBook.Sheets[1];

                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();

                sessionManager = new QBSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(countryQB, majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IGeneralSummaryReportQuery GeneralSummaryReportQueryRq = requestMsgSet.AppendGeneralSummaryReportQueryRq();
                GeneralSummaryReportQueryRq.GeneralSummaryReportType.SetValue(ENGeneralSummaryReportType.gsrtProfitAndLossByJob);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                IResponse response = responseList.GetAt(0);

                if (response.StatusCode >= 0)
                {
                    if (response.Detail != null)
                    {
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtGeneralSummaryReportQueryRs)
                        {
                            IReportRet ReportRet = (IReportRet)response.Detail;
                            if (ReportRet != null)
                            {
                                isVerified = true;

                                // Get Total Amount Column
                                int numColumns = ReportRet.NumColumns.GetValue();

                                int columnNumber = 1;
                                bool isNextIsTextRow = false;
                                bool isNextSubTotalRow = false;
                                bool isDataRowHaveSubTotalRow = false;
                                bool isDataRowNextToTotalRow = false;
                                bool isNextToTextRowFirstTime = false;

                                int totalTextColumn = 0;
                                string columnTitle = "";


                                if (ReportRet.ReportData != null)
                                {
                                    if (ReportRet.ReportData.ORReportDataList != null)
                                    {
                                        // Adding all the text row except amout
                                        #region Bind cell values 

                                        for (int rowNumber = 0; rowNumber < ReportRet.ReportData.ORReportDataList.Count; rowNumber++)
                                        {
                                            IORReportData ORReportData = ReportRet.ReportData.ORReportDataList.GetAt(rowNumber);

                                            // Text Row
                                            if (ORReportData.TextRow != null)
                                            {
                                                isNextSubTotalRow = false;
                                                isDataRowNextToTotalRow = false;

                                                if (isNextIsTextRow)
                                                {
                                                    dt.Columns.Add();
                                                    columnNumber += 1;
                                                }
                                                if (isDataRowHaveSubTotalRow)
                                                    columnNumber += 1;

                                                dr = dt.NewRow();
                                                if (ORReportData.TextRow.value != null)
                                                    columnTitle = ORReportData.TextRow.value.GetValue();
                                                if (columnTitle == "Income" || columnTitle == "Expense" || columnTitle == "Cost of Goods Sold")
                                                    columnNumber = 3;
                                                if (columnTitle == "Other Income/Expense" || columnTitle == "Ordinary Income/Expense")
                                                    columnNumber = 1;

                                                dr[columnNumber] = columnTitle;
                                                workSheet.Cells[rowNumber + 1, columnNumber + 1] = columnTitle;

                                                dt.Rows.Add(dr);
                                                dt.AcceptChanges();

                                                isNextToTextRowFirstTime = isNextIsTextRow;
                                                isDataRowHaveSubTotalRow = false;
                                                isNextIsTextRow = true;
                                            }
                                            // Data Row
                                            if (ORReportData.DataRow != null)
                                            {
                                                isNextIsTextRow = false;
                                                isNextSubTotalRow = false;
                                                isDataRowHaveSubTotalRow = true;


                                                if (isDataRowNextToTotalRow)
                                                    columnNumber -= 1;

                                                if (ORReportData.DataRow.ColDataList != null)
                                                {
                                                    dr = dt.NewRow();
                                                    string dataRow = "";
                                                    if (ORReportData.DataRow.ColDataList.GetAt(0).value != null)
                                                        dataRow = ORReportData.DataRow.ColDataList.GetAt(0).value.GetValue();

                                                    dr[columnNumber + 1] = dataRow;
                                                    workSheet.Cells[rowNumber + 1, columnNumber + 2] = dataRow;


                                                    dt.Rows.Add(dr);
                                                    dt.AcceptChanges();
                                                }

                                                isNextToTextRowFirstTime = false;
                                                isDataRowNextToTotalRow = false;
                                            }

                                            // Subtotal Row
                                            if (ORReportData.SubtotalRow != null)
                                            {
                                                if (isNextSubTotalRow)
                                                {
                                                    columnNumber -= 1;
                                                }
                                                isNextIsTextRow = false;
                                                isDataRowHaveSubTotalRow = false;

                                                if (ORReportData.SubtotalRow.ColDataList != null)
                                                {
                                                    dr = dt.NewRow();

                                                    if (ORReportData.SubtotalRow.ColDataList.GetAt(0).value != null)
                                                        columnTitle = ORReportData.SubtotalRow.ColDataList.GetAt(0).value.GetValue();

                                                    if (columnTitle == "Net Ordinary Income" || columnTitle == "Net Other Income")
                                                        columnNumber = 1;

                                                    dr[columnNumber] = columnTitle;
                                                    workSheet.Cells[rowNumber + 1, columnNumber + 1] = columnTitle;

                                                    dt.Rows.Add(dr);
                                                    dt.AcceptChanges();

                                                    isNextSubTotalRow = true;
                                                    isDataRowNextToTotalRow = true;

                                                }
                                            }

                                            // Total Row
                                            if (ORReportData.TotalRow != null)
                                            {
                                                isNextIsTextRow = false;
                                                string totalRow = "";
                                                // 1 column
                                                if (ORReportData.TotalRow.ColDataList != null)
                                                {
                                                    dr = dt.NewRow();

                                                    if (ORReportData.TotalRow.ColDataList.GetAt(0).value != null)
                                                        totalRow = ORReportData.TotalRow.ColDataList.GetAt(0).value.GetValue();
                                                    dr[0] = totalRow;
                                                    workSheet.Cells[rowNumber + 1, columnNumber] = totalRow;

                                                    dt.Rows.Add(dr);
                                                    dt.AcceptChanges();
                                                }


                                            }
                                        }
                                        #endregion

                                        // Remove empty columns 
                                        foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
                                        {
                                            if (dt.AsEnumerable().All(r => r.IsNull(column)))
                                                dt.Columns.Remove(column);
                                        }

                                        totalTextColumn = dt.Columns.Count;
                                        //Set all the cell style to bold before add the column amount
                                        range = workSheet.UsedRange;
                                        range.Font.Bold = true;

                                        // Region -  Amount Row 
                                        #region amount row

                                        for (int colNumber = 1; colNumber < numColumns; colNumber++)
                                        {
                                            dt.Columns.Add();

                                            for (int rowNumber = 0; rowNumber < ReportRet.ReportData.ORReportDataList.Count; rowNumber++)
                                            {
                                                IORReportData ORReportData = ReportRet.ReportData.ORReportDataList.GetAt(rowNumber);

                                                // Text Row
                                                if (ORReportData.TextRow != null)
                                                {
                                                    dt.Rows[rowNumber][colNumber + totalTextColumn - 1] = " ";
                                                }
                                                // Data Row
                                                if (ORReportData.DataRow != null)
                                                {
                                                    if (ORReportData.DataRow.ColDataList != null)
                                                    {
                                                        string dataRow = null;
                                                        if (ORReportData.DataRow.ColDataList.GetAt(colNumber).value != null)
                                                            dataRow = ORReportData.DataRow.ColDataList.GetAt(colNumber).value.GetValue();

                                                        if (dataRow != null)
                                                        {
                                                            dt.Rows[rowNumber][colNumber + totalTextColumn - 1] = dataRow;
                                                            workSheet.Cells[rowNumber + 1, colNumber + totalTextColumn] = dataRow;
                                                        }


                                                    }
                                                }

                                                // Subtotal Row
                                                if (ORReportData.SubtotalRow != null)
                                                {
                                                    if (ORReportData.SubtotalRow.ColDataList != null)
                                                    {
                                                        string subTotalRow = null;
                                                        if (ORReportData.SubtotalRow.ColDataList.GetAt(colNumber).value != null)
                                                            subTotalRow = ORReportData.SubtotalRow.ColDataList.GetAt(colNumber).value.GetValue();
                                                        if (subTotalRow != null)
                                                        {
                                                            dt.Rows[rowNumber][colNumber + totalTextColumn - 1] = subTotalRow;
                                                            workSheet.Cells[rowNumber + 1, colNumber + totalTextColumn] = subTotalRow;
                                                        }
                                                    }
                                                }

                                                // Total Row
                                                if (ORReportData.TotalRow != null)
                                                {
                                                    if (ORReportData.TotalRow.ColDataList != null)
                                                    {
                                                        string totaleRow = null;
                                                        if (ORReportData.TotalRow.ColDataList.GetAt(colNumber).value != null)
                                                            totaleRow = ORReportData.TotalRow.ColDataList.GetAt(colNumber).value.GetValue();
                                                        if (totaleRow != null)
                                                        {
                                                            dt.Rows[rowNumber][colNumber + totalTextColumn - 1] = totaleRow;
                                                            workSheet.Cells[rowNumber + 1, colNumber + totalTextColumn] = totaleRow;
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                        #endregion
                                        //Amount row end



                                        // Grouping
                                        #region Group

                                        range = workSheet.UsedRange;
                                        int startRow = 1;
                                        int endRow = ReportRet.ReportData.ORReportDataList.Count - 1;


                                        range = workSheet.get_Range($"a{startRow}", $"a{endRow}");
                                        range.Rows.Group();

                                        for (int col = 1; col < totalTextColumn; col++)
                                        {
                                            for (int rowNumber = 0; rowNumber < ReportRet.ReportData.ORReportDataList.Count; rowNumber++)
                                            {

                                                IORReportData ORReportData = ReportRet.ReportData.ORReportDataList.GetAt(rowNumber);

                                                // Text Row
                                                if (ORReportData.TextRow != null)
                                                {
                                                    if (!string.IsNullOrEmpty(dt.Rows[rowNumber][col].ToString()))
                                                    {
                                                        startRow = rowNumber + 1;

                                                    }
                                                }
                                                // Data Row
                                                if (ORReportData.DataRow != null)
                                                {

                                                }

                                                // Subtotal Row
                                                if (ORReportData.SubtotalRow != null)
                                                {
                                                    if (!string.IsNullOrEmpty(dt.Rows[rowNumber][col].ToString()))
                                                    {

                                                        endRow = rowNumber;
                                                        if (startRow > endRow)
                                                        {
                                                            startRow = 2;

                                                        }
                                                        range = workSheet.get_Range($"a{startRow}", $"a{endRow}");
                                                        range.Rows.Group();
                                                    }
                                                }

                                            }
                                        }

                                        #endregion
                                        // End Grouping


                                    }
                                }

                                // Add Column Titles
                                string colTitle = "";
                                int colIndex = totalTextColumn;

                                range = (Excel.Range)workSheet.Rows[1];
                                range.Insert();
                                range.Insert();
                                if (ReportRet.ColDescList != null)
                                {
                                    for (int i = 1; i < ReportRet.ColDescList.Count; i++)
                                    {
                                        IColDesc ColDesc = ReportRet.ColDescList.GetAt(i);
                                        if (ColDesc.ColTitleList != null)
                                        {
                                            if (ColDesc.ColTitleList.GetAt(0).value != null)
                                            {
                                                colTitle = ColDesc.ColTitleList.GetAt(0).value.GetValue();

                                                workSheet.Cells[1, colIndex + i] = colTitle;
                                                workSheet.Cells[1, colIndex + i].Font.Bold = true;
                                                workSheet.Cells[1, colIndex + i].Font.Size = 8;
                                            }
                                            if (ColDesc.ColTitleList.GetAt(1).value != null)
                                            {
                                                colTitle = ColDesc.ColTitleList.GetAt(1).value.GetValue();

                                                workSheet.Cells[2, colIndex + i] = colTitle;
                                                workSheet.Cells[2, colIndex + i].Font.Bold = true;
                                                workSheet.Cells[2, colIndex + i].Font.Size = 8;
                                                workSheet.Cells[2, colIndex + i].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
                                            }
                                        }
                                    }
                                }

                                string reporTitle = ReportRet.ReportTitle.GetValue();
                                string reporSubTitle = ReportRet.ReportSubtitle.GetValue();




                                range = (Excel.Range)workSheet.Rows[1];
                                range.Insert();
                                workSheet.Cells[1, 1] = reporSubTitle;
                                workSheet.Cells[1, 1].Font.Bold = true;

                                range = (Excel.Range)workSheet.Rows[1];
                                range.Insert();
                                workSheet.Cells[1, 1] = reporTitle;
                                workSheet.Cells[1, 1].Font.Bold = true;

                                range = (Excel.Range)workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, totalTextColumn]];
                                range.Merge();
                                range = (Excel.Range)workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[2, totalTextColumn]];
                                range.Merge();
                                range = (Excel.Range)workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[2, totalTextColumn]];
                                range.Font.Bold = true;
                                range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                                range.Font.Size = 12;
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                // Split The Row
                                app.ActiveWindow.SplitRow = 4;
                                app.ActiveWindow.SplitColumn = totalTextColumn;
                                app.ActiveWindow.FreezePanes = true;

                            }



                        }
                    }
                }
                if (!isVerified)
                {
                    throw new Exception($" Error: {response.StatusMessage}");
                }

                range = workSheet.UsedRange;
                range.Columns.AutoFit();
                workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);
                workBook = null;
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);

                    workBook.Close(true);
                }
                workBook = null;
                if (app != null)
                {
                    app.Quit();
                }
                Marshal.ReleaseComObject(app);
                CloseConnection();
            }
        }

        #endregion

    }
}
