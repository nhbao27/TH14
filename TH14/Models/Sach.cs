using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TH14.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Gia khong duoc de trong")]
    [Range(50, 1000, ErrorMessage = "Gia phai nam trong khoang 50 den 1000")]
    public decimal Gia { get; set; } // Đã bỏ dấu ? vì có [Required]

    public string? Anh { get; set; }

    public virtual TheLoai? MaTlNavigation { get; set; } // Đã sửa loại bỏ mâu thuẫn null!
}