using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class OverviewInProcessView : OverviewExpiredView
    {
        string issueNo;
        string issueDate;
        public string IssueNo { get { return issueNo; } }
        public string IssueDate { get { return issueDate; } }

        string priorExpriedNo;
        string priorExpriedIssueDate;
        string iRSNo;
        string iRSIssueDate;

        public OverviewInProcessView(string itemNo, string partNo, int quantity, DateTime expiredDate, int timeExtend, 
            string priorExpriedNo, string priorExpriedIssueDate, string iRSNo, string iRSIssueDate) 
            : base(itemNo, partNo, quantity, expiredDate, timeExtend)
        {
            this.priorExpriedNo = priorExpriedNo;
            this.priorExpriedIssueDate = priorExpriedIssueDate;
            this.iRSNo = iRSNo;
            this.iRSIssueDate = iRSIssueDate;
            Display();
        }

        private void Display()
        {
            if (iRSNo != null)
            {
                issueNo = iRSNo;
                issueDate = iRSIssueDate;
            }
            else
            {
                issueNo = priorExpriedNo;
                issueDate = priorExpriedIssueDate;
            }
        }
    }
}
