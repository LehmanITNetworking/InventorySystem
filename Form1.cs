using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem {
    public partial class InventorySystem : Form {

        DataTable inventory = new DataTable();
        public InventorySystem() {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e) {
            macTextBox.Text             = "";
            nameTextBox.Text            = "";
            serialTextBox.Text          = "";
            descriptionTextBox.Text     = "";
            locationTextBox.Text        = "";
        }

        private void saveButton_Click(object sender, EventArgs e) {
            String mac           = macTextBox.Text;
            String name          = nameTextBox.Text;
            String serial        = serialTextBox.Text;
            String description   = descriptionTextBox.Text;
            String location      = locationTextBox.Text;

            if (mac != "") {
                inventory.Rows.Add(mac, name, serial, description, location);

                newButton_Click(sender, e);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            try {
                inventory.Rows.RemoveAt(InventoryGridView1.CurrentCell.RowIndex);
            }catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void InventoryGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {

                macTextBox.Text = inventory.Rows[InventoryGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = inventory.Rows[InventoryGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
                serialTextBox.Text = inventory.Rows[InventoryGridView1.CurrentCell.RowIndex].ItemArray[2].ToString();
                descriptionTextBox.Text = inventory.Rows[InventoryGridView1.CurrentCell.RowIndex].ItemArray[3].ToString();
                locationTextBox.Text = inventory.Rows[InventoryGridView1.CurrentCell.RowIndex].ItemArray[4].ToString();



            } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void InventorySystem_Load(object sender, EventArgs e) {
            inventory.Columns.Add("MAC ADDRESS");
            inventory.Columns.Add("NAME");
            inventory.Columns.Add("SERIAL NO");
            inventory.Columns.Add("DESCRIPTION");
            inventory.Columns.Add("LOCATION");

            InventoryGridView1.DataSource = inventory;

        }
    }
}
