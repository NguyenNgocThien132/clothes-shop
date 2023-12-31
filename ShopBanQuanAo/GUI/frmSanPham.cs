﻿using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmSanPham : Form
    {
        private string fileAddress;
        private byte[] img; // mã hóa hình ảnh lưu trử
        BUS_SanPham busProduct = new BUS_SanPham();
        DTO_SanPham dtoProduct;

        public frmSanPham()
        {
            InitializeComponent();
        }
        // thiết lặp giá trị
        private void SetValue(bool param, bool isLoad)
        {
            txtId.Text = null;

            txtName.Text = null;
            txtQuantity.Text = null;
            txtUnitPrice.Text = null;
            txtImportUnitPrice.Text = null;
            txtNote.Text = null;
            btnInsert.Enabled = param;
            pcbProduct.Image = null;
            if (isLoad)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = !param;
                btnDelete.Enabled = !param;
            }
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Copy ảnh 
        private Image CloneImage(string path)
        {
            Image result;
            using (Bitmap original = new Bitmap(path))
            {
                result = (Bitmap)original.Clone();

            };
            return result;
        }

        //Lưu trử ảnh dạng mảng
        private byte[] ImageToByteArray(PictureBox pictureBox)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }

        private void LoadGridView()
        {
            gvProduct.Columns[0].HeaderText = "Mã hàng";
            gvProduct.Columns[1].HeaderText = "Tên hàng";
            gvProduct.Columns[2].HeaderText = "Số lượng";
            gvProduct.Columns[3].HeaderText = "Đơn giá nhập";
            gvProduct.Columns[4].HeaderText = "Đơn giá bán";
            gvProduct.Columns[5].HeaderText = "Hình ảnh";
            gvProduct.Columns[6].HeaderText = "Ghi chú";
            foreach (DataGridViewColumn item in gvProduct.Columns)
                item.DividerWidth = 1;

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)gvProduct.Columns[5];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            
            gvProduct.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvProduct.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvProduct.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvProduct.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvProduct.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvProduct.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvProduct.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Kiểm tra số
        private bool CheckIsNummber(string text)
        {
            int s;
            return int.TryParse(text, out s);
        }
        // mở  ảnh trong disk
        private void OpenImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            //File ảnh cho phép đc upload
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "Chọn ảnh cần upload";

            //Nếu chọn OK thì úp load ảnh
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                pcbProduct.Image = CloneImage(fileAddress);
                pcbProduct.ImageLocation = fileAddress;
                img = ImageToByteArray(pcbProduct);
            }
        }

        // Load form sản phẩm
        private void frmProduct_Load(object sender, EventArgs e)
        {
            gvProduct.DataSource = busProduct.ListOfProducts();
            LoadGridView();
            SetValue(true, false);
            txtName.Focus();
        }
        // Thêm sản phẩm mới
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!CheckIsNummber(txtQuantity.Text) || !CheckIsNummber(txtUnitPrice.Text) || !CheckIsNummber(txtImportUnitPrice.Text))
                MsgBox("Vui lòng nhập chữ số!", true);
            else if (txtName.Text == "")
                MsgBox("Thiếu trường thông tin!", true);
            else if (pcbProduct.Image == null)
                MsgBox("Vui lòng chọn hình cho sản phẩm!", true);
            else
            {
                dtoProduct = new DTO_SanPham
                (
                    txtName.Text,
                    int.Parse(txtQuantity.Text),
                    int.Parse(txtImportUnitPrice.Text),
                    int.Parse(txtUnitPrice.Text),
                    ImageToByteArray(pcbProduct), 
                    txtNote.Text
                );
                if (busProduct.InsertProduct(dtoProduct))
                {
                    gvProduct.DataSource = busProduct.ListOfProducts();
                    LoadGridView();
                    MsgBox("Thêm sản phẩm thành công");
                }
                else
                {
                    MsgBox("Thêm sản phẩm không được", true);
                }
            }
        }
        //Thêm ảnh
        private void btnInsertPicture_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        //CHọn nhiều trên gv
        private void gvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvProduct.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                txtId.ReadOnly = true;
                txtId.Text = gvProduct.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = gvProduct.CurrentRow.Cells[1].Value.ToString();
                txtQuantity.Text = gvProduct.CurrentRow.Cells[2].Value.ToString();
                txtImportUnitPrice.Text = gvProduct.CurrentRow.Cells[3].Value.ToString();
                txtUnitPrice.Text = gvProduct.CurrentRow.Cells[4].Value.ToString();
                
                MemoryStream memoryStream = new MemoryStream((byte[])gvProduct.CurrentRow.Cells[5].Value);
                pcbProduct.Image = Image.FromStream(memoryStream);
                txtNote.Text = gvProduct.CurrentRow.Cells[6].Value.ToString();
            }
        }
        // Cập nhật sản phẩm
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!CheckIsNummber(txtQuantity.Text) || !CheckIsNummber(txtUnitPrice.Text) || !CheckIsNummber(txtImportUnitPrice.Text))
                    MsgBox("Vui lòng nhập chữ số!", true);
                else if (txtName.Text == "")
                    MsgBox("Thiếu trường thông tin!", true);
                else if (pcbProduct.Image == null)
                    MsgBox("Vui lòng chọn hình!", true);
                else
                {
                    dtoProduct = new DTO_SanPham
                    (
                        int.Parse(txtId.Text),
                        txtName.Text,
                        int.Parse(txtQuantity.Text),
                        int.Parse(txtImportUnitPrice.Text),
                        int.Parse(txtUnitPrice.Text),
                        ImageToByteArray(pcbProduct),
                        txtNote.Text
                    );
                    if (busProduct.UpdateProduct(dtoProduct))
                    {
                        gvProduct.DataSource = busProduct.ListOfProducts();
                        LoadGridView();
                        MsgBox("Sửa sản phẩm thành công!");
                    }
                    else
                    {
                        MsgBox("Sửa sản phẩm không được", true);
                    }
                }
            }
        }
        // Xóa sản phẩm
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busProduct.DeleteProduct(int.Parse(txtId.Text)))
                {
                    gvProduct.DataSource = busProduct.ListOfProducts();
                    LoadGridView();
                    MsgBox("Xóa sản phẩm thành công");
                }
                else
                    MsgBox("Xóa không thành công!");
            }
        }

        // đặt lại giá trị sản phẩm
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }

        // Tìm kiếm sản phẩm trong gv
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string name = txtSearch.Text.Trim();
            if (name == "")
            {
                frmProduct_Load(sender, e);
                txtSearch.Focus();
            }
            else
            {
                DataTable data = busProduct.SearchProduct(txtSearch.Text);
                gvProduct.DataSource = data;
            }
        }
    }
}
