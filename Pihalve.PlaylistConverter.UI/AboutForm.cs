using System;
using System.Windows.Forms;

namespace Pihalve.PlaylistConverter.UI
{
    internal partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            Text = String.Format("About {0}", AssemblyInformation.Title);
            labelProductName.Text = AssemblyInformation.Product;
            labelVersion.Text = String.Format("Version {0}", AssemblyInformation.Version);
            labelCopyright.Text = AssemblyInformation.Copyright;
            labelCompanyName.Text = AssemblyInformation.Company;
            textBoxDescription.Text = AssemblyInformation.Description;
        }
    }
}
