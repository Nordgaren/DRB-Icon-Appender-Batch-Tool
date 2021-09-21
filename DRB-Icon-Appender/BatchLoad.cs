﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRB_Icon_Appender
{
    public partial class BatchLoad : Form
    {
        private static List<SpriteShape> Shapes;

        public BatchLoad(List<SpriteShape> shapes)
        {
            InitializeComponent();
            Shapes = new List<SpriteShape>(shapes);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                var list = JsonConvert.DeserializeObject<List<SpriteShape>>(File.ReadAllText(txtPath.Text));

                foreach (var item in list)
                {
                    Shapes.Add(item);
                }
            }
        }

        public static List<SpriteShape> GetShapes()
        {
            return Shapes;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var browseDialog = new OpenFileDialog()
            {
                AddExtension = true,
                FileName = "",
                DefaultExt = ".json",
                Title = "Batch load file",
                Filter = "Json(*.json) | *.json"
            };

            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = browseDialog.FileName;
            }
        }
    }
}