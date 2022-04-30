using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using RestSharp;
using MySql.Data.MySqlClient.Memcached;
using System.Net.Http;

namespace API_Dashboard
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            PanelDashboardShow();
        }
        public class Base
        {
            internal int someMember;
        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                RoundCorner.Radius = 6;
                ButtonBigSmall.Image = Properties.Resources.BtnMaximize;
                ButtonBigSmall.HoverState.Image = Properties.Resources.BtnMaximizeHover;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                RoundCorner.Radius = 0;
                ButtonBigSmall.Image = Properties.Resources.BtnRestoreDown;
                ButtonBigSmall.HoverState.Image = Properties.Resources.BtnRestoreDownHover;
            }
            else
            {

            }
        }

        void PanelDashboardShow()
        {
            ButtonDashboard.Image = Properties.Resources.HomeFill;
            LabelAppName.Text = "" + "Dashboard";
            PanelDashboard.Dock = DockStyle.Fill;
            PanelDashboard.Visible = true;
            PanelStats.Visible = false;
            PanelSettings.Visible = false;
            PanelInfo.Visible = false;
        }

        void PanelStatsShow()
        {
            ButtonStats.Image = Properties.Resources.StatsFill;
            LabelAppName.Text = "" + "Stats";
            PanelStats.Dock = DockStyle.Fill;
            PanelDashboard.Visible = false;
            PanelStats.Visible = true;
            PanelSettings.Visible = false;
            PanelInfo.Visible = false;
        }

        void PanelSettingsShow()
        {
            ButtonSettings.Image = Properties.Resources.SettingsFill;
            LabelAppName.Text = "" + "Settings";
            PanelSettings.Dock = DockStyle.Fill;
            PanelDashboard.Visible = false;
            PanelStats.Visible = false;
            PanelSettings.Visible = true;
            PanelInfo.Visible = false;
        }

        void PanelInfoShow()
        {
            ButtonInfo.Image = Properties.Resources.InfoFill;
            LabelAppName.Text = "" + "Info";
            PanelInfo.Dock = DockStyle.Fill;
            PanelDashboard.Visible = false;
            PanelStats.Visible = false;
            PanelSettings.Visible = false;
            PanelInfo.Visible = true;
        }

        void PanelDashboardHide()
        {
            ButtonDashboard.Image = Properties.Resources.Home;
            PanelDashboard.Visible = false;
        }

        void PanelStatsHide()
        {
            ButtonStats.Image = Properties.Resources.Stats;
            PanelStats.Visible = false;
        }

        void PanelSettingsHide()
        {
            ButtonSettings.Image = Properties.Resources.Settings;
            PanelSettings.Visible = false;
        }

        void PanelInfoHide()
        {
            ButtonInfo.Image = Properties.Resources.Info;
            PanelInfo.Visible = false;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonBigSmall_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                RoundCorner.Radius = 0;
                this.WindowState = FormWindowState.Maximized;
                ButtonBigSmall.Image = Properties.Resources.BtnRestoreDown;
                ButtonBigSmall.HoverState.Image = Properties.Resources.BtnRestoreDownHover;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                RoundCorner.Radius = 6;
                this.WindowState = FormWindowState.Normal;
                ButtonBigSmall.Image = Properties.Resources.BtnMaximize;
                ButtonBigSmall.HoverState.Image = Properties.Resources.BtnMaximizeHover;
            }
            else
            {

            }
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            if (PanelDashboard.Visible == false)
            {
                PanelDashboardShow();
                PanelStatsHide();
                PanelSettingsHide();
                PanelInfoHide();
            }
        }

        private void ButtonStats_Click(object sender, EventArgs e)
        {
            if (PanelStats.Visible == false)
            {
                PanelDashboardHide();
                PanelStatsShow();
                PanelSettingsHide();
                PanelInfoHide();
            }
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            if (PanelSettings.Visible == false)
            {
                PanelDashboardHide();
                PanelStatsHide();
                PanelSettingsShow();
                PanelInfoHide();
            }
        }

        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            if (PanelInfo.Visible == false)
            {
                PanelDashboardHide();
                PanelStatsHide();
                PanelSettingsHide();
                PanelInfoShow();
            }
        }

        private void ApiFatch()
        {
            CircleProgressBar1.Value = 18;
        }

        private async Task ApiAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://stock-and-options-trading-data-provider.p.rapidapi.com/options/aapl"),
                Headers =
    {
        { "X-RapidAPI-Proxy-Secret", "a755b180-f5a9-11e9-9f69-7bf51e845926" },
        { "X-RapidAPI-Host", "stock-and-options-trading-data-provider.p.rapidapi.com" },
        { "X-RapidAPI-Key", "ad111c69cemshd5db730978c17d8p1e00cejsn6e80d0351b8c" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(body);
                //CircleProgressBar1.Value = ;
                ApiFatch();
            }
        }
    }
}