using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatvanyossagokApplication
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection(
                @"Server=localhost;Port=3307;Database=latvanyossagokdb;Uid=root;");
            conn.Open();

            CreateDatabase();
            CreateTableLatvanyossagok();

        }
       
        private void CreateDatabase()
        {
            var cmd = conn.CreateCommand(); //cmd nevű parancs létrehozása
            /**
             *cmd nevű parancs tartalmának meghatározása (comandText) 
             */
            cmd.CommandText = @"CREATE DATABASE IF NOT EXISTS `latvanyossagokdb` 
                                DEFAULT CHARACTER SET utf8 
                                COLLATE utf8_hungarian_ci;
                                USE `latvanyossagokdb`";

            cmd.ExecuteNonQuery(); //cmd nevű parancs végrehajtása

        }

        private void CreateTableLatvanyossagok()
        {

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS `latvanyossagok` (
                              `id` int(11) NOT NULL,
                              `nev` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
                              `leiras` varchar(1000) COLLATE utf8_hungarian_ci NOT NULL,
                              `ar` int(11) NOT NULL,
                              `varos_id` int(11) NOT NULL)";
            cmd.ExecuteNonQuery();

        }


    }
}
