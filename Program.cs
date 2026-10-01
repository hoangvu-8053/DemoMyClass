using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DemoMyClass;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}

// ================= CLASS NGƯỜI DÙNG (myclass) =================
public class NguoiDung
{
    public string HoTen { get; set; } = "";
    public string GioiTinh { get; set; } = "";
    public DateTime NgaySinh { get; set; }
    public List<string> SoThich { get; set; } = new List<string>();

    public string XuatThongTin()
    {
        return $"Họ tên: {HoTen}, Giới tính: {GioiTinh}, " +
               $"Ngày sinh: {NgaySinh:dd/MM/yyyy}, " +
               $"Sở thích: {string.Join(", ", SoThich)}.";
    }
}

// ================= FORM =================
public class Form1 : Form
{
    private readonly TextBox txtHoTen = new TextBox();
    private readonly DateTimePicker dtpNgaySinh = new DateTimePicker();
    private readonly RadioButton rdoNam = new RadioButton();
    private readonly RadioButton rdoNu = new RadioButton();
    private readonly CheckBox chkTheThao = new CheckBox();
    private readonly CheckBox chkPhimAnh = new CheckBox();
    private readonly CheckBox chkDuLich = new CheckBox();
    private readonly Button btnXuat = new Button();

    public Form1()
    {
        Text = "Demo myclass";
        ClientSize = new Size(640, 190);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        Controls.Add(new Label { Text = "Thông tin", Location = new Point(20, 12), AutoSize = true });

        // Dòng 1: Họ tên + Ngày sinh
        Controls.Add(new Label { Text = "Họ tên", Location = new Point(20, 47), AutoSize = true });
        txtHoTen.Location = new Point(90, 44);
        txtHoTen.Size = new Size(200, 25);
        Controls.Add(txtHoTen);

        Controls.Add(new Label { Text = "Ngày sinh", Location = new Point(320, 47), AutoSize = true });
        dtpNgaySinh.Location = new Point(395, 44);
        dtpNgaySinh.Size = new Size(220, 25);
        dtpNgaySinh.Format = DateTimePickerFormat.Short;
        Controls.Add(dtpNgaySinh);

        // Dòng 2: Giới tính + Sở thích
        Controls.Add(new Label { Text = "Giới tính", Location = new Point(20, 92), AutoSize = true });
        rdoNam.Text = "Nam";
        rdoNam.Checked = true;
        rdoNam.Location = new Point(90, 89);
        rdoNam.AutoSize = true;
        rdoNu.Text = "Nữ";
        rdoNu.Location = new Point(155, 89);
        rdoNu.AutoSize = true;
        Controls.Add(rdoNam);
        Controls.Add(rdoNu);

        Controls.Add(new Label { Text = "Sở thích", Location = new Point(250, 92), AutoSize = true });
        chkTheThao.Text = "Thể thao";
        chkTheThao.Location = new Point(320, 89);
        chkTheThao.AutoSize = true;
        chkPhimAnh.Text = "Phim ảnh";
        chkPhimAnh.Location = new Point(410, 89);
        chkPhimAnh.AutoSize = true;
        chkDuLich.Text = "Du lịch";
        chkDuLich.Location = new Point(510, 89);
        chkDuLich.AutoSize = true;
        Controls.Add(chkTheThao);
        Controls.Add(chkPhimAnh);
        Controls.Add(chkDuLich);

        // Nút xuất thông tin
        btnXuat.Text = "Xuất thông tin";
        btnXuat.Location = new Point(500, 135);
        btnXuat.Size = new Size(115, 30);
        btnXuat.Click += BtnXuat_Click;
        Controls.Add(btnXuat);
    }

    private void BtnXuat_Click(object? sender, EventArgs e)
    {
        if (txtHoTen.Text.Trim() == "")
        {
            MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo");
            txtHoTen.Focus();
            return;
        }

        // Tạo đối tượng myclass và gán dữ liệu từ form
        var nd = new NguoiDung
        {
            HoTen = txtHoTen.Text.Trim(),
            GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
            NgaySinh = dtpNgaySinh.Value
        };
        if (chkTheThao.Checked) nd.SoThich.Add("Thể thao");
        if (chkPhimAnh.Checked) nd.SoThich.Add("Phim ảnh");
        if (chkDuLich.Checked) nd.SoThich.Add("Du lịch");

        MessageBox.Show(nd.XuatThongTin(), "Thông tin người dùng.");
    }
}