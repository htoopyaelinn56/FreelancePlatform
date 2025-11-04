using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelancePlatform.src
{
    public partial class ClientProfileForm : BaseForm
    {
        private int userId;
        public ClientProfileForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ClientProfileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
