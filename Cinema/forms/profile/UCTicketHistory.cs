using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.forms.profile
{
    public partial class UCTicketHistory: UserControl
    {
        private ProfileForm ProfileForm;
        public UCTicketHistory(ProfileForm ProfileForm)
        {
            InitializeComponent();
            this.ProfileForm = ProfileForm;
        }
    }
}
