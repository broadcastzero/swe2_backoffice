﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPU_Backoffice_Panels
{
    public partial class kundenKontakteTab : UserControl
    {
        public kundenKontakteTab()
        {
            InitializeComponent();
        }

        public void HideMsgLabels()
        {
            this.kundeNeuMsgLabel.Hide();
            this.searchKundeMsgLabel.Hide();
        }
    }
}
