﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadetSystem
{
    public partial class FrmCadetOccurrence : Form
    {
        Ocadet cadet;
        public FrmCadetOccurrence(Ocadet ocadet)
        {
            cadet = ocadet;
            InitializeComponent();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblprofile_Click(object sender, EventArgs e)
        {
            FrmCadetProfile cdtpro = new FrmCadetProfile(cadet);
            cdtpro.Show();
            this.Close();
        }

        private void pbprofile_Click(object sender, EventArgs e)
        {
            FrmCadetProfile cdtpro = new FrmCadetProfile(cadet);
            cdtpro.Show();
            this.Close();
        }

        private void lblparade_Click(object sender, EventArgs e)
        {
            FrmCadetParadestate cdtprd = new FrmCadetParadestate(cadet);
            cdtprd.Show();
            this.Close();
        }

        private void pbparade_Click(object sender, EventArgs e)
        {
            FrmCadetParadestate cdtprd = new FrmCadetParadestate(cadet);
            cdtprd.Show();
            this.Close();
        }

        private void lblattendance_Click(object sender, EventArgs e)
        {
            FrmCadetAttendance cdtatt = new FrmCadetAttendance(cadet);
            cdtatt.Show();
            this.Close();
        }

        private void pbattendance_Click(object sender, EventArgs e)
        {
            FrmCadetAttendance cdtatt = new FrmCadetAttendance(cadet);
            cdtatt.Show();
            this.Close();
        }

        private void lblrollcall_Click(object sender, EventArgs e)
        {
            FrmCadetRollcall cdtrol = new FrmCadetRollcall(cadet);
            cdtrol.Show();
            this.Close();
        }

        private void pbrollcall_Click(object sender, EventArgs e)
        {
            FrmCadetRollcall cdtrol = new FrmCadetRollcall(cadet);
            cdtrol.Show();
            this.Close();
        }

        private void lblmeals_Click(object sender, EventArgs e)
        {
            FrmCadetMeals cdtmeal = new FrmCadetMeals(cadet);
            cdtmeal.Show();
            this.Close();
        }

        private void pbmeals_Click(object sender, EventArgs e)
        {
            FrmCadetMeals cdtmeal = new FrmCadetMeals(cadet);
            cdtmeal.Show();
            this.Close();
        }

        private void lbllogout_Click(object sender, EventArgs e)
        {
            FrmLogin log = new FrmLogin();
            log.Show();
            this.Close();
        }

        private void pblogout_Click(object sender, EventArgs e)
        {
            FrmLogin log = new FrmLogin();
            log.Show();
            this.Close();
        }

        private void lblreports_Click(object sender, EventArgs e)
        {
            FrmCadetReports cdtrpt = new FrmCadetReports(cadet);
            cdtrpt.Show();
            this.Close();
        }

        private void pbreports_Click(object sender, EventArgs e)
        {
            FrmCadetReports cdtrpt = new FrmCadetReports(cadet);
            cdtrpt.Show();
            this.Close();
        }

        private void lblhome_Click(object sender, EventArgs e)
        {
            FrmCadetHome cdthme = new FrmCadetHome(cadet);
            cdthme.Show();
            this.Close();
        }

        private void pbhome_Click(object sender, EventArgs e)
        {
            FrmCadetHome cdthme = new FrmCadetHome(cadet);
            cdthme.Show();
            this.Close();
        }

        private void FrmCadetOccurrence_Load(object sender, EventArgs e)
        {
            lbllogger.Text = cadet.Name;
            lbldate.Text = cadet.TodayDate;
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txttask.Text == "")
            {
                MessageBox.Show("Fill the required field");
            }
            else
            {
                SqlCommand sqlcmd = new SqlCommand();
                string query = "INSERT into KDUoccurrences(Time,Task,Occurrencedate,Intake,SubmittedBy,SubmittedOn)values(@Time,@Task,@Occurrencedate,@Intake,@SubmittedBy,GETDATE())";

                
                DataAccessLayer.AddParameters(sqlcmd, "@Time", SqlDbType.Time, dtptime.Value.ToString("HH:mm"));
                DataAccessLayer.AddParameters(sqlcmd, "@Task", SqlDbType.NVarChar,txttask.Text);
                DataAccessLayer.AddParameters(sqlcmd, "@Occurrencedate", SqlDbType.DateTime, cadet.TodayDate);
                DataAccessLayer.AddParameters(sqlcmd, "@Intake", SqlDbType.Int, cadet.Intake);
                DataAccessLayer.AddParameters(sqlcmd, "@SubmittedBy", SqlDbType.NVarChar, cadet.Name);

                DataAccessLayer.ExecuteNonQuery(query, sqlcmd);
                {
                    MessageBox.Show("Saved Successfully");
                }
                
                txttask.Clear();
               
            }
        }

        private void gboccurrence_Enter(object sender, EventArgs e)
        {
            lbldate.Text = cadet.TodayDate;
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            FrmCadetOccurrenceView view = new FrmCadetOccurrenceView(cadet);
            view.Show();
            this.Close();
        }
    }
    }
