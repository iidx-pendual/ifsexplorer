using System.Diagnostics;
using System.Windows.Forms;

namespace IFSExplorer
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void linklabelYuki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://kivikakk.ee");
        }

        private void linklabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/kivikakk/IFSExplorer");
        }

        private void linklabelPublicDomain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://unlicense.org/");
        }
    }
}
