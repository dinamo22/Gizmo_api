using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace Testo
{
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(string text);
        private Thread thread2 = null;

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
        }
        //разберись потом с string to datatime
        
        private void button1_Click(object sender, EventArgs e) //сейчас выводит usernames
        {
            try
            {   
                //WebRequest request = WebRequest.Create("http://netstorage/api/hosts");
                //WebRequest request = WebRequest.Create("http://netstorage/api/users");
                WebRequest request = WebRequest.Create("http://netstorage/api/usersessions/activeinfo");
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
            //Form2 newForm = new Form2();
            //newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e) //сейчас выводит время первых 60 хостов
        {
            int[] hosts_time = new int[60];
            TextBox textBoxTemp = new TextBox();
            try
                {
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
                            if (temp_activesession_info.hostNumber == 0)
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
                        if ((i + 1) % 5 == 0)
                        {
                            textBox1.Text += Environment.NewLine;
                        }
                    }
                }
                catch (Exception host_time_exc)
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
            pictureBox1.Image = Gizmo_api.Base64ToImage(wtf);
            
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

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            thread2 = new Thread(new ThreadStart(SetText_try));
            thread2.Start();
            //Thread.Sleep(1000);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
        }

        private void WriteTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                textBox1.Invoke(d, new object[] { text });
            }
            else
            {
                textBox1.Text = text;
            }
        }
        private void SetText_try()
        {
            int[] hosts_time = new int[60];
            TextBox textBoxTemp = new TextBox();
            try
            {
                WebRequest activesessions_info_request = WebRequest.Create("http://netstorage/api/usersessions/activeinfo");
                activesessions_info_request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
                WebResponse activesessions_info_response = activesessions_info_request.GetResponse();
                Stream activesessions_info_stream = activesessions_info_response.GetResponseStream();
                StreamReader activesessions_info_stream_reader = new StreamReader(activesessions_info_stream);
                string activesessions_info_json_text = activesessions_info_stream_reader.ReadToEnd();

                Gizmo_api_usersessions_activeinfo_full temp_hosts_time = JsonConvert.DeserializeObject<Gizmo_api_usersessions_activeinfo_full>(activesessions_info_json_text);

                foreach (Gizmo_api_usersessions_activeinfo temp_activesession_info in temp_hosts_time.result)
                {                   
                    WebRequest userId_balanse_request = WebRequest.Create("http://netstorage/api/users/" + temp_activesession_info.userId + "/balance");
                    userId_balanse_request.Credentials = new NetworkCredential("Earlies", "Vjzctcnhf1");
                    WebResponse userId_balanse_response = userId_balanse_request.GetResponse();
                    Stream userId_balanse_stream = userId_balanse_response.GetResponseStream();
                    StreamReader userId_balanse_stream_reader = new StreamReader(userId_balanse_stream);
                    string userId_balanse_json_text = userId_balanse_stream_reader.ReadToEnd();

                    Gizmo_api_user_userId_balanse_full temp_userId_balanse = JsonConvert.DeserializeObject<Gizmo_api_user_userId_balanse_full>(userId_balanse_json_text);
                    if (temp_activesession_info.hostNumber < 61)
                    {
                        if (temp_activesession_info.hostNumber == 0)
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
                        textBoxTemp.Text += "pc0" + (i + 1) + " : " + (hosts_time[i] / 3600) + ":" + (hosts_time[i] % 3600) / 60 + '\t';
                    }
                    else
                    {
                        textBoxTemp.Text += "pc" + (i + 1) + " : " + (hosts_time[i] / 3600) + ":" + (hosts_time[i] % 3600) / 60 + '\t';
                    }
                    if ((i + 1) % 5 == 0)
                    {
                        textBoxTemp.Text += Environment.NewLine;
                    }
                }
            }
            catch (Exception host_time_exc)
            {
                MessageBox.Show(host_time_exc.Message, "nagovnokodil", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            WriteTextSafe(textBoxTemp.Text);
        }

        private void SetText()
        {
            WriteTextSafe("This text was set safely.");
        }
    }
}
