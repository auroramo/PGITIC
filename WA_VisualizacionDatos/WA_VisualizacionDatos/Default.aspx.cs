using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WA_VisualizacionDatos
{
    public partial class _Default : Page
    {
        ServiceReferenceDB.ServicioBDClient sr = new ServiceReferenceDB.ServicioBDClient();
        private DataSet ds = new DataSet();

        protected void Timer1_Tick(object sender, EventArgs e)

        {
            CargarValores();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarValores();
        }

        private void CargarValores()
        {
            ds = sr.RecuperarLecturas();
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if ((int)(drv[4]) <=4)
                {
                    e.Row.BackColor = System.Drawing.Color.Purple;

                }
                else if ((int)(drv[4]) > 4 && (int)(drv[4]) <= 14)
                {
                    e.Row.BackColor = System.Drawing.Color.CornflowerBlue;

                }
                else if ((int)(drv[4]) > 14 && (int)(drv[4]) <= 28)
                {
                    e.Row.BackColor = System.Drawing.Color.LemonChiffon;

                }
                else if ((int)(drv[4]) > 28)
                {
                    e.Row.BackColor = System.Drawing.Color.Salmon;

                }

            }
        }


    }
}