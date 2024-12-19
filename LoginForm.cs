using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolCloneDataFromGSHT
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Gọi phương thức bất đồng bộ bên trong sự kiện Click
            await HandleLoginAsync();
            this.Hide();

        }

        private async Task HandleLoginAsync()
        {
            string cookieID = Guid.NewGuid().ToString();
            using (var handler = new HttpClientHandler())
            {
                // Tạo CookieContainer để lưu trữ cookie
                handler.CookieContainer = new CookieContainer();

                // Thêm cookie vào CookieContainer
                Uri uri = new Uri("https://gsht.drvn.gov.vn");
                handler.CookieContainer.Add(uri, new Cookie("JSESSIONID", cookieID));

                using (HttpClient client = new HttpClient(handler))
                {
                    // Thêm các headers khác cho request
                    client.DefaultRequestHeaders.Add("Accept", "*/*");
                    client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9,vi;q=0.8");
                    client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    client.DefaultRequestHeaders.Add("Pragma", "no-cache");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                    client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Google Chrome\";v=\"123\", \"Not:A-Brand\";v=\"8\", \"Chromium\";v=\"123\"");
                    client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                    client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "\"Windows\"");

                    // URL và body cho request
                    string url = "https://gsht.drvn.gov.vn/loginagl?action=login&h=7788";
                    string jsonBody = "{\"mapParam\":{\"ma_nsd\":\"" + txtUsername.Text + "\",\"mat_khau\":\"" + txtPassword.Text + "\"}}";

                    // Tạo content với JSON body
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    try
                    {
                        // Gửi POST request
                        var rs = await client.PostAsync(url, content);

                        // Kiểm tra nếu response thành công
                        if (rs.IsSuccessStatusCode)
                        {
                            string responseContent = await rs.Content.ReadAsStringAsync();
                            var parsedJson = JObject.Parse(responseContent);
                            var msg = parsedJson["msg"];
                            if (msg["errCode"].ToString() == "0")
                            {
                                var model = JObject.Parse(msg["object"].ToString());
                                if (model["authorization"] != null && model["authorization"].ToString().Length > 0)
                                {
                                    Properties.Settings.Default.cookieID = cookieID;
                                    Properties.Settings.Default.Save();
                                    Actions ac = new Actions();
                                    ac.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ
                        Console.WriteLine("Error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string cookieID = Properties.Settings.Default.cookieID;
            if (cookieID != null && cookieID.Length > 0)
            {
                MessageBox.Show("Chưa đăng nhập");
                Actions lg = new Actions();
                lg.ShowDialog();
                this.Close();
            }
        }
    }
}
