﻿using System;
using DevExpress.XtraEditors;

namespace WitsWay.TempTests.GeneralQuery.QueryForms
{
    public partial class SearchControlUc : XtraUserControl, ISearchFilterUc<EmployeeSearchFilter>
    {
        public SearchControlUc()
        {
            InitializeComponent();
        }

        private void SearchControlUC_Load(object sender, EventArgs e)
        {

        }

        public EmployeeSearchFilter GetFilter()
        {
            return null;
        }

        public void BindFilter(EmployeeSearchFilter data)
        {

        }


        public string ConfigKey => throw new NotImplementedException();
    }
}