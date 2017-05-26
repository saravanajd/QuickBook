using System;
using Interop.qbposfc3;
using System.Data;
using QB.DAL;
using System.Collections.Generic;

namespace QB.DataAccess
{
    public class QuickBookPOS
    {

        QBPOSSessionManager sessionManager = null;

        private bool isConnectionOpened = false;
        private bool isSessionBegined = false;

        private short majorVersionQB = 3;
        private short minorVersionQB = 0;

        private string qbAppId = "QuickBooks";
        private string qbAppName = "QuickBooks";
        // Leave it blank for automatically find the POS server
        private string qbFileName = "Computer Name=estsys17;Company Data=mycompany;Version=12";

        #region Open and Close Connecion

        private void OpenConnection()
        {
            try
            {
                if (sessionManager == null)
                {
                    sessionManager = new QBPOSSessionManager();
                }
                if (!isConnectionOpened)
                {
                    sessionManager.OpenConnection(qbAppId, qbAppName);
                    isConnectionOpened = true;
                }

                if (!isSessionBegined)
                {
                    sessionManager.BeginSession(qbFileName);
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
                    sessionManager.CloseConnection();
                    isConnectionOpened = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Customer

        public bool AddCustomer(Customer customer)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerAdd customerAddRq = requestMsgSet.AppendCustomerAddRq();
                customerAddRq.FirstName.SetValue(customer.FirstName);
                customerAddRq.LastName.SetValue(customer.LastName);
                if (!string.IsNullOrEmpty(customer.BillAddressAdd1))
                    customerAddRq.BillAddress.Street.SetValue(customer.BillAddressAdd1);
                if (!string.IsNullOrEmpty(customer.BillAddressCity))
                    customerAddRq.BillAddress.City.SetValue(customer.BillAddressCity);
                if (!string.IsNullOrEmpty(customer.BillAddressState))
                    customerAddRq.BillAddress.State.SetValue(customer.BillAddressState);
                if (!string.IsNullOrEmpty(customer.BillAddressPostalCode))
                    customerAddRq.BillAddress.PostalCode.SetValue(customer.BillAddressPostalCode);
                if (!string.IsNullOrEmpty(customer.Phone))
                    customerAddRq.Phone.SetValue(customer.Phone);

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
                dt.Columns.Add("Email");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Company");

                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;
                ICustomerQuery CustomerQueryRq = requestMsgSet.AppendCustomerQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($" Error: {responseList.Count}");
                for (int j = 0; j < responseList.Count; j++)
                {
                    IResponse response = responseList.GetAt(j);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtCustomerQueryRs)
                            {
                                ICustomerRetList CustomerRet = (ICustomerRetList)response.Detail;

                                isVerified = true;
                                for (int i = 0; i < CustomerRet.Count; i++)
                                {
                                    ICustomerRet customerRet = CustomerRet.GetAt(i);

                                    if (customerRet != null)
                                    {
                                        dr = dt.NewRow();
                                        if (customerRet.FullName != null)
                                            dr["Name"] = customerRet.FullName.GetValue();
                                        if (customerRet.ListID != null)
                                            dr["QuickBooksID"] = customerRet.ListID.GetValue();
                                        if (customerRet.EMail != null)
                                            dr["Email"] = customerRet.EMail.GetValue();
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
                    }
                    if (!isVerified) throw new Exception($" Error: {response.StatusMessage}");
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
        public Customer GetCustomer(string ListID)
        {
            var customer = new Customer();

            bool isVerified = false;
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;
                ICustomerQuery CustomerQueryRq = requestMsgSet.AppendCustomerQueryRq();
                CustomerQueryRq.ListID.SetValue(ListID);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($" Error: Reponse List is Null");
                for (int j = 0; j < responseList.Count; j++)
                {
                    IResponse response = responseList.GetAt(j);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtCustomerQueryRs)
                            {
                                ICustomerRetList CustomerRet = (ICustomerRetList)response.Detail;
                                if (CustomerRet != null)
                                {
                                    isVerified = true;
                                    for (int i = 0; i < CustomerRet.Count; i++)
                                    {
                                        ICustomerRet customerRet = CustomerRet.GetAt(i);

                                        if (customerRet != null)
                                        {
                                            if (customerRet.FirstName == null) throw new Exception($" Customer Dont have a firstname");
                                            customer.FirstName = customerRet.FirstName.GetValue();
                                            if (customerRet.ListID != null)
                                                customer.ListId = customerRet.ListID.GetValue();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!isVerified) throw new Exception($" Error: {response.StatusMessage}");
                }
                return customer;

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

        public DataTable ViewCustomFieldCustomer()
        {
            var dt = new DataTable();
            dt.Columns.Add("CustomerName");
            DataRow dr;
            bool isVerified = false;
            try
            {
                #region RequestForCustomer
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerQuery CustomerQueryRq = requestMsgSet.AppendCustomerQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                ICustomerRetList customerRetList = (ICustomerRetList)response.Detail;
                #endregion

                #region RequestForCustomField

                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSetCust = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
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
                    sessionManager = new QBPOSSessionManager();

                    IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                    requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                    ICustomerAdd customerAddRq = requestMsgSet.AppendCustomerAddRq();

                    if (customer.FirstName != null)
                        customerAddRq.FirstName.SetValue(customer.FirstName);
                    if (customer.LastName != null)
                        customerAddRq.LastName.SetValue(customer.LastName);


                    OpenConnection();
                    IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                    CloseConnection();
                    IResponse response = responseMsgSet.ResponseList.GetAt(0);
                    var customerRet = (ICustomerRet)response.Detail;
                    string customerListID = "";
                    if (customerRet.ListID != null)
                        customerListID = customerRet.ListID.GetValue();

                    sessionManager = new QBPOSSessionManager();

                    IMsgSetRequest requestMsgSetReq = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                    requestMsgSetReq.Attributes.OnError = ENRqOnError.roeContinue;

                    IDataExtAdd DataExtAddRq = requestMsgSetReq.AppendDataExtAddRq();
                    DataExtAddRq.OwnerID.SetValue("0"); //field visable in UI so it is "0"
                    DataExtAddRq.DataExtName.SetValue("CustomField"); //name of field

                    //set for customer add
                    DataExtAddRq.ORDataExtOwner.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer);
                    if (customerListID == null) throw new Exception("Customer ListID is Null");
                    //give list id for cust
                    DataExtAddRq.ORDataExtOwner.ListDataExt.ListObjRef.ListID.SetValue(customerListID);

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
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ICustomerMod CustomerModRq = requestMsgSet.AppendCustomerModRq();
                CustomerModRq.FirstName.SetValue(customer.FirstName);
                if (!string.IsNullOrEmpty(customer.ListId))
                    CustomerModRq.ListID.SetValue(customer.ListId);

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

        #endregion

        #region Item

        public bool AddItem(Item item)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IItemInventoryAdd ItemInventoryAddRq = requestMsgSet.AppendItemInventoryAddRq();
                ItemInventoryAddRq.Price1.SetValue(item.Rate);
                if (item.Name != null)
                    ItemInventoryAddRq.Desc1.SetValue(item.Name);
                if (item.DepartmentListId != null)
                    ItemInventoryAddRq.DepartmentListID.SetValue(item.DepartmentListId);


                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                IItemInventoryRet itemInventoryRet = (IItemInventoryRet)response.Detail;

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");

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
        public DataTable ViewItem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item ListId");
            dt.Columns.Add("Item Name");
            dt.Columns.Add("Department");
            dt.Columns.Add("Item Description");
            dt.Columns.Add("On-hand Qty");
            DataRow dr;

            try
            {
                sessionManager = new QBPOSSessionManager();
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IItemInventoryQuery ItemInventoryQueryRq = requestMsgSet.AppendItemInventoryQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                if (responseMsgSet == null) throw new Exception($"ReponseMessageSet is Empty");
                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($"ReturnLinst is Empty");
                for (int i = 0; i < responseList.Count; i++)
                {
                    IResponse response = responseList.GetAt(i);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtItemInventoryQueryRs)
                            {
                                IItemInventoryRetList ItemInventoryRet = (IItemInventoryRetList)response.Detail;
                                for (int j = 0; j < ItemInventoryRet.Count; j++)
                                {
                                    dr = dt.NewRow();
                                    if (!string.IsNullOrEmpty(Convert.ToString(ItemInventoryRet.GetAt(j).ListID)))
                                    {
                                        dr["Item ListId"] = ItemInventoryRet.GetAt(j).ListID.GetValue().ToString();
                                    }
                                    if (!string.IsNullOrEmpty(Convert.ToString(ItemInventoryRet.GetAt(j).Desc1)))
                                    {
                                        dr["Item Name"] = ItemInventoryRet.GetAt(j).Desc1.GetValue().ToString();
                                    }
                                    if (!string.IsNullOrEmpty(Convert.ToString(ItemInventoryRet.GetAt(j).DepartmentCode)))
                                    {
                                        dr["Department"] = ItemInventoryRet.GetAt(j).DepartmentCode.GetValue().ToString();
                                    }
                                    if (!string.IsNullOrEmpty(Convert.ToString(ItemInventoryRet.GetAt(j).Desc2)))
                                    {
                                        dr["Item Description"] = ItemInventoryRet.GetAt(j).Desc2.GetValue().ToString();
                                    }
                                    if (!string.IsNullOrEmpty(Convert.ToString(ItemInventoryRet.GetAt(j).QuantityOnHand)))
                                    {
                                        dr["On-hand Qty"] = ItemInventoryRet.GetAt(j).QuantityOnHand.GetValue().ToString();
                                    }
                                    dt.Rows.Add(dr);

                                }
                            }

                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
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

                sessionManager = new QBPOSSessionManager();

                var requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                var itemQueryRq = requestMsgSet.AppendItemInventoryQueryRq();

                OpenConnection();
                var responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                var response = responseMsgSet.ResponseList.GetAt(0);
                var itemRetList = (IItemInventoryRetList)response.Detail;

                #endregion

                #region RequestForCustomField

                sessionManager = new QBPOSSessionManager();

                var requestMsgSetCust = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
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

                                if (itemRet.Desc1 != null)
                                    dr["ItemName"] = itemRet.Desc1.GetValue();

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

                    sessionManager = new QBPOSSessionManager();

                    IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                    requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                    IItemInventoryAdd itemInventoryAddRq = requestMsgSet.AppendItemInventoryAddRq();


                    if (item.Name != null)
                        itemInventoryAddRq.Desc1.SetValue(item.Name);
                    if (item.DepartmentListId != null)
                        itemInventoryAddRq.DepartmentListID.SetValue(item.DepartmentListId);


                    OpenConnection();
                    IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                    CloseConnection();
                    IResponse response = responseMsgSet.ResponseList.GetAt(0);
                    if (response.StatusCode != 0) throw new Exception($"Error: {response.StatusMessage}");
                    var itemRet = (IItemInventoryRet)response.Detail;
                    if (itemRet == null) throw new Exception($"Error: {response.StatusMessage}");
                    string itemListID = "";
                    if (itemRet.ListID != null)
                        itemListID = itemRet.ListID.GetValue();

                    #endregion

                    #region SetVendorCustomField

                    sessionManager = new QBPOSSessionManager();

                    IMsgSetRequest requestMsgSetReq = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                    requestMsgSetReq.Attributes.OnError = ENRqOnError.roeContinue;

                    IDataExtAdd DataExtAddRq = requestMsgSetReq.AppendDataExtAddRq();
                    DataExtAddRq.OwnerID.SetValue("0"); //field visable in UI so it is "0"
                    DataExtAddRq.DataExtName.SetValue("ItemCustField"); //name of field

                    //set for Item add
                    DataExtAddRq.ORDataExtOwner.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetItemInventory);
                    if (itemListID == null) throw new Exception("Item ListID is Null");
                    //give list id for cust
                    DataExtAddRq.ORDataExtOwner.ListDataExt.ListObjRef.ListID.SetValue(itemListID);

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
        public bool UpdateItem(Item item)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IItemInventoryMod ItemInventoryAddRq = requestMsgSet.AppendItemInventoryModRq();
                ItemInventoryAddRq.Price1.SetValue(item.Rate);
                if (item.Name != null)
                    ItemInventoryAddRq.Desc1.SetValue(item.Name);
                if (item.ListID!= null)
                    ItemInventoryAddRq.ListID.SetValue(item.ListID);


                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                IResponse response = responseMsgSet.ResponseList.GetAt(0);

                if (response.StatusCode != 0)
                    throw new Exception($" Error: {response.StatusMessage}");

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

        public Item GetItem(string listID)
        {
            var item = new Item();
            try
            {
                sessionManager = new QBPOSSessionManager();
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IItemInventoryQuery ItemInventoryQueryRq = requestMsgSet.AppendItemInventoryQueryRq();
                ItemInventoryQueryRq.ListID.SetValue(listID);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                if (responseMsgSet == null) throw new Exception($"ReponseMessageSet is Empty");
                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($"ReturnLinst is Empty");
                for (int i = 0; i < responseList.Count; i++)
                {
                    IResponse response = responseList.GetAt(i);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtItemInventoryQueryRs)
                            {
                                IItemInventoryRetList ItemInventoryRet = (IItemInventoryRetList)response.Detail;
                                for (int j = 0; j < ItemInventoryRet.Count; j++)
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ItemInventoryRet.GetAt(j).ListID)))
                                    {
                                        item.ListID = ItemInventoryRet.GetAt(j).ListID.GetValue().ToString();
                                    }
                                    if (!string.IsNullOrEmpty(Convert.ToString(ItemInventoryRet.GetAt(j).Desc1)))
                                    {
                                        item.Name= ItemInventoryRet.GetAt(j).Desc1.GetValue().ToString();
                                    }
                                }
                            }

                        }
                    }
                }
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Department

        public DataTable ViewDepartment()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Department Name");
            dt.Columns.Add("Code");
            dt.Columns.Add("ListID");
            bool isVerified = false;
            DataRow dr;
            try
            {

                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IDepartmentQuery DepartmentQueryRq = requestMsgSet.AppendDepartmentQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($" Error: {responseList.Count}");
                for (int j = 0; j < responseList.Count; j++)
                {
                    IResponse response = responseList.GetAt(j);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtDepartmentQueryRs)
                            {
                                IDepartmentRetList DepartmentRetList = (IDepartmentRetList)response.Detail;


                                if (DepartmentRetList != null)
                                {
                                    isVerified = true;
                                    for (int i = 0; i < DepartmentRetList.Count; i++)
                                    {
                                        IDepartmentRet DepartmentRet = DepartmentRetList.GetAt(i);
                                        if (DepartmentRet != null)
                                        {
                                            dr = dt.NewRow();
                                            if (DepartmentRet.DepartmentName != null)
                                                dr["Department Name"] = DepartmentRet.DepartmentName.GetValue();
                                            if (DepartmentRet.DepartmentCode != null)
                                                dr["Code"] = DepartmentRet.DepartmentCode.GetValue();
                                            if (DepartmentRet.ListID != null)
                                                dr["ListID"] = DepartmentRet.ListID.GetValue();

                                            dt.Rows.Add(dr);
                                            dt.AcceptChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!isVerified) throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddDepartment(Department dept)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IDepartmentAdd DepartmentAddRq = requestMsgSet.AppendDepartmentAddRq();
                DepartmentAddRq.DepartmentCode.SetValue(dept.DepartmentCode);
                DepartmentAddRq.DepartmentName.SetValue(dept.DepartmentName);

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
        }


        #endregion

        #region SalesOrder

        public DataTable ViewSalesOrder()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName");
            dt.Columns.Add("Order Date");
            dt.Columns.Add("Total");
            bool isVerified = false;
            DataRow dr;
            try
            {

                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderQuery SalesOrderQueryRq = requestMsgSet.AppendSalesOrderQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($" Error: {responseList.Count}");
                for (int j = 0; j < responseList.Count; j++)
                {
                    IResponse response = responseList.GetAt(j);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtSalesOrderQueryRs)
                            {
                                ISalesOrderRetList SalesOrderRetList = (ISalesOrderRetList)response.Detail;


                                if (SalesOrderRetList != null)
                                {
                                    isVerified = true;
                                    for (int i = 0; i < SalesOrderRetList.Count; i++)
                                    {
                                        var SalesOrderRet = SalesOrderRetList.GetAt(i);
                                        if (SalesOrderRet != null)
                                        {
                                            dr = dt.NewRow();
                                            if (SalesOrderRet.BillingInformation.FirstName != null)
                                                dr["FullName"] = SalesOrderRet.BillingInformation.FirstName.GetValue();
                                            if (SalesOrderRet.TxnDate != null)
                                                dr["Order Date"] = SalesOrderRet.TxnDate.GetValue();
                                            if (SalesOrderRet.Total != null)
                                                dr["Total"] = SalesOrderRet.Total.GetValue();

                                            dt.Rows.Add(dr);
                                            dt.AcceptChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!isVerified) throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool AddSalesOrder(SalesOrder salesOrder)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                ISalesOrderAdd SalesOrderAddRq = requestMsgSet.AppendSalesOrderAddRq();
                if (salesOrder.CustomerRefListID != null)
                    SalesOrderAddRq.CustomerListID.SetValue(salesOrder.CustomerRefListID);
                ISalesOrderItemAdd SalesOrderItemAdd622 = SalesOrderAddRq.SalesOrderItemAddList.Append();
                if (salesOrder.ItemRefListID != null)
                    SalesOrderItemAdd622.ListID.SetValue(salesOrder.ItemRefListID);
                SalesOrderItemAdd622.Qty.SetValue(salesOrder.ItemQuantity);

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
        }

        #endregion

        #region Vendor

        public DataTable ViewVendor()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Vendor Code");
            dt.Columns.Add("Comapny Name");
            dt.Columns.Add("Vendor Name");
            dt.Columns.Add("Vendor ListID");
            bool isVerified = false;
            DataRow dr;
            try
            {

                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorQuery VendorQueryRq = requestMsgSet.AppendVendorQueryRq();


                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($" Error: {responseList.Count}");
                for (int j = 0; j < responseList.Count; j++)
                {
                    IResponse response = responseList.GetAt(j);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtVendorQueryRs)
                            {
                                IVendorRetList VendorRetList = (IVendorRetList)response.Detail;


                                if (VendorRetList != null)
                                {
                                    isVerified = true;
                                    for (int i = 0; i < VendorRetList.Count; i++)
                                    {
                                        var VendorRet = VendorRetList.GetAt(i);
                                        if (VendorRet != null)
                                        {
                                            dr = dt.NewRow();
                                            if (VendorRet.VendorCode != null)
                                                dr["Vendor Code"] = VendorRet.VendorCode.GetValue();
                                            if (VendorRet.CompanyName != null)
                                                dr["Comapny Name"] = VendorRet.CompanyName.GetValue();
                                            if (VendorRet.FirstName != null)
                                                dr["Vendor Name"] = VendorRet.FirstName.GetValue();
                                            if (VendorRet.ListID != null)
                                                dr["Vendor ListID"] = VendorRet.ListID.GetValue();

                                            dt.Rows.Add(dr);
                                            dt.AcceptChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!isVerified) throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddVendor(Vendor vendor)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorAdd VendorAddRq = requestMsgSet.AppendVendorAddRq();

                if (vendor.CompanyName != null)
                    VendorAddRq.CompanyName.SetValue(vendor.CompanyName);
                if (vendor.Name != null)
                    VendorAddRq.FirstName.SetValue(vendor.Name);
                if (vendor.VendorCode != null)
                    VendorAddRq.VendorCode.SetValue(vendor.VendorCode);

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
        }
        public DataTable ViewCustomFieldVendor()
        {
            var dt = new DataTable();
            dt.Columns.Add("CompanyName");
            DataRow dr;
            bool isVerified = false;
            try
            {
                #region RequestForVendor

                sessionManager = new QBPOSSessionManager();

                var requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                var VendorQueryRq = requestMsgSet.AppendVendorQueryRq();

                OpenConnection();
                var responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();
                var response = responseMsgSet.ResponseList.GetAt(0);
                var vendorRetList = (IVendorRetList)response.Detail;

                #endregion

                #region RequestForCustomField

                sessionManager = new QBPOSSessionManager();

                var requestMsgSetCust = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
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

                                if (vendorRet.CompanyName != null)
                                    dr["CompanyName"] = vendorRet.CompanyName.GetValue();

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

                    sessionManager = new QBPOSSessionManager();

                    IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                    requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                    IVendorAdd VendorAddRq = requestMsgSet.AppendVendorAddRq();

                    if (vendor.CompanyName != null)
                        VendorAddRq.CompanyName.SetValue(vendor.CompanyName);
                    if (vendor.VendorCode != null)
                        VendorAddRq.VendorCode.SetValue(vendor.VendorCode);

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

                    sessionManager = new QBPOSSessionManager();

                    IMsgSetRequest requestMsgSetReq = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                    requestMsgSetReq.Attributes.OnError = ENRqOnError.roeContinue;

                    IDataExtAdd DataExtAddRq = requestMsgSetReq.AppendDataExtAddRq();
                    DataExtAddRq.OwnerID.SetValue("0"); //field visable in UI so it is "0"
                    DataExtAddRq.DataExtName.SetValue("CustomField"); //name of field

                    //set for Vendor add
                    DataExtAddRq.ORDataExtOwner.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetVendor);
                    if (vendorListID == null) throw new Exception("Customer ListID is Null");
                    //give list id for cust
                    DataExtAddRq.ORDataExtOwner.ListDataExt.ListObjRef.ListID.SetValue(vendorListID);

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
        public Vendor GetVendor(string listID)
        {
            var vendor = new Vendor();
            var isVerified = false;
            try
            {

                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorQuery VendorQueryRq = requestMsgSet.AppendVendorQueryRq();
                VendorQueryRq.ListID.SetValue(listID);

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($" Error: {responseList.Count}");
                for (int j = 0; j < responseList.Count; j++)
                {
                    IResponse response = responseList.GetAt(j);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtVendorQueryRs)
                            {
                                IVendorRetList VendorRetList = (IVendorRetList)response.Detail;

                                if (VendorRetList != null)
                                {
                                    isVerified = true;
                                    for (int i = 0; i < VendorRetList.Count; i++)
                                    {
                                        var VendorRet = VendorRetList.GetAt(i);
                                        if (VendorRet != null)
                                        {
                                            if (VendorRet.CompanyName == null) throw new Exception("Vendor dont have Companyname");
                                                vendor.CompanyName = VendorRet.CompanyName.GetValue();
                                            if (VendorRet.ListID != null)
                                                vendor.VendorList = VendorRet.ListID.GetValue();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!isVerified) throw new Exception($" Error: {response.StatusMessage}");
                }

                return vendor;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateVendor(Vendor vendor)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IVendorMod VendorModRq = requestMsgSet.AppendVendorModRq();

                if (vendor.CompanyName != null)
                    VendorModRq.CompanyName.SetValue(vendor.CompanyName);
                if (vendor.VendorList != null)
                    VendorModRq.ListID.SetValue(vendor.VendorList);

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
        }

        #endregion

        #region PurchaseOrder

        public DataTable ViewPurchaseOrder()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Vendor Code");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Date");
            dt.Columns.Add("Total");
            bool isVerified = false;
            DataRow dr;
            try
            {

                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(3, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IPurchaseOrderQuery PurchaseOrderQueryRq = requestMsgSet.AppendPurchaseOrderQueryRq();

                OpenConnection();
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                CloseConnection();

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) throw new Exception($" Error: {responseList.Count}");
                for (int j = 0; j < responseList.Count; j++)
                {
                    IResponse response = responseList.GetAt(j);
                    if (response.StatusCode >= 0)
                    {
                        if (response.Detail != null)
                        {
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtPurchaseOrderQueryRs)
                            {
                                IPurchaseOrderRetList PurchaseOrderRetList = (IPurchaseOrderRetList)response.Detail;


                                if (PurchaseOrderRetList != null)
                                {
                                    isVerified = true;
                                    for (int i = 0; i < PurchaseOrderRetList.Count; i++)
                                    {
                                        var VendorRet = PurchaseOrderRetList.GetAt(i);
                                        if (VendorRet != null)
                                        {
                                            dr = dt.NewRow();
                                            if (VendorRet.CompanyName != null)
                                                dr["Vendor Code"] = VendorRet.CompanyName.GetValue();
                                            if (VendorRet.QtyOrdered != null)
                                                dr["Quantity"] = VendorRet.QtyOrdered.GetValue();
                                            if (VendorRet.TxnDate != null)
                                                dr["Date"] = VendorRet.TxnDate.GetValue();
                                            if (VendorRet.Total != null)
                                                dr["Total"] = VendorRet.Total.GetValue();

                                            dt.Rows.Add(dr);
                                            dt.AcceptChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!isVerified) throw new Exception($" Error: {response.StatusMessage}");
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                sessionManager = new QBPOSSessionManager();

                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(majorVersionQB, minorVersionQB);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                IPurchaseOrderAdd PurchaseOrderAddRq = requestMsgSet.AppendPurchaseOrderAddRq();

                if (purchaseOrder.VendorRefListID != null)
                    PurchaseOrderAddRq.VendorListID.SetValue(purchaseOrder.VendorRefListID);
                if (purchaseOrder.PONumber != null)
                    PurchaseOrderAddRq.PurchaseOrderNumber.SetValue(purchaseOrder.PONumber);
                IPurchaseOrderItemAdd PurchaseOrderItemAdd = PurchaseOrderAddRq.PurchaseOrderItemAddList.Append();
                if (purchaseOrder.ItemRefListID != null)
                    PurchaseOrderItemAdd.ListID.SetValue(purchaseOrder.ItemRefListID);
                PurchaseOrderItemAdd.Qty.SetValue(purchaseOrder.ItemQuantity);

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
        }

        #endregion

    }
}
