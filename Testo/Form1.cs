using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace Testo
{
    public partial class Form1 : Form
    {
        //convert string to image
        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        //разберись потом с string to datatime
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


        private void button1_Click(object sender, EventArgs e) //сейчас выводит usernames
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

                textBox1.Text = "";
                foreach (Gizmo_api_users user in temp_users.result)
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
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e) //сейчас выводит время первых 60 хостов
        {
            try
            {
                int[] hosts_time = new int[60];
                WebRequest activesessions_info_request = WebRequest.Create("http://netstorage/api/usersessions/activeinfo");
                activesessions_info_request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
                WebResponse activesessions_info_response = activesessions_info_request.GetResponse();
                Stream activesessions_info_stream = activesessions_info_response.GetResponseStream();
                StreamReader activesessions_info_stream_reader = new StreamReader(activesessions_info_stream);
                string activesessions_info_json_text = activesessions_info_stream_reader.ReadToEnd();

                Gizmo_api_usersessions_activeinfo_full temp_hosts_time = JsonConvert.DeserializeObject<Gizmo_api_usersessions_activeinfo_full>(activesessions_info_json_text);

                foreach (Gizmo_api_usersessions_activeinfo temp_activesession_info in temp_hosts_time.result)
                {
                    textBox1.Text = "";
                    WebRequest userId_balanse_request = WebRequest.Create("http://netstorage/api/users/" + temp_activesession_info.userId + "/balance");
                    userId_balanse_request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
                    WebResponse userId_balanse_response = userId_balanse_request.GetResponse();
                    Stream userId_balanse_stream = userId_balanse_response.GetResponseStream();
                    StreamReader userId_balanse_stream_reader = new StreamReader(userId_balanse_stream);
                    string userId_balanse_json_text = userId_balanse_stream_reader.ReadToEnd();

                    Gizmo_api_user_userId_balanse_full temp_userId_balanse = JsonConvert.DeserializeObject<Gizmo_api_user_userId_balanse_full>(userId_balanse_json_text);
                    if (temp_activesession_info.hostNumber < 61)
                    {
                        if(temp_activesession_info.hostNumber == 0)
                        {
                            hosts_time[temp_activesession_info.hostNumber - 1] = -1;
                        }
                        else
                        {
                            hosts_time[temp_activesession_info.hostNumber - 1] = Convert.ToInt32(temp_userId_balanse.result.availableTime);
                        }                       
                    }
                    userId_balanse_response.Close();
                }
                activesessions_info_response.Close();
                for (int i = 0; i < 60; i++) 
                {
                    if (i < 10)
                    {
                        textBox1.Text += "pc0" + (i + 1) + " : " + (hosts_time[i] / 3600) + ":" + (hosts_time[i] % 3600) / 60 + '\t';
                    }
                    else
                    {
                        textBox1.Text += "pc" + (i + 1) + " : " + (hosts_time[i] / 3600) + ":" + (hosts_time[i] % 3600) / 60 + '\t';
                    }
                    if((i+1)%5 == 0)
                    {
                        textBox1.Text += Environment.NewLine;
                    }
                }
                
            }
            catch(Exception host_time_exc)
            {
                MessageBox.Show(host_time_exc.Message, "nagovnokodil", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }
       
        private void button3_Click(object sender, EventArgs e) //тут можно получать отчеты по отрезку времени
        {
            try
            {
                WebRequest reports_overview_request = WebRequest.Create("http://netstorage/api/reports/overview?DateFrom=2020-07-25T09%3A06&DateTo=2020-07-26T09%3A00");
                reports_overview_request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
                WebResponse reports_overview_response = reports_overview_request.GetResponse();
                Stream reports_overview_stream = reports_overview_response.GetResponseStream();
                StreamReader reports_overview_streamreader = new StreamReader(reports_overview_stream);
                string reports_overview_json_text = reports_overview_streamreader.ReadToEnd();

                Gizmo_api_reports_overview_full temp_reports_overview = JsonConvert.DeserializeObject<Gizmo_api_reports_overview_full>(reports_overview_json_text);
                //пока просто вывод залупы коня
                textBox1.Text = "";
                textBox1.Text += temp_reports_overview.result.operatorsStatistics[0].revenue;
                reports_overview_response.Close();
            }
            catch(Exception reports_overview_exc)
            {
                MessageBox.Show(reports_overview_exc.Message, "nagovnokodil", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            string q = "";
            using (var ms = new MemoryStream())
            {
                using (var bitmap = new System.Drawing.Bitmap("../ico.ico"))
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    q = Convert.ToBase64String(ms.GetBuffer()); //Get Base64
                }
            }
            string wtf = "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";
            pictureBox1.Image = Base64ToImage(wtf);
            
        }

        public string ConvertImage(System.Drawing.Bitmap tempBitmap) 
        {
            MemoryStream objStream = new MemoryStream();
            tempBitmap.Save(objStream,System.Drawing.Imaging.ImageFormat.Jpeg);
            return Convert.ToBase64String(objStream.ToArray());
        }

        private void button4_Click(object sender, EventArgs e) // пока просто получаю все процессы с хостов
        {
            try
            {
                int hostId = 41;

                WebRequest hostID_process_request = WebRequest.Create("http://netstorage/api/hostcomputers/" + hostId + "/process");
                hostID_process_request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
                WebResponse hostID_process_response = hostID_process_request.GetResponse();
                Stream hostID_process_stream = hostID_process_response.GetResponseStream();
                StreamReader hostID_process_streamreader = new StreamReader(hostID_process_stream);
                var hostID_process_full_json_text = hostID_process_streamreader.ReadToEnd();

                Gizmo_api_hostcomputers_hostID_process_full hostID_process_temp = JsonConvert.DeserializeObject<Gizmo_api_hostcomputers_hostID_process_full>(hostID_process_full_json_text);
                textBox1.Text = "";

                //получение системных процессов для сравнения
                List<string> sysProcs = new List<string> { };
                StreamReader sw = new StreamReader("../procs.txt");
                while(sw.EndOfStream == false)
                {
                    sysProcs.Add(sw.ReadLine());
                }
                sw.Close();
                foreach (Gizmo_api_hostcomputers_hostID_process process_temp in hostID_process_temp.result)
                {
                    bool isUserProcess = true;
                    foreach(string sysProc in sysProcs)
                    {
                        if (sysProc == process_temp.processExeName)
                            isUserProcess = false;
                    }
                    if (isUserProcess == true)
                        textBox1.Text += process_temp.processExeName + "  ";
                }
                hostID_process_response.Close();
            }
            
            catch(Exception hostId_process_exc)
            {
                MessageBox.Show(hostId_process_exc.Message, "nagovnokodil", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }
    }
}
