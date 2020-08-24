using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Testo
{
    public static class Gizmo_api
    {
        //string to image convert
        public static System.Drawing.Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                return image;
            }
        }
        //img to string convert
        public static string ConvertImage(System.Drawing.Bitmap tempBitmap)

        {
            MemoryStream objStream = new MemoryStream();
            tempBitmap.Save(objStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Convert.ToBase64String(objStream.ToArray());
        }      
        public static System.Threading.TimerCallback tm = new System.Threading.TimerCallback(Gizmo_api.UserSessions_Update);
        public static void UserSessions_Update(object obj) 
        {
            WebRequest activesessions_info_request = WebRequest.Create("http://netstorage/api/usersessions/activeinfo");
            activesessions_info_request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
            WebResponse activesessions_info_response = activesessions_info_request.GetResponse();
            Stream activesessions_info_stream = activesessions_info_response.GetResponseStream();
            StreamReader activesessions_info_stream_reader = new StreamReader(activesessions_info_stream);
            string activesessions_info_json_text = activesessions_info_stream_reader.ReadToEnd();
            Gizmo_api_usersessions_activeinfo_full active_sessions = (Gizmo_api_usersessions_activeinfo_full)obj;
            active_sessions = JsonConvert.DeserializeObject<Gizmo_api_usersessions_activeinfo_full>(activesessions_info_json_text);
        }
    }

    public class Gizmo_api_users_full
    {
        public List<Gizmo_api_users> result { get; set; }
        public int httpStatusCode { get; set; }
    }
    public class Gizmo_api_host_full
    {
        public List<Gizmo_api_hosts> result { get; set; }
        public int httpStatusCode { get; set; }
    }
    public class Gizmo_api_products_full
    {
        public List<Gizmo_api_products> result { get; set; }
        public int httpStatusCode { get; set; }
    }
    public class Gizmo_api_usersessions_activeinfo_full
    {
        public List<Gizmo_api_usersessions_activeinfo> result { get; set; }
        public int httpStatusCode { get; set; }
    }
    public class Gizmo_api_user_userId_balanse_full
    {
        public Gizmo_api_user_userId_balanse result { get; set; }
        public int httpStatusCode { get; set; }
    }
    public class Gizmo_api_reports_overview_full
    {
        public Gizmo_api_reports_overview result { get; set; }
        public int httpStatusCode { get; set; }
    }
    public class Gizmo_api_hostcomputers_hostID_process_full
    {
        public List<Gizmo_api_hostcomputers_hostID_process> result { get; set; }
        public int httpStatusCode { get; set; }
    }
    public class Gizmo_api_hostcomputers_full
    {
        public List<Gizmo_api_hostcomputers> result { get; set; }
        public int httpStatusCode { get; set; }
    }

    public class Gizmo_api_products
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public int OrderOptions { get; set; }
        public int PurchaseOptions { get; set; }
        public int Points { get; set; }
        public int PointsPrice { get; set; }
        public string Barcode { get; set; }
        public int StockOptions { get; set; }
        public double StockAlert { get; set; }
        public int StockProductId { get; set; }
        public double StockProductAmount { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductGroupId { get; set; }
        public int DisplayOrder { get; set; }
        public string Guid { get; set; }
        public int ModifiedById { get; set; }
        public string ModifiedTime { get; set; }
        public int CreatedById { get; set; }
        public string CreatedTime { get; set; }
        public int Id { get; set; }
    }
    public class Gizmo_api_hosts
    {
        public int maximumUsers { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public int hostGroupId { get; set; }
        public int state { get; set; }
        public int[] iconId { get; set; }
        public bool isDeleted { get; set; }
        public int modifiedById { get; set; }
        public string modifiedTime { get; set; }
        public object createdById { get; set; }
        public string createdTime { get; set; }
        public int id { get; set; }
    }
    public class Gizmo_api_users
    {
        public string username { get; set; }
        public string email { get; set; }
        public int userGroupId { get; set; }
        public object isNegativeBalanceAllowed { get; set; }
        public object isPersonalInfoRequested { get; set; }
        public object billingOptions { get; set; }
        public string enableDate { get; set; }
        public string fisabledDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthDate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postCode { get; set; }
        public string phone { get; set; }
        public string mobilePhone { get; set; }
        public object sex { get; set; }
        public object isDeleted { get; set; }
        public object isDisabled { get; set; }
        public string guid { get; set; }
        public string smartCardUID { get; set; }
        public string identification { get; set; }
        public object modifiedById { get; set; }
        public string modifiedTime { get; set; }
        public object createdById { get; set; }
        public string createdTime { get; set; }
        public object id { get; set; }
    }
    public class Gizmo_api_usersessions_activeinfo
    {
        public string username { get; set; }
        public int userId { get; set; }
        public double span { get; set; }
        public string lastLogin { get; set; }
        public string lastLogout { get; set; }
        public int hostId { get; set; }
        public string hostName { get; set; }
        public int hostNumber { get; set; }
        public string userGroupName { get; set; }
        public int userGroupId { get; set; }
        public string hostGroupName { get; set; }
        public int hostGroupId { get; set; }
        public int sessionState { get; set; }
        public int slot { get; set; }
    }
    public class Gizmo_api_user_userId_balanse
    {
        public int userId { get; set; }
        public double deposits { get; set; }
        public double points { get; set; }
        public double onInvoices { get; set; }
        public double onInvoicedUsage { get; set; }
        public double onUninvoicedUsage { get; set; }
        public double timeProduct { get; set; }
        public double timeFixed { get; set; }
        public object availableTime { get; set; }
        public object availableCreditedTime { get; set; }
        public double balance { get; set; }
        public double timeProductBalance { get; set; }
        public double usageBalance { get; set; }
        public double totalOutstanding { get; set; }
    }
    public class Gizmo_api_reports_overview
    {
        public List<Gizmo_api_operatorsStatistics> operatorsStatistics { get; set; }
        public string averageMemberUsagePeriodMinutes { get; set; }
        public string averageGuestUsagePeriodMinutes { get; set; }
        public double averageUtilizationPercentage { get; set; }
        public int uniqueMembersLogins { get; set; }
        public int uniqueGuestsLogins { get; set; }
        public Gizmo_api_memberCounters memberCounters { get; set; }
        public double totalRevenue { get; set; }
        public double averageRevenuePerMember { get; set; }
        public double averageRevenuePerGuest { get; set; }
        public List<Gizmo_api_revenuePerGroup> revenuePerGroup { get; set; }
        public string name { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public string companyName { get; set; }
        public string reportType { get; set; }
    }
    public class Gizmo_api_hostcomputers_hostID_process
    {
        public Gizmo_api_mainModule mainModule { get; set; }
        public int id { get; set; }
        public int parentID { get; set; }
        public int sessionID { get; set; }
        public string processName { get; set; }
        public string processExeName { get; set; }
        public string commandLine { get; set; }
        public int basePriority { get; set; }
        public string startTime { get; set; }
        public string totalProcessorTime { get; set; }
        public string userProcessorTime { get; set; }
        public int processorCount { get; set; }
        public long privateMemorySize { get; set; }
        public string currentDirectorv { get; set; }
    }
    public class Gizmo_api_hostcomputers
    {
        public string hostname { get; set; }
        public string macAddress { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public int hostGroupId { get; set; }
        public int state { get; set; }
        public object iconId { get; set; }
        public bool isDeleted { get; set; }
        public int modifiedById { get; set; }
        public string modifiedTime { get; set; }
        public object createdById { get; set; }
        public string createdTime { get; set; }
        public int id { get; set; }
    }


    public class Gizmo_api_operatorsStatistics //for Gizmo_api_reports_overview
    {
        public int operatorId { get; set; }
        public string operatorName { get; set; }
        public int minutesWorked { get; set; }
        public string hoursWorked { get; set; }
        public double minutesSold { get; set; }
        public string hoursSold { get; set; }
        public double productsSold { get; set; }
        public double timeOffersSold { get; set; }
        public double bundlesSold { get; set; }
        public int voids { get; set; }
        public double revenue { get; set; }
    }
    public class Gizmo_api_memberCounters //for Gizmo_api_reports_overview
    {
        public int newMembers { get; set; }
        public int totalMembers { get; set; }
        public int bannedMembers { get; set; }
    }
    public class Gizmo_api_revenuePerGroup //for Gizmo_api_reports_overview
    {
        public string name { get; set; }
        public double value { get; set; }
    }
    public class Gizmo_api_mainModule // for Gizmo_api_hostcomputers_hostID_process
    {
        public string fileName { get; set; }
        public string moduleName { get; set; }
        public string companyName { get; set; }
        public string deskription { get; set; }
        public string fileVersion { get; set; }
        public long entryPointAddress { get; set; }
        public long moduleMemorySize { get; set; }
        public long baseAddress { get; set; }
        public string iconData { get; set; }
    }
}
