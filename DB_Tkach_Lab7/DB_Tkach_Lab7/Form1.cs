using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.SqlClient;

namespace DB_Tkach_Lab7
{
    public partial class Form1 : Form
    {
        public OleDbConnection cn = new OleDbConnection(
            "Provider = sqloledb; " +
            "Data Source = DESKTOP-74QMQEE; " +
            "Initial Catalog = study; " +
            "Integrated Security=SSPI;"
        );

        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab7";
        }

        private List<String> Get_factories()
        {
            List<String> res = new List<String>();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT number, name, address, boss FROM factory";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(
                              rd.GetValue(rd.GetOrdinal("number")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("name")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("address")).ToString() + " " 
                            + rd.GetValue(rd.GetOrdinal("boss")).ToString());
                    }
                }
                return res;
            }
            finally
            {
                cn.Close(); // закрытие соединения с БД
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Add_new_factory(String name, String address, String boss)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO factory(name, address, boss) VALUES (?, ?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@newName", name);
                cmd.Parameters.AddWithValue("@newAddress", address);
                cmd.Parameters.AddWithValue("@newBoss", boss);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("factory");
            }
        }

        private void Add_new_Department(String factoryName, String boss)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Department(factoryName, boss) VALUES (?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@factoryName", factoryName);
                cmd.Parameters.AddWithValue("@boss", boss);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Department");
            }
        }

        private void Add_new_ManufactureTechnology(String description,
                                                   String developer,
                                                   String duration)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO ManufactureTechnology(description, developer, duration) VALUES (?, ?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@developer", developer);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("ManufactureTechnology");
            }
        }

        private void Add_new_Product(String factoryNumber,
                                     String departmentNumber,
                                     String name,
                                     String usage,
                                     String weight,
                                     String manufactureTechnologyArticle)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Product(factoryNumber, departmentNumber, name, usage, weight, manufactureTechnologyArticle) VALUES (?, ?, ?, ?, ?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@factoryNumber", factoryNumber);
                cmd.Parameters.AddWithValue("@departmentNumber", departmentNumber);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@usage", usage);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@manufactureTechnologyArticle", manufactureTechnologyArticle);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Product");
            }
        }

        private void Add_new_SparePart(String name,
                                       String productArticle,
                                       String weight,
                                       String size,
                                       String vendorArticle,
                                       String delivery)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO SparePart(name, productArticle, weight, size, vendorArticle, delivery) VALUES (?, ?, ?, ?, ?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@productArticle", productArticle);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@vendorArticle", vendorArticle);
                cmd.Parameters.AddWithValue("@delivery", delivery);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("SparePart");
            }
        }
       
        private void Add_new_Vendor(String name,
                                    String region,
                                    String adress,
                                    String boss)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "INSERT INTO Vendor(name, region, adress, boss) VALUES (?, ?, ?, ?)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@region", region);
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.Parameters.AddWithValue("@boss", boss);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Vendor");
            }
        }
        // вывод в листбокс
        private void refresh_listbox(String par)
        {
            if(par.Equals("factory"))
            {
                listBox1.Items.Clear();
                // переносим список фамилий в listBox1
                foreach (String i in Get_factories())
                    listBox1.Items.Add(i);
            } 
            else
            if (par.Equals("Department"))
            {
                listBox1.Items.Clear();
                foreach (String i in Get_Departments())
                    listBox1.Items.Add(i);
            }
            else
            if (par.Equals("ManufactureTechnology"))
            {
                listBox1.Items.Clear();
                foreach (String i in Get_ManufactureTechnology())
                    listBox1.Items.Add(i);
            }
            else
            if (par.Equals("Product"))
            {
                listBox1.Items.Clear();
                foreach (String i in Get_Product())
                    listBox1.Items.Add(i);
            }
            else
            if (par.Equals("SparePart"))
            {
                listBox1.Items.Clear();
                foreach (String i in Get_SparePart())
                    listBox1.Items.Add(i);
            }
            else
            if (par.Equals("Vendor"))
            {
                listBox1.Items.Clear();
                foreach (String i in Get_Vendor())
                    listBox1.Items.Add(i);
            }

        }

        private List<String> Get_Vendor()
        {
            List<String> res = new List<String>();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT article, name, region, adress, boss FROM Vendor";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(
                              rd.GetValue(rd.GetOrdinal("article")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("name")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("region")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("adress")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("boss")).ToString());
                    }
                }
                return res;
            }
            finally
            {
                cn.Close(); // закрытие соединения с БД
            }
        }

        private List<String> Get_SparePart()
        {
            List<String> res = new List<String>();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT article, name, productArticle, weight, size, vendorArticle, delivery FROM SparePart";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(
                              rd.GetValue(rd.GetOrdinal("article")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("name")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("productArticle")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("weight")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("size")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("vendorArticle")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("delivery")).ToString());
                    }
                }
                return res;
            }
            finally
            {
                cn.Close(); // закрытие соединения с БД
            }
        }

        private List<String> Get_Product()
        {
            List<String> res = new List<String>();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT article, factoryNumber, departmentNumber, name, usage, weight, manufactureTechnologyArticle FROM Product";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(
                              rd.GetValue(rd.GetOrdinal("article")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("factoryNumber")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("departmentNumber")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("name")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("usage")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("weight")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("manufactureTechnologyArticle")).ToString());
                    }
                }
                return res;
            }
            finally
            {
                cn.Close(); // закрытие соединения с БД
            }
        }

        private List<String> Get_ManufactureTechnology()
        {
            List<String> res = new List<String>();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT article, description, developer, duration FROM ManufactureTechnology";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(
                              rd.GetValue(rd.GetOrdinal("article")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("description")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("developer")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("duration")).ToString());
                    }
                }
                return res;
            }
            finally
            {
                cn.Close(); // закрытие соединения с БД
            }
        }

        private List<String> Get_Departments()
        {
            List<String> res = new List<String>();
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT number, factoryName, boss FROM Department";
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Add(
                              rd.GetValue(rd.GetOrdinal("number")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("factoryName")).ToString() + " "
                            + rd.GetValue(rd.GetOrdinal("boss")).ToString());
                    }
                }
                return res;
            }
            finally
            {
                cn.Close(); // закрытие соединения с БД
            }
        }

        private void Delete_Department(String number)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Department WHERE number=?";
                cmd.Parameters.AddWithValue("@number", number);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(e.Message.ToString());
            }
            finally
            {
                cn.Close();
                refresh_listbox("Department");
            }
        }

        private void Delete_Factory(String number)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM factory WHERE number=?";
                cmd.Parameters.AddWithValue("@number", number);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("factory");
            }
        }

        private void Delete_ManufactureTechnology(String article)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM ManufactureTechnology WHERE article=?";
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("ManufactureTechnology");
            }
        }

        private void Delete_Product(String article)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Product WHERE article=?";
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Product");
            }
        }

        private void Delete_SparePart(String article)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM SparePart WHERE article=?";
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("SparePart");
            }
        }

        private void Delete_Vendor(String article)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Vendor WHERE article=?";
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Vendor");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            refresh_listbox("factory");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Add_new_factory(textBox_Name.Text, textBox_Address.Text, textBox_Boss.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Factory(textBox_Delete_Number.Text);
        }
         
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Update_factory(textBox_Delete_Number.Text, textBox_Name.Text, textBox_Address.Text, textBox_Boss.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Add_new_Department(textBox_Department_fn.Text, textBox_Department_Boss.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            refresh_listbox("Department");
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            Delete_Department(textBox_Department_Del.Text);
        }
        // вывод в поля
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = listBox1.SelectedItem.ToString();
            string selectedTab = tabControl1.SelectedTab.Text;
            string[] val = selected.Split(' ');
            if (selectedTab.Equals("factory"))
            {
                textBox_Delete_Number.Text = val[0];
                textBox_Name.Text = val[1];
                textBox_Address.Text = val[2];
                textBox_Boss.Text = val[3];
            }
            else
            if(selectedTab.Equals("Department"))
            {
                textBox_Department_Del.Text = val[0];
                textBox_Department_fn.Text =  val[1];
                textBox_Department_Boss.Text = val[2];
                // зум вс по знам 1400 за 10 мин до начала написать на почту 5e2d@mail.ru
            }
            else
            if (selectedTab.Equals("ManufactureTechnology"))
            {
                textBox1.Text = val[1];
                textBox2.Text = val[2];
                textBox3.Text = val[3];
                textBox4.Text = val[0];
            }
            else
            if (selectedTab.Equals("Product"))
            {
                textBox11.Text= val[0];
                textBox7.Text = val[1];
                textBox6.Text = val[2];
                textBox5.Text = val[3];
                textBox10.Text= val[4];
                textBox9.Text = val[5];
                textBox8.Text = val[6];
            }
            else
            if (selectedTab.Equals("SparePart"))
            {
                textBox12.Text = val[0];
                textBox18.Text = val[1];
                textBox17.Text = val[2];
                textBox16.Text = val[3];
                textBox15.Text = val[4];
                textBox14.Text = val[5];
                textBox13.Text = val[6];
            }
            else
            if (selectedTab.Equals("Vendor"))
            {
                textBox19.Text = val[0];
                textBox20.Text = val[1];
                textBox22.Text = val[2];
                textBox21.Text = val[3];
                textBox23.Text = val[4];
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text;
            refresh_listbox(selectedTab);
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            refresh_listbox("ManufactureTechnology");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            refresh_listbox("Product");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            refresh_listbox("SparePart");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            refresh_listbox("Vendor");
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Add_new_ManufactureTechnology(textBox1.Text,
                                              textBox2.Text,
                                              textBox3.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Add_new_Product(textBox7.Text    ,
                                textBox6.Text    ,
                                textBox5.Text    ,
                                textBox10.Text   ,
                                textBox9.Text    ,
                                textBox8.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Add_new_SparePart(textBox13.Text,
                                  textBox18.Text,
                                  textBox17.Text,
                                  textBox16.Text,
                                  textBox15.Text,
                                  textBox14.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                Add_new_Vendor(textBox20.Text,
                               textBox22.Text,
                               textBox21.Text,
                               textBox23.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Delete_ManufactureTechnology(textBox4.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Delete_Product(textBox11.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Delete_SparePart(textBox12.Text);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Delete_Vendor(textBox19.Text);
        }

        private void Update_factory(String number, String name, String address, String boss)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE factory SET name = ?, address = ?, boss = ? WHERE number = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@newName", name);
                cmd.Parameters.AddWithValue("@newAddress", address);
                cmd.Parameters.AddWithValue("@newBoss", boss);
                cmd.Parameters.AddWithValue("@number", number);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("factory");
            }
        }

        private void Update_Department(String number, String factoryName, String boss)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "UPDATE Department SET factoryName = ?, boss = ? WHERE number = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@factoryName", factoryName);
                cmd.Parameters.AddWithValue("@boss", boss);
                cmd.Parameters.AddWithValue("@number", number);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Department");
            }
        }

        private void Update_ManufactureTechnology( String article,
                                                   String description,
                                                   String developer,
                                                   String duration)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "UPDATE ManufactureTechnology SET description = ?, developer = ?, duration = ? WHERE article = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@developer", developer);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("ManufactureTechnology");
            }
        }

        private void Update_Product( String article, 
                                     String factoryNumber,
                                     String departmentNumber,
                                     String name,
                                     String usage,
                                     String weight,
                                     String manufactureTechnologyArticle)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "UPDATE Product SET factoryNumber = ?, departmentNumber = ?, name = ?, usage = ?, weight = ?, manufactureTechnologyArticle = ? WHERE article = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@factoryNumber", factoryNumber);
                cmd.Parameters.AddWithValue("@departmentNumber", departmentNumber);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@usage", usage);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@manufactureTechnologyArticle", manufactureTechnologyArticle);
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Product");
            }
        }

        private void Update_SparePart( String article,
                                       String name,
                                       String productArticle,
                                       String weight,
                                       String size,
                                       String vendorArticle,
                                       String delivery)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "UPDATE SparePart SET name = ?, productArticle = ?, weight = ?, size = ?, vendorArticle = ?, delivery = ? WHERE article = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@productArticle", productArticle);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@vendorArticle", vendorArticle);
                cmd.Parameters.AddWithValue("@delivery", delivery);
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("SparePart");
            }
        }

        private void Update_Vendor( String article,
                                    String name,
                                    String region,
                                    String adress,
                                    String boss)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "UPDATE Vendor SET name  = ?, region  = ?, adress  = ?, boss = ? WHERE article = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@region", region);
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.Parameters.AddWithValue("@boss", boss);
                cmd.Parameters.AddWithValue("@article", article);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
                refresh_listbox("Vendor");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Update_Department(textBox_Department_Del.Text, textBox_Department_fn.Text, textBox_Department_Boss.Text);

            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Update_ManufactureTechnology(textBox4.Text,
                                         textBox1.Text,
                                         textBox2.Text,
                                         textBox3.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Update_Product(textBox11.Text,
                           textBox7.Text,
                           textBox6.Text,
                           textBox5.Text,
                           textBox10.Text,
                           textBox9.Text,
                           textBox8.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                Update_SparePart(textBox12.Text,
                             textBox13.Text,
                             textBox18.Text,
                             textBox17.Text,
                             textBox16.Text,
                             textBox15.Text,
                             textBox14.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                Update_Vendor(textBox19.Text,
                          textBox20.Text,
                          textBox22.Text,
                          textBox21.Text,
                          textBox23.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }

        private void ExecuteQuery(string query_text)
        {
            cn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = query_text;
                cmd.Parameters.Clear();

                OleDbDataReader reader = cmd.ExecuteReader();

                listBox1.Items.Clear();
                while (reader.Read())
                {
                    string res = "";
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        res += " " + reader[i].ToString(); 
                    }
                    listBox1.Items.Add(res);
                }
            }
            finally
            {
                cn.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                ExecuteQuery(richTextBox1.Text);
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("ERROR: " + ex.GetType());
                listBox2.Items.Add(ex.Message.ToString());
            }
        }
    }// 13(вс) 1400 экзамен
}
