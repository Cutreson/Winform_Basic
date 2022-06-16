using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_SaveLink;
using BUS_SaveLink;

namespace GUI_SaveLink
{
    public partial class GUI_Link : Form
    {
        BUS_Link bus_Link = new BUS_Link();
        public GUI_Link()
        {
            InitializeComponent();
        }

        private void GUI_Link_Load(object sender, EventArgs e)
        {
            table_Link.DataSource = bus_Link.getLink();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(txt_Title.Text != "" && txt_Url.Text != "")
            {
                DTO_Link link = new DTO_Link(0, txt_Title.Text, txt_Url.Text);
                if(bus_Link.addLink(link))
                {
                    MessageBox.Show("Thêm thành công");
                    table_Link.DataSource = bus_Link.getLink();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(table_Link.SelectedRows.Count > 0)
            {
                if(txt_Title.Text != "" && txt_Url.Text != "")
                { 
                    DataGridViewRow row = table_Link.SelectedRows[0];
                    int id = Convert.ToInt16(row.Cells[0].Value.ToString());
                    DTO_Link link = new DTO_Link(id, txt_Title.Text, txt_Url.Text);
                    if(bus_Link.editLink(link))
                    {
                        MessageBox.Show("Sửa thành công");
                        table_Link.DataSource = bus_Link.getLink();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }    
                }
                else
                {
                    MessageBox.Show("Nhập đầy đủ thông tin");
                }
            }
            else
            {
                MessageBox.Show("Chọn link cần sửa");
            }
        }

        private void table_Link_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = table_Link.SelectedRows[0];
            txt_Title.Text = row.Cells[1].Value.ToString();
            txt_Url.Text = row.Cells[2].Value.ToString();
        }
    }
}
