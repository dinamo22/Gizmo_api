using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace Testo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            public List<Gizmo_api_user_userId_balanse> result { get; set; }
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
            public int deposits { get; set; }
            public int points { get; set; }
            public int onInvoices { get; set; }
            public int onInvoicedUsage { get; set; }
            public int onUninvoicedUsage { get; set; }
            public int timeProduct { get; set; }
            public int timeFixed { get; set; }
            public int availableTime { get; set; }
            public int availableCreditedTime { get; set; }
            public int balance { get; set; }
            public int timeProductBalance { get; set; }
            public int usageBalance { get; set; }
            public int totalOutstanding { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //WebRequest request = WebRequest.Create("http://netstorage/api/hosts");
                //WebRequest request = WebRequest.Create("http://netstorage/api/users");
                WebRequest request = WebRequest.Create("http://netstorage/api/usersessions/activeinfo");
                WebRequest request1 = WebRequest.Create("http://netstorage/api/users/balance");
                request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader stream_reader = new StreamReader(stream);
                string all_json_text = stream_reader.ReadToEnd();
                
                //Gizmo_api_host_full temp_api = JsonConvert.DeserializeObject<Gizmo_api_host_full>(all_json_text);
                Gizmo_api_users_full temp_users = JsonConvert.DeserializeObject<Gizmo_api_users_full>(all_json_text);
                //foreach (Gizmo_api_hosts host in temp_api.result)
                foreach(Gizmo_api_users user in temp_users.result)
                {
                    if(user.userGroupId == 1 )
                    textBox1.Text += user.username + "  ";
                }
                response.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "nagovnokodil", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }
    }
}
