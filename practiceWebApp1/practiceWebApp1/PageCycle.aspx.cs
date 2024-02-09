using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practiceWebApp1
{
    public partial class PageCycle : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //This will fire before page initialised and set value to lable. 
            lblDisplayPageEventsSteps.Text = "This is PreInit Event";
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            //This will fire when the page is initialised and set value to lable. 
            lblDisplayPageEventsSteps.Text += lblDisplayPageEventsSteps.Text = "<br/>This is Init Event";
        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            //This will fire when page initialization completed and set value to lable. 
            lblDisplayPageEventsSteps.Text += lblDisplayPageEventsSteps.Text = "<br/>This is InitComplete Event";
        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            //This will fire before page load and set value to lable. 
            lblDisplayPageEventsSteps.Text += lblDisplayPageEventsSteps.Text = "<br/>This is PreLoad Event";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //This will fire when page is loaded and set value to lable. 
            lblDisplayPageEventsSteps.Text += lblDisplayPageEventsSteps.Text = "<br/>This is Load Event";
        }
    }
}